(**
---
title: Piping and Composition
category: Basics
categoryindex: 2
index: 9
---
*)


(**
## Piping
Piping allows you to pass values into a function's or union's parameter and return the result.
This is often used when you're piping multiple functions and their results into each other.

Passing a value of ``10`` into a function like so:
```fsharp
function 10
```

Is equivalent to piping the value into the function like so:
```fsharp
10
|> function
```
As you can see, we're passing the value ``10`` into a single parameter function and producing the result.
Because of this, combining the pipe operator with a partially applied function is incredibly useful.

```fsharp
let add x y = x + y

10
|> add 5 // partially applying `5`
|> add 7 // partially applying `7`
|> add 9 // partially applying `9`
```

This is incredibly beneficial when you're dealing with "long" function chains like so:
```fsharp
let f x = ...
let g x = ...
let m x = ...

let a = f 10
let b = g a
let c = m b
```

Using the pipe operator, the above example would be:
```fsharp
let f x = ...
let g x = ...
let m x = ...

10
|> f
|> g
|> m
```

A more practical example of the pipe operator would be passing an initial list through multiple List module functions in succession.
*)
let double x = x * 2
let isEven x = x % 2 = 0

[0..20]
|> List.map double // double every number
|> List.filter isEven // only even numbers
|> List.sortDescending // sort from high to low
(*** include-it ***)

(**
We can add or remove steps from the above pipeline by inserting or removing a pipe.
This allows us to construct elegant and concise workflows and easily reason about them.

## Function Composition

You can compose multiple functions together using the ``>>`` operator.
This allows you to evaluate the left-hand function and pass the result into the right-hand function.
The output type of the left-hand function must be the input type of the right-hand function, for example: ``A -> B`` and ``B -> C``.
This is very similar to piping, but instead of piping values into functions, we are building up new functions by combining smaller ones.
*)
let addFive x = x + 5
let multiplyTwo x = x * 2
let addFiveMultiplyTwo = addFive >> multiplyTwo

let twenty = addFiveMultiplyTwo 5
(*** include-fsi-output ***)

(**
You can chain these together to create new functions by composing (or combining) many smaller functions together.
*)
let addTwo x = x + 2
let multiplyFive x = x * 5
let divideThree x = x / 3
let subtractFour x = x - 4
let operation = addTwo >> multiplyFive >> divideThree >> subtractFour

let sixteen = operation 10
(*** include-fsi-output ***)