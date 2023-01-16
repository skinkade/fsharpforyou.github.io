# Top-down Evaluation

F# code is evaluated top-down which has some interesting side effects.
You can only call functions and reference bindings or types that are defined above the current definition.

```fsharp
add 1 3
let add x y = x + y
// `add` is defined below the above call site
// which results in a compiler error
```

The advantage of top-down evaluation is that the flow of your application's code is easier to reason about.
Code is read and evaluated from top to bottom in a sequential manner.
We can clearly understand and reason about our dependent types and functions.

This top-down evaluation also applies to the ordering of files within a project.
You can only use functions, types, and modules defined in other files if the file is ordered above the current definition. 

```
1. Logic.fs
2. Program.fs
```

Here, any code in `Program.fs` can access modules, types, functions, and bindings in `Logic.fs`, but not the other way around. This is because `Logic.fs` is ordered above `Program.fs`. 
