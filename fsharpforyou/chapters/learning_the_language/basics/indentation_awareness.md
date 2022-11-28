# Indentation Awareness

F# relies on the level of indentation to discern the beginning and end of an expression.

```fsharp
let addTen num =
    let ten = 10 // <---
    ten + num    // <---
                 // this block has consistent indentation levels.

let result =
    addTen 5 // 15
```

Here, the compiler can discern the beginning and end of the `addTen` function and `result` let binding. Both are indented consistently with 4 spaces and are terminated by the subsequent non-indented expression. A general rule of thumb is: to be consistent with the level of indentation in a block. Inconsistent indentation levels in a block will result in a compiler error.

```fsharp
let addTen num =
    let ten = 10
   ten + num
// ^^^^^^^^^
// inconsistent indentation in the function body.
```

Because the last expression of a block acts as the return value, the compiler will see that the `addTen` function isn't a completed block as it can't discern the return value.
