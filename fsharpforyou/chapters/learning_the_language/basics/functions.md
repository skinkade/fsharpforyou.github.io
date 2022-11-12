# Functions

Functions are the primary unit of execution of any program.
Functions have a very similar syntax to let bindings, unlike let bindings, functions are evaluated once per call.

You can define function parameters one after another separated by a space. These parameters will be passed into the function when it's called.

```fsharp
let add x y = x + y
let ten = add 5 5
```

The types will be inferred from the first call. Initially, the `add` function will have a signature of `int -> int -> int`.
This is because the compiler sees that as a sane default.

If you initially call the function with float values, the type inference will then change to infer `float -> float -> float`.
Any subsequent call would require float parameters.

You can override the type inference by supplying type annotations for one or more parameters.

```fsharp
let add (x: float) (y: float) = x + y
let ten = add 5.0 5.0 // ten: float
```
