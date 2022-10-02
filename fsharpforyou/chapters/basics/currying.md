# Currying

By default, functions in F# are curried. Every function has a single parameter and a single output.

Let's take a look at this function signature.
```fsharp
// int -> int
let addFive x = x + 5
```

This signature indicates that the function has a single int parameter and returns a single int value. The left-hand side of the `->` represents the input and the right-hand side represents the output.

Now let's take a look at the function signature of a "two parameter" function.

```fsharp
// int -> (int -> int)
let add x y = x + y
```

This signature indicates that the function has a single int parameter, and returns a new function with the signature of `int -> int`

Functions with "multiple parameters" are instead single parameter functions that return new functions.