# The Record Pattern

The record pattern allows you to define a pattern for some or all values of a record.

```fsharp
type Person =
    { FirstName: string
      LastName: string
      Age: int }

let describe person =
    match person with
    | { FirstName = "John"; LastName = "Doe" } -> "Is a John Doe"
    | { Age = 18 } -> "Is eighteen years old"
    | _ -> "Unknown description"
```

The above expression utilizes the record, constant, and wildcard patterns. The above code checks for equality between a subset of record values and constants.

To demonstrate this, we can use the tuple and variable patterns from before alongside the record pattern.

```fsharp
type Person =
    { Name: string * string
      Age: int }

let describe person =
    match person with
    | { Name = (firstName, lastName); Age = 18 } ->
        $"{firstName} {lastName} is 18"

    | _ -> "Unknown description"
```