(**
---
title: Conditionals
category: Basics
categoryindex: 2
index: 7
---
*)

(**
# Conditional Expressions
Conditional expressions are expressions that evaluate a boolean value (true or false)
and evaluate a branch of code if that condition yields a ``true`` value: ``if X do Y, else do Z``
*)

let outputAge age =
  if age >= 18 then printfn "You are an adult!"
  else printfn "You are not an adult!"

outputAge 23
outputAge 15
(*** include-output ***)

(**
All branches of a conditional expression must return values of the same type, which is inferred from the return value of the first branch (or optionally, the type annotation).
If the first branch returns a ``string`` value, the second branch cannot return a ``unit`` value as ``unit`` is not convertible to ``string``.
This code will result in a compiler error:
```fsharp
let outputAge' age =
  if age >= 18 then "Adult" // <- string value
  else () // <- unit value
```
*)
