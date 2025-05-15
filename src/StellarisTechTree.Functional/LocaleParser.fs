namespace StellarisTechTree.Functional

open FParsec
open StellarisTechTree.Functional.Types
open StellarisTechTree.Functional.Primitives
open System
open System.Text.RegularExpressions

module LocaleParser =
    /// Debug function
    let (<!>) (p: Parser<_, _>) label : Parser<_, _> =
        fun stream ->
            // printfn $"%A{stream.Position}: Entering %s{label}"
            let reply = p stream
            // printfn $"%A{stream.Position}: Leaving %s{label} (%A{reply.Status})"
            reply

    let private text =
        quote >>. many1CharsTill anyChar (attempt (quote .>> followedByNewline)) <!> "word"

    let private stringValue = spaces >>. text .>> opt quote <!> "stringValue" |>> LocaleValue.StringValue

    let private name =
        spaces >>. many1CharsTill anyChar colonChar .>> opt colonChar .>> opt digit <!> "name"
        |>> Name

    let private singleProperty =
        name .>>. stringValue .>> spaces <!> "singleProperty" |>> LocaleObject.SingleProperty

    let private locale = name >>. many (attempt singleProperty)
    
    let private matchResult (fileName: String) result =
        match result with
        | Success(result, _, _) -> Result.Ok result
        | Failure(message, _, _) -> Result.Error $"Error in file {fileName}: {message}"

    let private parse file =
        Regex.Replace(file, "#.+", String.Empty) |> run (many locale)
    
    let public getParsingResult (file: String, fileName: String) = file |> parse |> (matchResult fileName)
