# Functions

Functions are the primary unit of execution of any program.
Functions act as a black box of transformation: you give a function an input and it's transformed into an output. An example of this would be a `double` function that transforms `2` into `4`, `4` into `8`, `8` into `16`, and so on.

You can define functions by using the `let` syntax and defining a name and a list of parameters one after another separated by a space.
These parameters will be passed into the function when it's called.

```fsharp
let add x y = x + y
let ten = add 5 5
```

When you define a function, the compiler will infer the types of parameters and the output.
Functions have type signatures, which indicate the types of their inputs and output.
For instance, a function named `double` which takes a number and returns another number will have the signature `int -> int`.

The `add` function will have an initial signature of `int -> int -> int`. However, once you call the function the compiler may adjust its type inference like so:

```fsharp
let add x y = x + y
// add = int -> int -> int

let helloWorld = add "Hello" "World"
// type inference has changed after this call.
// add = string -> string -> string
```

You can override the compiler's type inference by supplying type annotations for one or more parameters. This can be used for clarity or as a corrective action, in situations where the compiler gets it wrong.

```fsharp
let add (x: float) (y: float) = x + y // float -> float -> float
let ten = add 5.0 5.0 // ten: float
```
