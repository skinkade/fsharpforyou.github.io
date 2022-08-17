(**
---
title: Functions
category: Basics
categoryindex: 2
index: 4
---
*)

(**
# Functions
Functions are the primary unit of execution of any program.
They serve as named bindings from a set of parameters to a value.
Unlike let bindings, functions are evaluated once per call.
You can define function parameters one after another separated by a space.
These parameters will be passed into the function when it's called by the consumer.
*)
let double x = x * 2
let add x y = x + y
let multiply x y = x * y
let addToTuple (x, y) z = (x + z, y + z)

let ten = double 5
let fifteen = add 10 5
let twenty = multiply 10 2
let twoAndThree = addToTuple (1,2) 1
(*** include-fsi-output ***)

(**
Notice that in F#, function parameters are separated by whitespace instead of commas.
*)

(**
Optionally, you can add type annotations to a function parameter by surrounding the parameter with parenthesis and annotating it with the desired type.
The type annotation preceding the `=` is the return type of the function.
*)
let divide (left: int) (right: int) : int = left / right
let four = divide 8 2
(*** include-fsi-output ***)

(**
Some functions won't take in a specific parameter but instead will have a unit parameter.
This acts as a zero-parameter function.
*)

let getInt () = 30
let thirty = getInt ()
(*** include-fsi-output ***)

(**
## Currying and Function signatures
In F# all functions are curried.
Which means all multi-parameter functions are instead, single-parameter functions that return other functions.
Let's take a look at this function signature to understand what's going on.
*)

let addFive number = number + 5
(*** include-fsi-output ***)

(**
The function signature of `int -> int` indicates that a function accepts a single `int` parameter, and returns an `int` value.
Now, let's take a look at the function signature of a multi-parameter function.
*)

let addNums x y = x + y
(*** include-fsi-output ***)

(**
The function signature of `int -> int -> int` indicates that a function accepts a single `int` parameter, and returns a new function with the signature of `int -> int`.
Because of this, we can partially fill in parameters to a function and get back a new function with only the remaining parameters left.
This is called partial application and is incredibly beneficial, allowing us to build new reusable functions from existing ones.
*)
let multiplyNums x y = x * y
let doubleNum = multiplyNums 2
doubleNum 10
(*** include-fsi-output ***)

(**
## Functions as values
Higher order functions are functions that accept functions as parameters or return functions.
This can be very useful for abstracting away the implementation of a function (dynamic implementation).

Here we will define a function named `outputNumber` that will accept another function as a parameter.
*)
let outputNumber (output: int -> unit) = output 10 

(**
Because `printfn "%d"` returns a function with the signature of `int -> unit`, we can pass it to the `outputNumber` function.
*)
let printNumber = printfn "%d"
outputNumber printNumber
(*** include-fsi-merged-output ***)

(**
## Anonymous functions
Anonymous functions aka lambda expressions are a way to define functions without explicitly naming them.
This is often used in conjunction with higher-order functions (when passing functions as arguments to other functions).
*)
let output (output: string -> unit) = output "Hello, World!" 
output (fun value -> printfn "%s" value)
(*** include-output ***)

(**
## Operator functions
You can create custom operators using operator functions by surrounding the operator symbols with parenthesis.  
Valid operator symbols include: `! $ % & * + - . / < = > ? @ ^ |`
*)

let (++) left right = $"{left} {right}"

"Hello" ++ "World"
(*** include-it ***)

(**
The above operator is in `infix` form which means the operator gets placed between the two arguments.  
You can create a unary operator, which is placed before a single parameter, by prefixing the operator symbols with `~`. 
*)

let (~+.) number = number * number + number

+.2.0
(*** include-it ***)
