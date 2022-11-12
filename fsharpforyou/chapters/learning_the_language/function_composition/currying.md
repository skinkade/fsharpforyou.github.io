# Currying

By default, functions in F# are curried. Every function has a single parameter and a single output.

Let's take a look at this function signature.

```fsharp
// int -> int
let addFive x = x + 5
```

The left-hand side of the `->` represents the input and the right-hand side represents the output.
This signature indicates that the function has a single int value as an input and a single int value as an output.

Let's take a look at another function signature.

```fsharp
// int -> int -> int
let add x y = x + y
```

This signature indicates that the function has a single int parameter as input, and returns a new function with the signature of `int -> int`.
Functions with "multiple parameters" are instead single parameter functions that return a series of _other_ single parameter functions.