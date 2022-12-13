# Active Patterns

Active patterns allow us to define reusable patterns that decompose and deconstruct data in various ways.
These can later be used in match expressions, functions, or bindings like any other pattern.

Here we will define a pattern an active pattern with two options: `IsAdult` or `IsNotAdult`.
We can then utilize these patterns in a match expression.

```fsharp
type Person =
    { FirstName: string
      LastName: string
      Age: int }

let (|IsAdult|IsNotAdult|) person =
    if person.Age >= 18 then IsAdult else IsNotAdult

let person = { FirstName = "John"; LastName = "Doe"; Age = 21 }

match person with
| IsAdult -> printfn "Is an adult"
| IsNotAdult -> printfn "Is not an adult"
```

We can also use active patterns to deconstruct values.
Here we will define an active pattern to deconstruct a color into its ARGB (alpha, red, green, blue) values.

```fsharp
open System.Drawing

let (|ARGB|) (color: Color) =
    color.A, color.R, color.G, color.B

let color = Color.Red
let (ARGB (a, r, g, b)) = color

printfn $"A: {a}, R: {r}, G: {g}, B: {b}"
```

There may be instances where a pattern will optionally deconstruct or decompose a value (they may or may not match against a value).
We can use partial active patterns to accomplish this.

```fsharp
// |_| denotes a partial active pattern.
let (|IsAdult|_|) person =
    if person.Age >= 18 
    then Some IsAdult
    else None

let output person =
    match person with
    | IsAdult -> "Is an adult"
    | _ -> "Is not an adult"
```

Parameterized active patterns allow you to pass a parameter to an active pattern while matching against it. In this case, you're partially applying the active pattern function and the value being matched against is the single parameter that's left.

```fsharp
let (|IsMultipleOf|_|) number value =
    if value % number = 0 then Some IsMultipleOf else None

// If the number is divisible by 3 output "Fizz"
// If the number is divisible by 5 output "Buzz"
// If the number is divisible by both output "FizzBuzz"
// otherwise, output the number as a string.
let fizzBuzz number =
    match number with
    | IsMultipleOf 3 & IsMultipleOf 5 -> "FizzBuzz"
    | IsMultipleOf 3 -> "Fizz"
    | IsMultipleOf 5 -> "Buzz"
    | number -> string 
```