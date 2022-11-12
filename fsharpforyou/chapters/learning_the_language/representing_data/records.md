# Records

Records represent an immutable aggregate or collection of named values.

```fsharp
type Person =
    { FirstName: string
      LastName: string
      Age: int }
```

We can define a record value, by supplying each named member with a value like so:

```fsharp
let person = { FirstName = "John"; LastName = "Doe"; Age = 25 }
```

Records are immutable. After a record value is constructed, we connot modifier its members.
Instead, we can update individual members of a record value using the _copy and update_ expression.

```fsharp
let person = { FirstName = "John"; LastName = "Doe"; Age = 25 }
let person2 = { person with Age = 21 }
```

These two record values have identical `FirstName` and `LastName` members as the `Age` member is the only one that got updated.

You can access record member values using dot notation.

```fsharp
let person = { FirstName = "John"; LastName = "Doe"; Age = 25 }
person.FirstName // "John"
```

Anonymous records allow you to define record values without creating an extra type.
These are often used as one-off values that don't need to be reused elsewhere.

```fsharp
let anonymousPerson = {| FullName = "John Doe"; CurrentActivity = "Being secretive" |}
//                    ^^                                                            ^^
//                     notice the vertical bars, which indicates an anonymous record.
```