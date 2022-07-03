(**
---
title: Creating Types
category: Basics
categoryindex: 2
index: 6
---
*)

(**
# Creating Types
In F#, you can create your own types. These include: type aliases, records, and discriminated unions.

## Type Aliases
Type aliases allow you to create aliases for existing types.
*)

type EmailAddress = string

(**
Because ``EmailAddress`` is an alias for ``string``, for all intents and purposes an ``EmailAddress`` is just a ``string``, and can be used as such.
*)
let emailAddressString: string = "johndoe@email.com"
let emailAddressAliased: EmailAddress = "johndoe@gmail.com"
(*** include-fsi-output ***)

(**
## Record Types
Record types represent an immutable collection of named values.
*)
type Person =
    { FirstName: string
      LastName: string
      Age: int }

(**
You can define records in multiple ways, for instance... another common syntax for record definition is a single-line definition with semicolon-separated members.
(Semicolons can be used in any record definition, but they're only required for record definition if the members aren't on separate lines)
*)
type Person' = { FirstName: string; LastName: string; Age: int }

(**
You can construct a record value by giving each member of your desired record a value.
The type of the record is inferred from the members. As F# is evaluated top-down,
the compiler will infer the record type by using the record with matching members closest to the value declaration (if no type annotation is present).
*)

type Customer =
    { Username: string
      EmailAddress: string
      FullName: string }
    
 let johnDoe =
    { Username = "john_doe"
      EmailAddress = "johndoe@site.com"
      FullName = "John Doe" }
(*** include-fsi-output ***)

(**
Records are immutable, which means their state can never be changed after a value is created.
You can copy the contents of a record, change individual members, and get a new value using the _copy and update_ expression.
*)
type Coords =
    { X: int
      Y: int
      Z: int }
    
let coords = { X = 10; Y = 20; Z = 30 }
let updatedCoords = { coords with X = 0 }

printfn "Coords: %O" coords
printfn "Updated coords: %O" updatedCoords
(*** include-output ***)

(**
As you can see, ``updatedCoords`` and ``coords`` have the same ``Y`` and ``Z`` values.
However, the ``X`` value is different as that's the only value we changed in the _copy and update_ expression.

You can access individual members on a value using the dot operator as such:
*)
let xValue = updatedCoords.X
(*** include-value: xValue ***)

(**
Because F# is evaluated top-down, types can't normally reference each other.
However, you can define mutually recursive record types (records that reference each other) like so:
*)
type Occupant =
  { FirstName: string
    LastName: string
    Address: Address }
and Address =
  { State: string
    City: string
    StreetAddress: string
    ZipCode: string
    Occupant: Occupant }
(*** include-fsi-output ***)

(**
## Discriminated Unions
Discriminated unions represent a choice between a number of named cases, optionally with additional data.
*)
type Suit =
  | Heart
  | Diamond
  | Club
  | Spade

let suit = Heart
(*** include-fsi-output ***)

(**
You can define a choice's associated data by using ``of`` followed by the value's type.
Individual cases can have different types of data associated with them, or no data at all.
*)
type ContactInformation =
  | EmailAddress of string
  | PhoneNumber of string

let contactInfo = EmailAddress "johndoe@email.com"
(*** include-fsi-output ***)
