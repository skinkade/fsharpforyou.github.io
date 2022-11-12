# Operators

Operators are special functions that can be applied to several types.
Unlike other functions, operators can be infixed (placed between two parameters).

We'll be covering basic operators including arithmetic and boolean comparison operators.

The arithmetic operators include: `+`, `-`, `/`, `*`, `%`, `**`.

```fsharp
let ten = 5 + 5 // add two numbers.
let four = 8 - 4 // subtract two numbers.
let five = 10 / 2 // divide two numbers.
let twenty = 10 * 2 // multiply two numbers.
let remainder = 10 % 2 // remainder after division.
let squared = 10 ** 2 // 10 to the power of 2
```

The comparison operators include: `=`, `<>`, `>`, `<`, `>=`, `<=`.
These operators compare two values and return a boolean result, `true` or `false`.

```fsharp
let equals = 5 = 5 // is 5 equal to 5?
let notEquals = 5 <> 5 // is 5 not equal to 5?
let greaterThan = 5 > 5 // is 5 greater than 5?
let lessThan = 5 < 5 // is 5 less than 5?
let greaterThanOrEqualTo = 5 >= 5 // is 5 greater than or equal to 5
let lessThanOrEqualTo = 5 <= 5 // is 5 less than or equal to 5
```

You can define operator functions by surrounding the operator symbols with parenthesis.
Valid operator symbols include: `!`, `$`, `%`, `&`, `*`, `+`, `-`, `.`, `/`, `<`, `=`, `>`, `?`, `@`, `^`, `|`.

```fsharp
let (++) word1 word2 = sprintf "%s %s" word1 word2
"Hello" ++ "World" // "Hello World"
```

Because operators are simply functions. They can also be called like other functions.
Take the `+` operator for example:

```fsharp
let result = (+) 5 10 // equivalent to: 5 + 10
```