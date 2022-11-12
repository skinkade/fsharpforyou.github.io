# Active Patterns

Active patterns allows us to define reusable patterns that decompose and deconstruct data in various ways.
These can later be used in match expressions, functions, or bindings like any other patterns.

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
Here we will define an active pattern to deconstruct a color into it's ARGB (alpha, red, green, blue) values.

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