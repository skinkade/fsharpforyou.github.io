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
Pattern matching allows us to match against or decompose values using patterns, which act as rules for their transformation.
Pattern matching is used primarily in three ways: function arguments, let bindings, and match expressions.
All of these constructs allow you to define patterns that can decompose or deconstruct a value.

Let's start with two simple patterns: The tuple and variable patterns.
*)

let coordinates = (1.0, 2.0, 3.0)
let (x, y, z) = coordinates
(*** include-fsi-output ***)

(**
The tuple pattern allows us to define a pattern for each position of a tuple value
and the variable pattern allows us to bind values to names.
We can combine these two patterns to extract a tuple with three values into three respective bindings as demonstrated in the above example.

This is not a conditional pattern, the variable pattern will always match against a value.
We may want to define a set of patterns to conditionally match against a value.
We can do this with a match expression.

Here we will demonstrate a match expression with the identifier pattern,
which allows us to match against a discriminated union's identifier.
*)

type Suit =
    | Heart
    | Diamond
    | Club
    | Spade

let suit = Heart

match suit with
| Heart -> "Heart"
| Diamond -> "Diamond"
| Club -> "Club"
| Spade -> "Spade"
(*** include-it ***)

(**
Match expressions allow us to sequentially define patterns that will be checked against the value one by one until a match is
found. If a pattern is matched against a value, the corresponding arm will be evaluated and a value will be produced.

Match expressions need to be exhaustive, which means every potential pattern needs to be accounted for.
In some cases, this can be cumbersome or tedious. However, a wildcard pattern `_` can be used which matches any given value and discards it.
*)

match suit with
| Heart -> "Heart"
| Diamond -> "Diamond"
| _ -> "Neither heart nor diamond"

(**
What about discriminated union identifiers that have associated values?
We could also use a pattern for those too!
*)

type ContactInformation =
    | EmailAddress of string
    | PhoneNumber of string

let contact contactInformation =
    match contactInformation with
    | EmailAddress emailAddress ->
        $"Sending an email to {emailAddress}"
    | PhoneNumber phoneNumber ->
        $"Sending a text message to {phoneNumber}"

let contactInfo = EmailAddress "johndoe@site.com"
contact contactInfo
(*** include-it ***)

(**
Here we utilize the identifier pattern and the variable pattern.
We bind the identifier's associated value to a name and use it in the return value.

We may want a pattern to conditionally match a value, for instance: Matching a DU's identifier and its value.
There are many ways to do this. One way is to match a value against a constant value.
*)

type Coordinate =
    | TwoDimensional of float * float
    | ThreeDimensional of float * float * float

let plot coordinate =
    match coordinate with
    | TwoDimensional (0.0, 0.0) -> "Zero"
    | ThreeDimensional (0.0, 0.0, 0.0) -> "Zero"
    | TwoDimensional (x, y) -> $"X: {x}, Y: {y}"
    | ThreeDimensional (x, y, z) -> $"X: {x}, Y: {y}, Z: {z}"

(***)

let coordinate1 = TwoDimensional (0.0, 0.0)
plot coordinate1
(*** include-it ***)

let coordinate2 = TwoDimensional (5.0, 3.0)
plot coordinate2
(*** include-it ***)

(**
As shown above, the constant pattern allows you to match a value against constants (numerical, character, string literal, and enum values)

The value associated with a single-case discriminated union can be deconstructed into a binding using the variable pattern.
A match expression isn't required as the union only has a single case and the variable pattern will always match against a value.
*)

type String50 = String50 of string

let string50 = String50 "Hello, World!"
let (String50 value) = string50
(*** include-fsi-output ***)

(**
Sometimes, you may want to use the variable pattern in conjunction with a conditional expression.
We can do this with `when`
*)

let number = 50

match number with
| number when number >= 100 -> "value >= 100"
| number when number >= 10 -> "value >= 10"
| number -> "value = 10"

(*** include-it ***)

(**
As you can see, we bind `number` to a new name, shadowing the original, and utilize a conditional expression.
If the expression produces a boolean value of `true`, the match arm will produce a value.
*)