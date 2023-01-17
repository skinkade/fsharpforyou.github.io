# Conditional Expressions

Conditional expressions are expressions that evaluate a boolean value.
If the boolean expression evaluates to a `true` value, the associated branch or block of code will be evaluated.

```fsharp
let age = 20

if age >= 18 then
    printfn "You are an adult!"
else
    printfn "You are not an adult!"
```

Because `if` expressions yield values, we can bind the result of the expression to a name using a `let binding`.

```fsharp
let age = 20
let output = if age >= 18 then "Adult" else "Minor"
```

All branches of a conditional expression must return values of the same type,
which is inferred from the return value of the first branch (or optionally, the type annotation of the binding/function).
If the first branch returns a string value, the second branch cannot return a unit value as a unit is not convertible to a string.

This code will result in a compiler error:

```fsharp
let age = 20

if age >= 18 then
    "Adult" // <- string value
else
    () // <- unit value
```
