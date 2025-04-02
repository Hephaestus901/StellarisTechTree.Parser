namespace StellarisTechTree.Functional

module Types =
    type public Condition =
        | GreaterThan of string
        | LesserThan of string
        | GreaterThanOrEqualsTo of string
        | LesserThenOrEqualsTo of string

    type public Name = string

    type public Comparator = string * Condition

    type public Identifier =
        | NameIdentifier of Name
        | ComparatorIdentifier of Comparator

    type public TypeValue =
        | BooleanValue of bool
        | StringValue of string
        | Variable of string
        | IntValue of int32
        | FloatValue of float
    
    type public Property =
        | SingleProperty of Identifier * TypeValue
        | ArrayProperty of Name * TypeValue list
        | ObjectProperty of Name * Property list
        | EmptyObject of Name
        
    type public LocaleValue =
        | StringValue of string
    
    type public LocaleObject =
        | SingleProperty of Name * LocaleValue
        
    type public VariableValue = float
        
    type VariableObject = Name * VariableValue

    let private getNameFromIdentifier (id: Identifier) =
        match id with
        | NameIdentifier name -> Name name
        | ComparatorIdentifier(name, _) -> Name name

    type Identifier with
        member x.getName() = getNameFromIdentifier x
