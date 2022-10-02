# Higher Order Functions

Higher-order functions allow you to define a function as a value.
This is useful if you want to pass functions to other functions as parameters.

```fsharp
let output (f: string -> unit) = f "Hello, World!"

output (printfn "%s")
```

Because `printfn %s` has a signature of `string -> unit`, it can be passed as a parameter to the output function.
The output function would then call that passed-in function with a parameter of `"Hello World"`.

This technique allows you to dynamically call a function with the desired value.
This function can be replaced to perform differing operations.
I can pass in a function to print to the console, output to a file, or any other desired operation.