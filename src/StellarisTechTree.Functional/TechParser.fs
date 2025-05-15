namespace StellarisTechTree.Functional

open System.Collections.Generic
open FParsec
open Primitives
open System
open System.Text.RegularExpressions
open StellarisTechTree.Functional.Types

module TechParser =
    let (<!>) (p: Parser<_, _>) label : Parser<_, _> =
        fun stream ->
            printfn $"%A{stream.Position}: Entering %s{label}"
            let reply = p stream
            printfn $"%A{stream.Position}: Leaving %s{label} (%A{reply.Status})"
            reply

    let private numberFormat =
        NumberLiteralOptions.AllowMinusSign ||| NumberLiteralOptions.AllowFraction

    let public singleWord: Parser<string, unit> =
        manyChars (letter <|> digit <|> anyOf [ '_'; '/' ]) <!> "singleWord"

    let public manyWords: Parser<string, unit> =
        quote >>. stringsSepBy singleWord (pstring " ")  .>> quote .>> opt eof
        <!> "manyWords"

    /// opt skip start
    let public stringValue: Parser<TypeValue, unit> =
        spaces >>. choice [ attempt manyWords; attempt singleWord ] <!> "stringValue"
        |>> fun x ->
            match x with
            | "yes" -> TypeValue.BooleanValue true
            | "no" -> TypeValue.BooleanValue false
            | any -> TypeValue.StringValue any

    /// opt skip start
    let public variable =
        spaces >>. pchar '@' >>. singleWord <!> "variable"
        |>> fun x -> $"@{x}"
        |>> TypeValue.Variable

    /// opt skip start
    let public digitValue =
        spaces >>. numberLiteral numberFormat "number" <!> "digitValue"
        |>> fun nl ->
            if nl.IsInteger then
                TypeValue.IntValue(int32 nl.String)
            else
                TypeValue.FloatValue(float nl.String)

    /// opt skip start
    let public propertyValue =
        spaces >>. choice [ attempt variable; attempt digitValue; attempt stringValue ]
        <!> "propertyValue"

    let public listOfStrings =
        spaces
        >>. openingBracketLiteral
        >>. manyTill (propertyValue .>> spaces) closingBracketLiteral
        <!> "listOfStrings"

    /// opt skip start
    let public nameIdentifier =
        spaces >>. singleWord .>> spaces .>> equalsSign <!> "nameIdentifier" |>> Name

    let public comparatorIdentifier =
        spaces >>. singleWord .>> spaces .>>. conditionChar <!> "comparatorIdentifier"
        |>> Comparator

    let public identifier =
        choice
            [ attempt nameIdentifier |>> NameIdentifier
              attempt comparatorIdentifier |>> ComparatorIdentifier ]
        <!> "identifier"

    let public property =
        identifier .>>. propertyValue <!> "property" |>> Property.SingleProperty
    
    let public plainArrayValue =
        spaces >>. propertyValue <!> "plainArrayValue" |>> ArrayValue.PlainArrayValue
    
    let public complexArrayValue =
        nameIdentifier .>>. listOfStrings <!> "arrayProperty" |>> ArrayValue.ComplexArray 

    let public arrayValues = choice [attempt complexArrayValue; attempt plainArrayValue]
    
    let public complexArrayProperty, private complexArrayPropertyImpl : Parser<Property, unit> *
                                                                         Parser<Property, unit> ref =
        createParserForwardedToRef ()
        
    complexArrayPropertyImpl.Value <-
        spaces >>. nameIdentifier
        .>> spaces
        .>> openingBracketLiteral
        .>>. manyTill (arrayValues .>> spaces) closingBracketLiteral
        <!> "complexArrayProperty"
        |>> fun (id, value) -> Property.ArrayProperty(id, value )
    
    let public simpleObjectProperty =
        identifier .>> ws .>> openingBracketLiteral
        .>>. manyTill
            (choice [ attempt complexArrayProperty; attempt property ]
             .>> spaces)
            closingBracketLiteral
        <!> "simpleObjectProperty"
        |>> fun (id, value) -> Property.ObjectProperty(id.getName (), value)

    let public complexObjectProperty, private complexObjectPropertyImpl: Parser<Property, unit> *
                                                                         Parser<Property, unit> ref =
        createParserForwardedToRef ()

    complexObjectPropertyImpl.Value <-
        spaces >>. identifier .>> ws .>> openingBracketLiteral
        .>>. manyTill
            (choice
                [ attempt complexObjectProperty
                  attempt simpleObjectProperty
                  attempt complexArrayProperty
                  attempt property ]
             .>> spaces)
            closingBracketLiteral
        <!> "complexObjectProperty"
        |>> fun (id, value) -> Property.ObjectProperty(id.getName (), value)

    let private matchResult (fileName: String) result =
        match result with
        | Success(result, _, _) -> Result.Ok result
        | Failure(message, _, _) -> Result.Error $"Error in file {fileName}: {message}"

    let private parse file =
        Regex.Replace(file, "#.+", String.Empty) |> run (many complexObjectProperty)

    let public getParsingResult (file: String, fileName: String) = file |> parse |> (matchResult fileName)
