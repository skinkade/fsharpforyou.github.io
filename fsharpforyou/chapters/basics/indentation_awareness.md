# Indentation Awareness

Unlike some other languages, F# uses indentation to determine the beginning and end of a block. Expressions and types require consistent indentation for your program to compile.

For example, this code would compile as the expression is indented and the indentation levels are consistent.

```fsharp
let ten =
    let five = 5
    five + five
```

This code, however, wouldn't compile as the compiler can't determine the value of `ten`.

```fsharp
let ten =
let five = 5
five + five
```