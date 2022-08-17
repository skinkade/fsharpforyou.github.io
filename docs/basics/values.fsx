(**
---
title: Values and expressions
category: Basics
categoryindex: 2
index: 1
---
*)

(**
# Values and expressions
In this chapter, we'll be going over expressions and values in F#.

What exactly is an expression?
An expression is a block or unit of code that produces a value.

Let's take a quick look at this expression:
*)

5 + 5
(*** include-fsi-output ***)

(**
Let's break that down:

 1. `5 + 5` is an expression.
 2. The expression evaluates to `10`
 3. The value has the type of `int`

What does this mean?

 -   F# is an expression-based language which means that everything produces a value.

 -   F# is a statically typed language which means that every value has a single type
     that can't be changed after initialization.

## Let bindings
We can reuse the results of expressions by giving them names.
These are called `let bindings`.
*)

let ten = 5 + 5
(*** include-fsi-output ***)

(**
From left to right, this reads as:
`let` the name `ten` be assigned to the result of the expression `5 + 5`.

The expression `5 + 5` yields a value with the type of `int`.
Types describe the kind of value something is and what we can do with it.
Don't worry about them right now, we'll cover this later.

Expressions can span multiple lines, but the last line of an expression always yields the result (produces the value). 

As you may have noticed, we didn't have to specify the value's type.
F# has strong type inference which means that values usually don’t require type annotations.
Although, type annotations are needed if the compiler can't figure out the type for a value,
or you want to override the compiler’s type inference.

You can specify type annotations by using a colon followed by the value's type like so:
*)

let five: float = 5
(*** include-fsi-output ***)

(**
By default let bindings are immutable which means their values can’t be changed after we create them.
F# does support mutable let bindings, but we have to explicitly declare that a binding is mutable using the `mutable`
keyword and mutate it using the `<-` operator.
*)

let mutable result = 1 + 1
result <- 4
(*** include-value: result ***)

(**
## Static typing
As noted above, F# is a statically typed language which means that every value has a single type and we are unable to change that type after initialization.
This allows us to write code with confidence as every value's type is checked at compile time and is guaranteed to be correct or our application won't compile.

Because the value of `result` has the type of `int`, we cannot change the binding to a value with the type of `string`.
This code will result in a compiler error:
```fsharp
let mutable result = 1 + 1
result <- "Hello"
```
```text
This expression was expected to have type
    'int'
but here has type
    'string'
```

## Indentation Awareness
F# relies on the level of indentation to determine the beginning and the end of an expression.
Consistency is key, once a new indentation offset is created, every following expression in the current body must be aligned with that offset.
*)

let twenty =
    let ten = 10
    ten + ten
(*** include-fsi-output ***)

(**
This code will result in a compiler error:
```fsharp
let twenty =
    let ten = 10
        ten + ten
```
```text
Incomplete value or function definition.
If this is in an expression, the body of the expression must be indented to the same column as the 'let' keyword.
```
*)