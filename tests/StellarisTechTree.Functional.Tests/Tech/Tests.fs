module StellarisTechTree.Functional.Tests.Tech.Tests

open FParsec
open System
open StellarisTechTree.Functional
open StellarisTechTree.Functional.Types
open Xunit

[<Theory>]
[<InlineData "has_resource">]
let ``singleWord tests`` (input: String) =
    let parsingResult = run (many TechParser.singleWord) input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) -> Assert.Equal(input, parsed[0])
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData "Distant Stars Story Pack">]
let ``words tests`` (input: String) =
    let parsingResult = run TechParser.words $"\"{input}\""

    match parsingResult with
    | ParserResult.Success(parsed, _, _) -> Assert.Equal(input, parsed)
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData "test">]
let ``string value tests`` (input: String) =
    let parsingResult = run TechParser.stringValue input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) ->
        match parsed with
        | TypeValue.StringValue value -> Assert.Equal(input, value)
        | _ -> Assert.Fail "Type mismatch"
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData ("@test", "@test")>]
[<InlineData ("""@tier2cost3
area
""", "@tier2cost3")>]
let ``variable tests`` (input: String, expected: String) =
    let parsingResult = run TechParser.variable input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) ->
        match parsed with
        | TypeValue.Variable value -> Assert.Equal(expected, value)
        | _ -> Assert.Fail "Type mismatch"
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData("15", 15)>]
let ``digit value Int32 tests `` (input: String, expected: Int32) =
    let parsingResult = run TechParser.digitValue input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) ->
        match parsed with
        | TypeValue.IntValue value -> Assert.Equal(expected, value)
        | _ -> Assert.Fail "Type mismatch"
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData("65.0", 65.0)>]
let ``digit value Float tests `` (input: String, expected: float) =
    let parsingResult = run TechParser.digitValue input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) ->
        match parsed with
        | TypeValue.FloatValue value -> Assert.Equal(expected, value)
        | _ -> Assert.Fail "Type mismatch"
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData "host_has_dlc = \"Distant Stars Story Pack\"">]
[<InlineData "has_country_flag = non_lithoid_subspecies">]
[<InlineData "area = society">]
[<InlineData "is_rare = yes">]
let ``property value test`` (input: String) =
    let parsingResult = run TechParser.property input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) -> Assert.Equal("SingleProperty", parsed.GetType().Name)
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData ("category = { \"field_manipulation\" }", "category")>]
[<InlineData ("prerequisites = { \"tech_archaeostudies\" }", "prerequisites")>]
[<InlineData ("""feature_flags = {
	unlock_arcane_deciphering
}""", "feature_flags")>]
let ``array property test`` (input: String, expectedName: String) =
    let parsingResult = run TechParser.arrayProperty input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) ->
        match parsed with
        | ArrayProperty(name, _) -> Assert.Equal(expectedName, name)
        | _ -> Assert.Fail "type mismatch"
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData("has_resource =", "has_resource")>]
let ``name identifier tests`` (input: String, expected: String) =
    let parsingResult = run TechParser.nameIdentifier input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) -> Assert.Equal(expected, parsed)
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData """tech_archaeoshield = {
    prerequisites = { "tech_archaeostudies" }
    ai_update_type = all
}
""">]
let ``plain obj tests`` (input: String) =
    let parsingResult = run TechParser.plainObjectProperty input
    
    match parsingResult with
    | ParserResult.Success(parsed,_,_) -> Assert.Equal(true, true)
    | ParserResult.Failure(error, _, _) -> Assert.Fail error

[<Theory>]
[<InlineData """tech_nanite_transmutation = {
	potential = {
		host_has_dlc = "Distant Stars Story Pack"
	}
}
""">]
[<InlineData """tech_arcane_deciphering = {
	weight_modifier = {
		modifier = {
			NOT = {
				has_resource = { type = minor_artifacts amount > 0 }
			}
		}
	}
}
""">]
[<InlineData """tech_eco_simulation = {
	weight_modifier = {
		modifier = {
			NOR = {
				has_country_flag = non_lithoid_subspecies
			}
		}
	}
}
""">]
let ``All property tech test`` (input: String) =
    let parsingResult = TechParser.getParsingResult input

    match parsingResult with
    | Result.Ok _ -> Assert.Equal(true, true)
    | Result.Error error -> Assert.Fail error

[<Theory>]
[<InlineData "has_resource = { type = minor_artifacts amount > 0 }">]
let ``objProperty test`` (input: String) =
    let parsingResult = run TechParser.objProperty input

    match parsingResult with
    | ParserResult.Success(parsed, _, _) -> Assert.Equal("ObjectProperty", parsed.GetType().Name)
    | ParserResult.Failure(error, _, _) -> Assert.Fail error
    
[<Fact>]
let ``tech test`` ()=
    let parsingResult = TechParser.getParsingResult TechTest.techRiftSphere

    match parsingResult with
    | Result.Ok result -> Assert.Equal(true, true)
    | Result.Error error -> Assert.Fail error
