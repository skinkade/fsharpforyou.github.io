# Currying

By default, functions in F# are curried. Every function has a single parameter and a single output.

Let's take a look at this function signature.
```fsharp
// int -> int
let addFive x = x + 5
```

The left-hand side of the `->` represents the input and the right-hand side represents the output.
This signature indicates that the function has a single int value as input and a single int value as output.

Let's take a look at another function signature.

```fsharp
// int -> int -> int
let add x y = x + y
```

This signature indicates that the function has a single int parameter as input, and returns a new function with the signature of `int -> int`.
Functions with "multiple parameters" are instead single parameter functions that return new functions.

To demonstrate currying, we can _partially apply_ a single parameter to the `add` function.
The type of the resulting value will be `int -> int`, indicating that a new function has been produced.

```fsharp
let add x y = x + y
let addFive = add 5 // int -> int
```

This technique allows us to build up new functions by partially applying parameters to existing ones.