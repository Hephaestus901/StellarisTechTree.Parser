namespace StellarisTechTree.Functional

open FParsec
open StellarisTechTree.Functional.Types

module Primitives =

    let private greaterSign: Parser<Condition, unit> =
        pstring ">" |>> Condition.GreaterThan

    let private lesserSign: Parser<Condition, unit> =
        pstring "<" |>> Condition.LesserThan

    let private lesserOrEqualsSign: Parser<Condition, unit> =
        pstring "<=" |>> Condition.LesserThenOrEqualsTo

    let private greaterOrEqualsSign: Parser<Condition, unit> =
        pstring ">=" |>> Condition.GreaterThanOrEqualsTo

    let internal conditionChar =
        choice [ lesserOrEqualsSign; greaterOrEqualsSign; lesserSign; greaterSign ]
    
    let internal ws: Parser<unit, unit> = skipChar ' '

    let internal quote: Parser<unit, unit> = skipChar '"'

    let internal equalsSign: Parser<unit, unit> = skipChar '='

    let internal openingBracketLiteral: Parser<unit, unit> = skipChar '{'

    let internal closingBracketLiteral: Parser<unit, unit> = skipChar '}'

    let internal colonChar: Parser<unit, unit> = skipChar ':'
