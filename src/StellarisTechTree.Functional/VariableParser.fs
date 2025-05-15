namespace StellarisTechTree.Functional

open System
open System.Text.RegularExpressions
open FParsec
open StellarisTechTree.Functional.Types
open StellarisTechTree.Functional.Primitives

module VariableParser =
    /// Debug function
    let (<!>) (p: Parser<_, _>) label : Parser<_, _> =
        fun stream ->
            // printfn $"%A{stream.Position}: Entering %s{label}"
            let reply = p stream
            // printfn $"%A{stream.Position}: Leaving %s{label} (%A{reply.Status})"
            reply

    let private numberFormat =
        NumberLiteralOptions.AllowMinusSign ||| NumberLiteralOptions.AllowFraction

    let private name =
        spaces >>. manyChars (letter <|> digit <|> anyOf [ '_'; '@' ]) <!> "name"
        |>> Name

    let private numberBasedValue =
        spaces >>. numberLiteral numberFormat "number" <!> "numberBasedValue"
        |>> fun nl ->
            if nl.IsInteger then
                VariableValue.IntValue(int32 nl.String)
            else
                VariableValue.FloatValue(float nl.String)

    let private variable =
        name .>> spaces .>> equalsSign .>>. numberBasedValue .>> spaces
        |>> VariableObject

    let private matchResult (fileName: String) result =
        match result with
        | Success(result, _, _) -> Result.Ok result
        | Failure(message, _, _) -> Result.Error $"Error in file {fileName}: {message}"

    let private parse file =
        Regex.Replace(file, "#.+", String.Empty) |> run (many variable)
    
    let public getParsingResult (file: String, fileName: String) = file |> parse |> (matchResult fileName)
