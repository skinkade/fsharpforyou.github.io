# Indentation Awareness

F# relies heavily on indentation levels to determine the start and end of an expression. 
A general rule of thumb is: be consistent with the level of indentation within a block.

For example, this code would compile as the indentation levels clearly indicate the beginning and end of the expression.

```fsharp
let ten =
    let five = 5
    five + five
```

However, this code wouldn't compile as the compiler can't determine the value of `ten` as the block isn't indented at all.

```fsharp
let ten =
let five = 5
five + five
```

This code also won't compile as the indentation levels are misaligned.

```fsharp
let ten =
    let five = 5
   five + five
```