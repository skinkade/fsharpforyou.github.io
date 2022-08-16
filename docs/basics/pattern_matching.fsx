(**
---
title: Pattern Matching
category: Basics
categoryindex: 2
index: 8
---
*)

(**
# Pattern matching

Pattern matching allows us to decompose or deconstruct values using patterns, which act as rules for their transformation.
Pattern matching is used primarily in three ways: function arguments, let bindings, and match expressions.

With pattern matching we can:

 1. Bind values to names.
 2. Evaluate values against constants.
 3. Deconstruct and decompose the values of tuples, records, discriminated unions, tuples, and more. 

Here we can decompose a tuple into its constituent bindings using the tuple and variable patterns. 
*)

let coordinates = (0.0, 5.0, 10.0)
let (x, y, z) = coordinates
(*** include-fsi-output ***)

(**
What's going on here?

 1. The tuple pattern allows us to define a pattern for each value of a tuple by its position.
 2. The variable pattern binds values to names.

By combining the tuple and variable pattern we can bind each value of a tuple, by its position, to a name.

This is not a conditional pattern, the variable pattern will always match against a value.
We may want to define a set of patterns to conditionally match against a value.
We can do this with a match expression.

```fsharp
match value with
| pattern1 -> expression1
| pattern2 -> expression2
| pattern3 -> expression3
```

Each pattern is sequentially evaluated against the value.
Once the first match is found the match arm will evaluate the corresponding expression and produce a value.

A match expression must be exhaustive, which means every possible pattern for a given value needs to be accounted for.
In some cases, this may be tedious or even impossible to do.
We can utilize the wildcard pattern which will always match and discard the value.

```fsharp
match value with
| _ -> expression
```

We can combine a pattern with a conditional expression using `when`.
If the pattern matches and the conditional expression evaluates to true,
the corresponding match arm will be evaluated.

```fsharp
match value with
| pattern1 when ... -> expression1
```

This is often used in conjunction with the variable pattern.
The newly bound value will be used in the conditional expression as shown below:

```fsharp
let number = 10

match number with
| value when value > 100 -> ...
| value when value > 50 -> ...
| value -> ...
```

The constant pattern will match a value against a constant value (character, string, number, or enumeration).
If the constant value is equal to the value we're testing it against, then the match arm will be evaluated.

```fsharp
match number with
| 10 -> ...
| 20 -> ...
| 30 -> ...
*)

type ContactInformation =
    | None
    | EmailAddress of string
    | PhoneNumber of string

let contact (contactInfo: ContactInformation) =
    match contactInfo with
    | None -> "No contact info"
    | EmailAddress emailAddress -> $"Sending an email to {emailAddress}"
    | PhoneNumber phoneNumber -> $"Sending a text message to {phoneNumber}"

(***)

let none = None
contact none
(*** include-it ***)

let email = EmailAddress "johndoe@site.com"
contact email
(*** include-it ***)

let phone = PhoneNumber "000-123-4567"
contact phone
(*** include-it ***)

(**
The AND pattern allows us to specify multiple patterns in a single arm that will only be evaluated if every pattern matches against the value.

```fsharp
match value with
| pattern1 & pattern2 & pattern3 -> ...
| pattern1 & pattern2 -> ...
```

The OR pattern allows us to specify a single expression for multiple match arms.

```fsharp
match value with
| pattern1
| pattern2 -> ...
```

The list pattern allows us to decompose the values of a list by supplying patterns for each element.
Here we will decompose a list using the variable pattern, a constant pattern, and the wildcard pattern.
```fsharp
match value with
| [first; 2; _] -> ...
```

We can also decompose a list into its head and tail values using the CONS pattern.
If we have a list value of `[1; 2; 3; 4; 5]` the head value would be `1` and the tail value would be `[2; 3; 4; 5]`.
*)

let value = [1; 2; 3; 4; 5]

match value with
| [] -> "Empty list."
| head::tail -> $"Head: {head}, Tail: {tail}"
(*** include-it ***)

(**
Patterns could also be used in let bindings and function arguments.
These patterns must be exhaustive, which means it must match all possible values of a given type.
If we wanted to extract the value of a single-case union without matching against the value we could utilize this.
This works because the union only has a single identifier to match against and the variable pattern will always match against a value.

```fsharp
type PositiveInteger = PositiveInteger of int

// A let binding that utilizes pattern matching
let (PositiveInteger intValue) = positiveInt

// A function argument that utilizes pattern matching
let extractIntValue (PositiveInteger intValue) = intValue
```

If the pattern isn't exhaustive then it wouldn't work.
This could not be substituted by a list patternbecause a list could be empty or have any number of elements.
*)