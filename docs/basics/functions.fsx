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
Notice than in F# function parameters are seperated by whitespace instead of commas.
*)

(**
Optionally, you can add type annotations to a function parameter by surrounding the parameter with parenthesis and annotating it with the desired type.
The type annotation preceding the ``=`` is the return type of the function.
*)
let divide (left: int) (right: int) : int = left / right
let four = divide 8 2
(*** include-fsi-output ***)

(**
Some functions won't take in a specific parameter but instead will have a unit parameter.
This acts as a zero parameter function.
*)

let getInt () = 30
let thirty = getInt ()
(*** include-fsi-output ***)

(**
## Currying and Function signatures
In F#, all functions are curried.
This means that every function has a single parameter.
What about ``let add x y = ...``, doesn't that have two parameters? 
If we look at this function's signature, we could figure out what exactly is going on.
*)
let addNumbers x y = x + y
(*** include-fsi-output ***)

(**
As you can see from the above example, the function signature is ``int -> int -> int``.
What does this mean? A function with the signature of ``int -> int`` means the function has a single ``int`` parameter
and returns an ``int`` value. The signature ``int -> int -> int`` means the function has a single ``int`` parameter, and returns
another function with the signature of ``int -> int``. Functions with "multiple parameters" are instead functions with a single parameter
that return other functions.

We can see this by passing one argument to the ``addNumbers`` function.
*)
let addFive = addNumbers 5
(*** include-fsi-output ***)

(**
This is called partial application.
We can partially fill in parameters to a function and get a new function where only the remaining parameters need to be filled in.
This allows us to build new reusable functions from existing functions as shown above.
*)
let fifty = addFive 45
(*** include-fsi-output ***)

(**
## Passing functions around
Higher order functions are functions that accept functions as parameters or return functions.
This can be very useful for abstracting away the implementation of a function (dynamic implementation).

Here we will define a function named ``outputParameter`` that will accept another function as a parameter.
*)
let outputNumber (output: int -> unit) = output 10 

(**
Because ``printfn "%d"`` returns a function with the signature of ``int -> unit``, we can pass it to the ``outputNumber`` function.
*)
let printNumber = printfn "%d"
outputNumber printNumber
(*** include-fsi-merged-output ***)

(**
## Anonymous functions
Anonymous functions aka lambda expressions are a way to define functions without explicitly naming them.
This is often used in conjunction with higher-order functions (when passing functions as arguments to other functions).
*)

outputNumber (fun number -> printfn "%d" number)
(*** include-output ***)
