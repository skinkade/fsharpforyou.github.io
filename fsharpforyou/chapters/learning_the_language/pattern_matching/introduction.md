# An Intro to Pattern Matching

Pattern matching allows us to decompose and/or deconstruct values using patterns, which act as rules for their transformation.

```fsharp
let coords = (1.0, 2.0, 3.0)  // float * float * float
//            ^^^  ^^^  ^^^
//             x    y    z

let (x, y, z) = coords
// x = 1.0
// y = 2.0
// z = 3.0
```

Here, we deconstruct a tuple value containing x, y, and z coordinate values into their respective bindings.  This is utilizing the tuple and variable patterns. The tuple pattern allows us to specify a pattern for each element of the tuple by its position and the variable pattern binds a value to a name (similar to a let binding).

By combining these two patterns, we can create bindings for each element of a tuple like so:

```fsharp
let (firstName, lastName, age) = "John", "Doe", 25
// firstName = "John"
// lastName = "Doe"
// age = 25
```

This not only works for let bindings but also function arguments and `for..in` expressions.

```fsharp
let printCoordinate (x, y, z) =
//                  ^^^^^^^^^
//                  tuple and variable pattern.
    printfn $"X: {x}, Y: {y}, Z: {z}"

let printAllCoordinates coords =
    for (x, y, z) in coords do
//      ^^^^^^^^^
//      tuple and variable pattern.
        printfn $"X: {x}, Y: {y}, Z: {z}"

printCoordinate (1, 2, 3)
printAllCoordinates [(1, 2, 3); (4, 5, 6)]
```

This however does not work with all patterns. Patterns in let bindings, function arguments, and `for..in` expressions must be exhaustive. This means all possible values need to be accounted for by the pattern. In the case of the variable and tuple pattern, it will always match against the value and can therefore be used in these cases.