namespace StellarisTechTree.Functional

open FParsec
open StellarisTechTree.Functional.Types

module VariableParser =
    let private name =
        opt spaces >>.
        many1CharsTill anyChar (pchar ' ')
        .>> spaces
        .>> opt (skipChar '=')
        .>> spaces
        |>> Name

    let private variable =
        name .>>. pfloat
        .>> spaces
        |>> VariableObject
    
    let private matchResult result =
        match result with
        | Success(result, _, _) -> Result.Ok result
        | Failure(message, _, _) -> Result.Error message

    let public getParsingResult file = file |> run (many variable) |> matchResult
