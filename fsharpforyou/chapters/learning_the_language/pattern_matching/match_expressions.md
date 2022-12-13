# Match Expressions

Match expressions allow you to define a sequential set of patterns to be evaluated one by one against a value until a match is found.

```fsharp
let number = 5

let output =
    match number with
    | 10 -> "ten" 
    | 15 -> "fifteen"
    | num -> $"Number is {num}"

printfn $"Output: {output}" // "Output: Number is 5"
```

Let's break this down.
1. If the value is `10` yield `ten`.
2. Otherwise, if the value is `15` yield `fifteen`.
3. Otherwise, bind the value to the name `num` and yield `Number is {num}`.

In the above match expression, we are utilizing two different patterns. One is the constant pattern that evaluates a value against a constant (an int, string, bool, char, ...). The other is the variable pattern that binds the value to a name. The two constant patterns are conditional, they will only match a specific subset of integers, while the variable pattern will always match against a value. 

This is important because match expressions have to be exhaustive. Every possible pattern needs to be present for a given value. However, this can be tedious or impractical when using conditional patterns. Instead, you can use patterns like the variable and wildcard pattern which will always match a value.

```fsharp
let number = 5

let output =
    match number with
    | 10 -> "ten"
    | 15 -> "fifteen"
    | _ -> "the value was discarded"
//    ^ the wildcard pattern
//    will match against and discard the value

printfn $"Output: {output}" // "Output: the value was discarded"
```

This match expression is exhaustive as the wildcard pattern acts as a _catch-all_ if the two previous patterns aren't matched.

Let's revisit the tuple pattern from the previous page and introduce the constant pattern to create a function that outputs a string based on X, Y, and Z, coordinate values.

```fsharp
let describe coords =
    match coords with
    | (0, 0, 0) -> "Coordinates are all zero"
    | (x, y, z) -> $"X: {x}, Y: {y}, Z: {z}"

describe (0, 0, 0) // "Coordinates are all zero"
describe (1, 2, 3) // "X: 1, Y: 2, Z: 3"
```

Here, we use the tuple pattern to supply a pattern for each value by its position, utilizing both the constant and variable patterns for each value. This is an example of pattern matching and patterns in action.

You can specify guards in branches by using `when ...`, we can combine this with the variable pattern to have conditional logic in a match expression.

```fsharp
let fizzBuzz number =
    match number with
    | number when number % 15 = 0 -> "FizzBuzz"
    | number when number % 3 = 0 -> "Fizz"
    | number when number % 5 = 0 -> "Buzz"
    | number -> string number

fizzBuzz 30 // "FizzBuzz"
fizzBuzz 7 // "7"
```

In some cases, you'd want to match a value against multiple patterns. You can do this with the AND pattern using `pattern1 & pattern2`, which acts as pattern composition, forming a new pattern that will match against a value if all patterns match.

```fsharp
let describe coords =
    match coords with
    | (0, 0, 0) & (x, y, z) -> "Zeros"
    | (x, y, z) -> $"X: {x}, Y: {y}, Z: {z}"

describe (0, 0, 5) // "X and Y: 0, Z: 5"
describe (1, 2, 3) // "X: 1, Y: 2, Z: 3"
```

In some cases, you'd want to evaluate the same block of code if one of many patterns match a given value. You can do this with the OR pattern by simply adding an additional branch instead of producing a value with `-> expr`.

```fsharp
let describe number =
    match number with
    | 1
    | 2
    | 3 -> "Number is either: 1, 2, or 3"
    | number -> $"Number is: {number}"
```