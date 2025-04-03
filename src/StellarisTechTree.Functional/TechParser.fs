namespace StellarisTechTree.Functional

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

    let public words = pchar '"' >>. many1CharsTill anyChar (pchar '"') <!> "words"

    let public singleWord =
        opt (skipChar '"') >>. many1CharsTill anyChar (skipChar '"' <|> spaces1 <|> eof)
        <!> "singleWord"

    let public stringValue =
        choice [ attempt words; attempt singleWord ] .>> opt (skipChar '"')
        <!> "stringValue"
        |>> fun x ->
            match x with
            | "yes" -> TypeValue.BooleanValue true
            | "no" -> TypeValue.BooleanValue false
            | any -> TypeValue.StringValue any

    let public variable =
        pstring "@" .>>. singleWord <!> "variable"
        |>> (fun (a, b) -> $"{a}{b}")
        |>> TypeValue.Variable

    let private numberFormat =
        NumberLiteralOptions.AllowMinusSign ||| NumberLiteralOptions.AllowFraction

    let public digitValue =
        numberLiteral numberFormat "number" <!> "digitValue"
        |>> fun nl ->
            if nl.IsInteger then
                TypeValue.IntValue(int32 nl.String)
            else
                TypeValue.FloatValue(float nl.String)

    let public propertyValue =
        choice [ attempt variable; attempt digitValue; attempt stringValue ]
        <!> "propertyValue"

    let public listOfStrings =
        skipString "{" >>. manyTill (spaces >>. propertyValue .>> spaces) (skipString "}")
        .>> opt spaces
        <!> "listOfStrings"

    let public nameIdentifier =
        spaces >>. singleWord .>> equalsSign .>> spaces <!> "nameIdentifier" |>> Name

    let public comparatorIdentifier =
        spaces >>. singleWord .>>. conditionChar .>> ws <!> "comparatorIdentifier"
        |>> Comparator

    let public identifier =
        choice
            [ attempt nameIdentifier |>> NameIdentifier
              attempt comparatorIdentifier |>> ComparatorIdentifier ]
        <!> "identifier"

    let public property =
        identifier .>>. propertyValue .>> spaces <!> "property"
        |>> Property.SingleProperty

    let public arrayProperty =
        nameIdentifier .>>. listOfStrings .>> opt spaces <!> "arrayProperty"
        |>> ArrayProperty

    let public plainObjectProperty =
        identifier .>> openingBracketLiteral
        .>>. opt (many (choice [ attempt arrayProperty; attempt property ]))
        .>> closingBracketLiteral
        <!> "plainObjectProperty"
        |>> fun (id, value) ->
            if value.IsSome then
                Property.ObjectProperty(id.getName (), value.Value)
            else
                id.getName () |> EmptyObject

    let public objProperty, private objPropertyImpl: Parser<Property, unit> * Parser<Property, unit> ref =
        createParserForwardedToRef ()

    objPropertyImpl.Value <-
        identifier .>> openingBracketLiteral
        .>>. many (
            choice
                [ attempt objProperty
                  attempt plainObjectProperty
                  attempt arrayProperty
                  attempt property ]
        )
        .>> closingBracketLiteral
        <!> "objPropertyImpl"
        |>> fun (id, value) -> Property.ObjectProperty(id.getName (), value)

    let private matchResult result =
        match result with
        | Success(result, _, _) -> Result.Ok result
        | Failure(message, _, _) -> Result.Error message

    let private parse file =
        Regex.Replace(file, "#.+", String.Empty) |> run (many objProperty)

    let public getParsingResult file = file |> parse |> matchResult
