# Partial Application

Because F# functions are curried, this allows us to take advantage of a useful technique called "partial application".
Partial application takes advantage of curried functions by partially applying parameters to a function and getting a new function back.

```fsharp
let add x y = x + y
let addFive = add 5
```

This technique allows us to build new functions by partially applying parameters to existing ones.