# Anonymous Functions

Anonymous functions allow you to define functions without explicitly defining them.
This is often used in conjunction with higher-order functions, to pass a function as a value to another function.

```fsharp
let output (f: string -> unit) = f "Hello, World!"

output (fun value -> printfn "Value is %s" value)
```
