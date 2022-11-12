# Partial application

To demonstrate the use of curried functions, we can _partially apply_ a single parameter to the `add` function.
The type of the resulting value will be `int -> int`, indicating that a new function has been produced.

```fsharp
let add x y = x + y // int -> int -> int
let addFive = add 5 // int -> int
let ten = addFive 10
```

This technique allows us to build up new functions by partially applying parameters to existing ones.