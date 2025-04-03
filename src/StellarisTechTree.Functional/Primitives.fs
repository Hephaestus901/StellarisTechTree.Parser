namespace StellarisTechTree.Functional

open FParsec
open StellarisTechTree.Functional.Types

module Primitives =
    let internal ws: Parser<unit, unit> = skipChar ' '
    
    let internal newLineLiteral: Parser<unit, unit> =
        skipNewline <|> followedByL eof "end of input"

    let internal spaceOrNewLine: Parser<unit, unit> = ws <|> newLineLiteral

    let internal equalsSign: Parser<unit, unit> = skipString "="

    let internal greaterSign: Parser<Condition, unit> =
        pstring ">" |>> Condition.GreaterThan

    let internal lesserSign: Parser<Condition, unit> =
        pstring "<" |>> Condition.LesserThan
        
    let internal lesserOrEqualsSign: Parser<Condition, unit> =
        pstring "<=" |>> Condition.LesserThenOrEqualsTo
        
    let internal greaterOrEqualsSign: Parser<Condition, unit> =
        pstring ">=" |>> Condition.GreaterThanOrEqualsTo

    let internal openingBracketLiteral: Parser<unit, unit> = skipChar '{' .>> spaces <|> spaceOrNewLine

    let internal closingBracketLiteral: Parser<unit, unit> = skipChar '}' .>> spaces <|> spaceOrNewLine

    let internal conditionChar = choice [ lesserOrEqualsSign; greaterOrEqualsSign; lesserSign; greaterSign; ]
    
    let internal colonChar: Parser<unit, unit> = skipString ":"
