module StellarisTechTree.Functional.Tests.Variable.Tests

open VariableTest
open StellarisTechTree.Functional
open System
open Xunit

[<Fact>]
let ``Should parse variables`` () =
    let parsingResult = VariableParser.getParsingResult VariableTest

    let result =
        match parsingResult with
        | Result.Ok _ -> String.Empty
        | Result.Error error -> error

    Assert.Equal(String.Empty, result)
