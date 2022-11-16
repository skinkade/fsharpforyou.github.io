# Top-down Evaluation

F# code is evaluated top-down which has some interesting side effects.
You can only call functions and reference bindings or types that are defined above the current definition.

```fsharp
add 1 3 // compiler error: The value or constructor 'add' is not defined.

let add x y = x + y // `add` is defined below its usage, which isn't valid.
```

The advantage of top-down evaluation is that the flow of your application's code is easier to reason about.
Code is read and evaluated from top to bottom in a sequential manner.
We can clearly understand and reason about our dependent types and functions.

This top-down evaluation also applies to the ordering of files within a project.
You can only use functions, types, and modules defined in other files if the file is ordered above the current definition. 