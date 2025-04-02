module StellarisTechTree.Functional.Tests.Locale.Tests

open LocaleTest
open StellarisTechTree.Functional
open System
open Xunit

[<Fact>]
let ``Should parse locale`` () =
    let parsingResult = LocaleParser.getParsingResult LocaleTest

    let result =
        match parsingResult with
        | Result.Ok _ -> String.Empty
        | Result.Error error -> error

    Assert.Equal(String.Empty, result)
