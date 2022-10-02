# Conditional Expressions

Conditional expressions are expressions that evaluate a boolean expression.
If the boolean expression evaluates to true, the associated branch or block of code will be evaluated.

```fsharp
let age = 20

if age >= 18 then
    printfn "You are an adult!"
else
    printfn "You are not an adult!"
```

Because these are expressions, they will produce a value.
We can bind the result of the expression to a name using a `let binding`.

```fsharp
let age = 20
let output = if age >= 18 then "Adult" else "Minor"
```

All branches of a conditional expression must return values of the same type,
which is inferred from the return value of the first branch (or optionally, the type annotation).
If the first branch returns a string value, the second branch cannot return a unit value as a unit is not convertible to a string.

This code will result in a compiler error:

```fsharp
let age = 20

if age >= 18 then
    "Adult" // <- string value
else
    () // <- unit value
```