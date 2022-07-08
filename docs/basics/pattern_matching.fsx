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
Pattern matching allows us to decompose and deconstruct types such as Unions, Records, and Tuples based on their shape and values using patterns,
which act as rules for their transformation. Let's start with tuple patterns so we could start to understand this concept and why it's so powerful.

Let's start by decomposing a coordinate tuple into its respective ``x, y, z`` bindings.
*)

let coordinate = 3, 5, 1
let x, y, z = coordinate
(*** include-fsi-output ***)

(**
Because the signature of ``coordinate`` is ``int * int * int`` the pattern ``x, y, z``
defines individual bindings for each position of the tuple.
The first tuple element will be deconstructed into ``x``, the second into ``y``, and the third into ``z`` because of their positions in the pattern.

To expand on this coordinate example, we can create a discriminated union
that represents a choice between a two-dimensional or three-dimensional coordinate value.

```fsharp
type Coordinate =
    | Coord2d of int * int
    | Coord3d of int * int * int
```

Now that we've done this, how could we determine whether a coordinate value is either two-dimensional or three-dimensional?
We could utilize a match expression to do this. A match expression will allow us to define multiple patterns which will
be evaluated against the value in order. Once a pattern is matched, the expression associated with that match arm will be evaluated.
*)

type Coordinate =
    | Coord2d of int * int
    | Coord3d of int * int * int

let details coord =
    match coord with
    | Coord2d (x, y) -> printfn $"two-dimensional coordinate value. X: {x}, Y: {y}"
    | Coord3d (x, y, z) -> printfn $"three-dimensional coordinate value. X: {x}, Y: {y}, Z: {z}"

let coord2d = Coord2d(5, 10)
let coord3d = Coord3d(1, 5, 10)

details coord2d
details coord3d
(*** include-output ***)

(**
As you can see from the above example, we can define multiple match arms each with their own pattern.
We match against a Discriminated Union by matching against the choice, and optionally, the data associated with it.
Because we're simply deconstructing the data, the arm will always be matched against if the choice is correct.

However, we can define multiple patterns for a single choice, by additionally matching against the data associated with it.
*)
let zero coordinates =
    match coordinates with
    // if the identifier is Coord2 and the tuple is (0, 0)
    | Coord2d (0, 0) -> true
    // if the identifier is Coord3 and the tuple is (0, 0, 0)
    | Coord3d (0, 0, 0) -> true
    | Coord2d (x, y) -> false
    | Coord3d (x, y, z) -> false
(**
Here, instead of just defining a pattern that matches a discriminated union's identifier,
we can match against a discriminated union's identifier AND the value associated with it.
If the choice is ``Coord2d`` and the tuple value is ``0.0, 0.0`` then the first arm will be matched against... and so on.
This is called a ``constant`` pattern. Where we match a value against a constant value (constant values are: strings, numerical values, and enumerations).
Example: Matching a value of type ``int * int * int`` against a constant pattern of ``(0, 1, 2)``
If each tuple value is equal to the corresponding constant value in the same position, the pattern will be matched.

Match expressions need to be exhaustive, which means that every possible pattern needs to be accounted for. We'll get a compiler warning otherwise.
In some cases, this can be tedious (or impossible). Often times we only want to match against a few patterns and discard the rest.
We can do this using the wildcard pattern, identified by an underscore as shown below:
*)

let zero' coordinates =
    match coordinates with
    | Coord2d (0, 0) -> true
    | Coord3d (0, 0, 0) -> true
    | Coord2d _ -> false // effectively ignores the data associated with this DU identifier
    | Coord3d _ -> false // effectively ignores the data associated with this DU identifier

(**
As you can see from the above example, we don't necessarily care about the data associated with the identifier in the last two cases, so we just ignore it.

However, this code can still be improved, the first two and the last two patterns evaluate to the same value.
``if the first OR second pattern matches then ...`` and ``if the third OR fourth pattern matches then ...``.
We could simplify this code by using the OR pattern like so:
*)
let zero'' coordinates =
    match coordinates with
    | Coord2d (0, 0)
    | Coord3d (0, 0, 0) -> true
    | Coord2d _
    | Coord3d _ -> false

(**
As you can see from the above example, we can define one resulting expression for multiple patterns.
If any of the patterns match against the value, then that shared expression will be evaluated.

Sometimes, we just want to deal with the value directly in a match arm. We could do this using the variable pattern.
The variable pattern creates a binding from the value we're matching against to a specific name.
You can also use the variable pattern in conjunction with a ``when`` expression for conditional logic.
*)

let matchValue value =
    match value with
    | value when value > 5 -> $"{value} is greater than 5"
    | value -> sprintf $"Value is {value}"

let matchWithTen = matchValue 10
let matchWithTwo = matchValue 2
(*** include-fsi-output ***)

(**
We can decompose records and match against their values using a record pattern.
*)
type Coords = { X: int; Y: int; Z: int }

let matchCoords coords =
    match coords with
    | { X = 0; Y = 0; Z = 0 } -> printfn "X, Y, and Z are all 0"
    | { X = x; Y = y; Z = z } -> printfn $"X: {x}, Y: {y}, Z: {z}"

matchCoords { X = 0; Y = 0; Z = 0 }
matchCoords { X = 10; Y = 20; Z = 30 }
(*** include-output ***)

(**
As you can see from the above example,
the pattern ``{ X = 0; Y = 0; Z = 0 }`` will match against any record definition with the corresponding values and
the pattern ``{ X = x; Y = y; Z = z }`` will deconstruct the record values into individual bindings.

We can decompose a list using the list pattern like so:
*)

let outputList list =
    match list with
    | [ 1 ] -> printfn "Single value: 1"
    | [ 1; 2 ] -> printfn "Two values: 1 and 2"
    | [ 1; 2; 3 ] -> printfn "Three values: 1, 2, and 3"
    | [ x; y; z ] -> printfn $"Three values: {x}, {y}, and {z}"

outputList [1]
outputList [1; 2]
outputList [1; 2; 3]
outputList [0; 10; 20]
(*** include-output ***)

(**
You can use the CONS pattern (``::``) to deconstruct a list into its head and tail values like so:
*)
let outputList' list =
    match list with
    | [] -> printfn "List is empty."
    | head :: tail -> printfn $"Head: {head}, Tail: %A{tail}"

outputList' []
outputList' [1]
outputList' [1;2;3;4;5]
(*** include-output ***)

(**
As you can see from the above example, if there is a single element present in the list
the first element will be assigned to the name ``head``, and the tail of the list (the elements other then the head) will
be assigned to the name ``tail``.

This pattern can be extended by using ``first :: second :: tail``
which will match any list that has 2 of more elements.
*)
let outputList'' list =
    match list with
    | [] -> printfn "List is empty."
    | first :: second :: tail -> printfn $"First: {first}, Second: {second}, Tail: %A{tail}"
    | head :: tail -> printfn $"Head: {head}, Tail: %A{tail}"

outputList'' [1]
outputList'' [1;2]
(*** include-output ***)

(**
This pattern can be extended to match a list with any number of elements like so:
``first :: second :: third :: fourth :: tail`` and so on...
*)