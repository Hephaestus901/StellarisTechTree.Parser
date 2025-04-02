namespace StellarisTechTree.Functional

open FParsec
open StellarisTechTree.Functional.Types
open System
open System.Text.RegularExpressions

module LocaleParser =   
    let private word =
        opt (skipChar '"')
        >>. many1CharsTill anyChar (attempt (pchar '"' .>> followedByNewline))
        .>> opt (skipChar '"')
        .>> spaces

    let private stringValue =
        opt (skipChar '"') >>. word .>> opt (skipChar '"') |>> LocaleValue.StringValue

    let private nameIdentifier =
        spaces >>. many1CharsTill anyChar (pchar ':')
        .>> opt (skipChar ':')
        .>> opt digit
        .>> spaces
        |>> Name

    let private property =
        nameIdentifier .>>. stringValue .>> spaces |>> LocaleObject.SingleProperty

    let private matchResult result =
        match result with
        | Success(result, _, _) -> Result.Ok result
        | Failure(message, _, _) -> Result.Error message

    let private locale = nameIdentifier >>. many (attempt property)

    let private parse file =
        Regex.Replace(file, "#.+", String.Empty) |> run locale

    let public getParsingResult file = file |> parse |> matchResult
