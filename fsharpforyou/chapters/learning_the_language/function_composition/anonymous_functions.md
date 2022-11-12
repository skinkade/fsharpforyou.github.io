# Anonymous Functions

Anonymous functions allow you to define functions without explicitly naming them.

```fsharp
let output (f: string -> unit) = f "Hello, World!"

output (fun value -> printfn "Value is %s" value)
```

These are often used in conjunction with higher-order functions.
Serving as one-off functions that may have no other use but as a parameter to another function.