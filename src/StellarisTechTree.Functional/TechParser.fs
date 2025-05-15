namespace StellarisTechTree.Functional

open FParsec
open Primitives
open System
open System.Text.RegularExpressions
open StellarisTechTree.Functional.Types

module TechParser =
    /// Debug function
    let (<!>) (p: Parser<_, _>) label : Parser<_, _> =
        fun stream ->
            // printfn $"%A{stream.Position}: Entering %s{label}"
            let reply = p stream
            // printfn $"%A{stream.Position}: Leaving %s{label} (%A{reply.Status})"
            reply

    let private numberFormat =
        NumberLiteralOptions.AllowMinusSign ||| NumberLiteralOptions.AllowFraction
    
    let public numberBasedValue =
        spaces >>. numberLiteral numberFormat "number" <!> "numberBasedValue"
        |>> fun nl ->
            if nl.IsInteger then
                TypeValue.IntValue(int32 nl.String)
            else
                TypeValue.FloatValue(float nl.String)
    
    let public singleWord: Parser<string, unit> =
        manyChars (letter <|> digit <|> anyOf [ '_'; '/' ]) <!> "singleWord"

    let public multipleWords: Parser<string, unit> =
        quote >>. stringsSepBy singleWord (pstring " ") .>> quote .>> opt eof
        <!> "manyWords"

    let public stringOrBoolValue: Parser<TypeValue, unit> =
        spaces >>. choice [ attempt multipleWords; attempt singleWord ]
        <!> "stringOrBoolValue"
        |>> fun x ->
            match x with
            | "yes" -> TypeValue.BooleanValue true
            | "no" -> TypeValue.BooleanValue false
            | any -> TypeValue.StringValue any

    let public variableValue =
        spaces >>. pchar '@' >>. singleWord <!> "variableValue"
        |>> fun x -> $"@{x}"
        |>> TypeValue.Variable

    let public propertyValueGateway =
        choice [ attempt variableValue; attempt numberBasedValue; attempt stringOrBoolValue ]
        <!> "propertyValueGateway"

    let public nameIdentifier =
        spaces >>. singleWord .>> spaces .>> equalsSign <!> "nameIdentifier" |>> Name

    let public comparatorIdentifier =
        spaces >>. singleWord .>> spaces .>>. conditionChar <!> "comparatorIdentifier"
        |>> Comparator

    let public identifierGateway =
        choice
            [ attempt nameIdentifier |>> NameIdentifier
              attempt comparatorIdentifier |>> ComparatorIdentifier ]
        <!> "identifierGateway"

    let public singleProperty =
        identifierGateway .>>. propertyValueGateway <!> "singleProperty"
        |>> Property.SingleProperty

    let public plainArrayValue =
        spaces >>. propertyValueGateway <!> "plainArrayValue"
        |>> ArrayValue.PlainArrayValue

    let public complexArrayValue =
        nameIdentifier .>> spaces .>> openingBracketLiteral
        .>>. manyTill (propertyValueGateway .>> spaces) closingBracketLiteral
        <!> "complexArrayValue"
        |>> ArrayValue.ComplexArray

    let public arrayValuesGateway =
        choice [ attempt complexArrayValue; attempt plainArrayValue ]
        <!> "arrayValuesGateway"

    let public arrayProperty, private arrayPropertyImpl: Parser<Property, unit> * Parser<Property, unit> ref =
        createParserForwardedToRef ()

    arrayPropertyImpl.Value <-
        spaces >>. nameIdentifier .>> spaces .>> openingBracketLiteral
        .>>. manyTill (arrayValuesGateway .>> spaces) closingBracketLiteral
        <!> "arrayProperty"
        |>> fun (id, value) -> Property.ArrayProperty(id, value)

    let public simpleObjectProperty =
        identifierGateway .>> ws .>> openingBracketLiteral
        .>>. manyTill (choice [ attempt arrayProperty; attempt singleProperty ] .>> spaces) closingBracketLiteral
        <!> "simpleObjectProperty"
        |>> fun (id, value) -> Property.ObjectProperty(id.getName (), value)

    let public complexObjectProperty, private complexObjectPropertyImpl: Parser<Property, unit> *
                                                                         Parser<Property, unit> ref =
        createParserForwardedToRef ()

    complexObjectPropertyImpl.Value <-
        spaces >>. identifierGateway .>> ws .>> openingBracketLiteral
        .>>. manyTill
            (choice
                [ attempt complexObjectProperty
                  attempt simpleObjectProperty
                  attempt arrayProperty
                  attempt singleProperty ]
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
