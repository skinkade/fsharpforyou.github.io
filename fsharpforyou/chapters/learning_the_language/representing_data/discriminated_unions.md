# Discriminated Unions

A discriminated union represents a choice between one of many cases.
Each case can either have no data associated with it or a single parameter.

```fsharp
type ContactInformation =
    | NotPresent
    | EmailAddress of string // <- the email value
    | PhoneNumber of string // <- the phone number value
```

We can construct an instance of a union type by supplying the case and the associated data (if present).

```fsharp
let contactInfo = NotPresent
let emailContact = EmailAddress "email@provider.com"
let phoneContact = PhoneNumber "000-000-0000"
```

You may notice that the construction of the `EmailAddress` and `PhoneNumber` cases look incredibly similar to function calls. That's because they are! If we don't supply any data to the `EmailAddress` case, you can see that it's actually a function that takes a `string` input and returns a `ContactInformation` value.

```fsharp
let emailAddress = EmailAddress
// emailAddress = string -> ContactInformation

let contactInfo = emailAddress "email@provider.com"
// contactInfo = EmailAddress "email@provider.com"
```

Individual union cases can only have a single type of value associated with them. You can use tuple types or record types to represent an aggregate or combination of data for a specific union case.

```fsharp
type Shape =
    | Square of int
    | Rectangle of int * int

let square = Square 15
let rectangle = Rectangle (10, 20)
```

Although this is valid F# code, it's not entirely clear what properties the values of this tuple represent. Which value is the length or height of the rectangle? Often, it's best to introduce a record type instead of a tuple.

```fsharp
type Square = { Size: int }
type Rectangle = { Length: int; Width: int }

type Shape =
    | Square of Square
    | Rectangle of Rectangle

let square = Square { Size = 10 }
let rectangle = Rectangle { Length = 15; Width = 20 }
```

Like records, discriminated unions are immutable and compared by value. If you compare two instances of a union type, if they have the same case and equal associated data, they are equal.

```fsharp
let email1 = EmailAddress "email@provider.com"
let email2 = EmailAddress "email@provider.com"
email1 = email2 // result: true
//     ^
// are they equal?
```