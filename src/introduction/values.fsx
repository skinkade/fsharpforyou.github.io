(**
---
title: Values and expressions
category: Introduction
categoryindex: 1
index: 2
---
*)

(**
# Values and expressions
In this chapter, we'll be going over expressions and values in F#.
Let's take a quick look at this expression:
*)

5 + 5;;
(*** include-it ***)

(**
Let's break that down:
1. ``5 + 5`` is an expression.
2. The expression evaluates to ``10``
3. The value has the type of ``int``
What does this mean?
* F# is an expression-based language which means that _everything is a value_.
This differs from languages like C# and Java which make a distinction between expressions (yielding values)
and statements (commands or units of execution).
* F# is a statically typed language which means that every value has a single type that is
enforced at compile time.

We can assign values to names using let bindings:
*)

let ten = 5 + 5;;
(*** include-it ***)

(**
From left to right, this reads as:
``let`` the name ``ten`` be assigned to the result of the expression ``5 + 5``.

As you may have noticed, the binding's type is inferred by the compiler.
F# has strong type inference which means that values usually don’t require type annotations.
Sometimes type annotations are needed if the compiler can't figure out the type for a specific value,
or you want to override the compiler’s type inference.

You can specify type annotations by using a colon followed by the value's type like so:
*)
let five: int = 5
(*** include-it ***)


(**
By default let bindings are immutable which means their values can’t be changed after initialization.
F# does support mutable let bindings, but we have to explicitly declare that a binding is mutable.
We can declare a let binding as mutable using the ``mutable`` keyword:
*)

let mutable two = 1 + 1;;
(*** include-it ***)

(**
Since this binding is explicitly declared as mutable, we can then mutate its value using the ← operator:
*)
two <- 2

(**
As previously stated, F# is a statically typed language with strong type safety.
If we try to change the value of a binding after initialization, we’ll get a compiler error.
Because `two` is declared as an `int` value, we cannot change the binding to a value with the type of `string`.

This code will result in a compiler error:
```fsharp
two <- "Hello"
```
```
error FS0001: This expression was expected to have type
    'int'
but here has type
    'string'
```
*)
