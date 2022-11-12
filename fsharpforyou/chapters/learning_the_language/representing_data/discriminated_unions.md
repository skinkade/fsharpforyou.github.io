# Discriminated Unions

A discriminated union represents a choice between one of many cases.
Each case can either have no data associated with it or data of differing types.

```fsharp
type ContactInformation =
    | None
    | EmailAddress of string
    | PhoneNumber of string
```

We can construct an instance of a union type by supplying the case, and optionally, the associated data.

```fsharp
let contactInfo = EmailAddress "johndoe@site.com"
```

The data associated with an individual case can optionally have a name.
This makes your intention clear to anyone reading your code.

```fsharp
type Shape =
    | Rectangle of width: int * height: int

let shape = Rectangle (width = 10, height = 20)
```

You can determine the identifier of a discriminated union value by using pattern matching.

```fsharp
let contactInfo = EmailAddress "johndoe@site.com"

match contactInfo with
| None -> printfn "No contact info found."
| EmailAddress value -> printfn "Sending an email to %s" value
| PhoneNumber value -> printfn "Sending a text message to %s" value
```