# Sequence expressions

List comprehension allows you to dynamically build lists using loops and conditional expressions.
Every element produced from this loop will be present in the resulting list.

```fsharp
let list = [ for i in 0..10 -> i * 2 ]
// [ 0; 2; 4; 6; 8; 10; 12; 14; 16; 18; 20 ]
```

Unlike normal for expressions, those present in a list comprehension produce values that will be present in the resulting list.

List comprehensions can also contain conditional expressions.
These expressions can produce values present in the resulting list.

```fsharp
let value = 10
let list = [ if value % 2 = 0 then "Even" else "Odd" ]
```

Unlike traditional `if` expressions the ones present in a list comprehension don't need additional branches such as `else if` or `else`.

```fsharp
let value = 10
let list = [ if value % 2 = 0 then "Even" ]
```

You can mix and match normal elements that will always be present in the list with `if` and `for` expressions.

```fsharp
let value = 10

let list = [
    "Hello, World!"
    if value % 2 = 0 then "Value is even"
    for i in 0..10 do string i
]
```

The resulting list will consist of `"Hello World"`, `"Value is even"` and `0..10` as strings.
Please note that you can't use the `for i in elems -> ...` syntax here as that would ignore the 2 previous expressions.