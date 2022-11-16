# Higher Order Functions

Higher-order functions allow you to define a function as a value.
This is useful if you want to pass functions to other functions as parameters.

```fsharp
let output (f: string -> unit) = f "Hello, World!"

output (printfn "%s")
```

Because `printfn %s` has a signature of `string -> unit`, it can be passed as a parameter to the output function.
The output function would then call that passed-in function with a parameter of `"Hello World"`.

A higher-order function defines a contract that can be fulfilled by any function with matching signatures.
This may be useful when you want to swap out the implementation details of a function with another at runtime.
Instead of printing to the console, I could instead write to a file, or a cache, or send an HTTP request, etc ... 
All without having to worry about the specific implementation details of the passed-in function.