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
In F#, you model data by creating types that represent combinations of smaller types.
These include type abbreviations, records, and discriminated unions.

## Type abbreviations
Type abbreviations represent an alias (alternate name) or abbreviation for an existing type.
*)
type Number = int

(**
Because `Number` is an abbreviation for `int`, for all intents and purposes `Number` is an `int`, and can be used as such.
*)
let number: Number = 10

(**
Type abbreviations serve multiple purposes, but most importantly, they are documentation and give meaning to types that don't have a meaning of their own.

One common use for abbreviations is passing around function signatures with names.
Here we give the function signature `string -> unit` a descriptive name to be used as a type annotation.
*)

type Output = string -> unit
let output: Output = printfn "%s"
output "Hello, World!"
(*** include-output ***)

(**
Another common use for type abbreviations is to shorten longer types.
Here we shorten a list of a list that represents a 2d grid.
We may not want to type out `list<list<int>>` or we may want to give it
a more descriptive name.
*)
type Grid = list<list<int>>
let grid: Grid = [ [1; 2; 3]; [4; 5; 6] ]
(*** include-fsi-output ***)

(**
## Records
A record represents an immutable container for named values.
*)

type Person =
    { FirstName: string
      LastName: string
      Age: int }

(**
This reads as:  
the type `Person` has  
a `FirstName` value with a type of `string` AND  
a `LastName` value with a type of `string` AND  
an `Age` value with a type of `int`  

Notice the emphasis on AND? This is because record types are also called AND types.
Why? Because a record is an aggregate (or a collection) of named values and every value must be accounted for
during construction.

You can define records in multiple ways. Another common syntax for record definition is a single-line definition with semicolon-separated properties.
Semicolons can be used in any record definition, but they're only required for record definition if the properties aren't on separate lines.

```fsharp
type Person = { FirstName: string; LastName: string; Age: int }
```

You can construct a record type by giving each member a value. The type of the record is inferred from the members.
As F# is evaluated top-down, the compiler will infer the record type by using the record with matching properties closest to the value declaration (if no type annotation is present).
*)

let john = { FirstName = "John"; LastName = "Doe"; Age = 21 }

(**
You can access individual members of a record using the dot operator.
*)

john.FirstName
(*** include-it ***)

(**
As records are immutable, we cannot modify a member's value after creation.
We can see this by trying to mutate a record's member value.

```fsharp
john.FirstName <- "Not John"
```

This results in a compiler error:
```text
This field is not mutable
```

If you wanted to slightly change a record value, it can be quite cumbersome to individually copy
the contents of one record into another. Thankfully, there's a shortcut for this. 
Using the copy and update expression, we can modify individual values of an existing record, and produce
a new record with the appropriate changes.
*)
{ john with FirstName = "Jane" }
(*** include-it ***)

(**
As you can see from the above example, the `LastName` and `Age` members of the `john` value are the same.
The only difference is the `FirstName` value. What happened to the original value? It remains unchanged.
Instead, we produced a new value reflecting our changes.
*)

john
(*** include-it ***)

(**
As F# is evaluated top-down, types normally can't be mutually recursive, which means they can't have references to each other.
You have to use a special syntax to do this.
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
A discriminated union represents a choice between any number of cases with optional data.
*)

type Suit =
    | Heart
    | Diamond
    | Club
    | Spade

(**
This reads as: the type `Suit` can either be a `Heart` OR `Diamond` OR `Club` OR  `Spade`.
Notice the emphasis on OR? This is because discriminated unions are also called or/choice types.
As they represent a choice between one of many values.

You can create an instance of a discriminated union by using choosing an identifier or case like so:
*)

let suit = Heart
(*** include-fsi-output ***)

(**
Individual cases can have different types of data associated with them or no data at all.
You can define the data associated with a case by using `of` followed by the type like so:
*)
type ContactInformation =
    | None
    | EmailAddress of string
    | PhoneNumber of string

(**
You can construct a discriminated union case that has data associated with it like so:
*)

EmailAddress "johndoe@site.com"
(*** include-fsi-output ***)

(**
That looks awfully like a function call doesn't it? That's because it is!
*)

EmailAddress
(*** include-fsi-output ***)

(**
The data associated with cases can also have named values.
These values can offer a descriptive name for otherwise an arbitrary type.
*)

type Shape =
    | Rectangle of width: int * height: int
    | Circle of radius: int

(**
When you construct an instance of `Shape` you can supply named parameters like so:
*)
let shape = Rectangle (width = 10, height = 20)

(**
These aren't required but they can add clarity and documentation to your code when it otherwise wouldn't exist.
Take for example:
*)
let rectangle = Rectangle (10, 20)

(**
Which value represents the width and which one represents the height? is it the first one or the second one?
If you're unsure or forget, you'd have to look at the type definition to refresh your memory.
This can be a hassle as you probably won't remember what the values represent in all of your discriminated unions 
unless you create individual bindings for them. You shouldn't rely solely upon your memory because you'll often forget
and other people who are reading your code won't have the same luxury, they simply wouldn't know without knowledge of your intention.

Sometimes, you may want to define a single-case discriminated union. There's a shortcut for this:
*)

type A = B
(*** include-fsi-output ***)

(**
This may look like a type alias at first, but its not. 
Whats the difference? If `B` was a defined type, then this would be an alias.
Since it's not a type, its a single-case discriminated union.
*)

type String50 = String50 of string

(**
Why would you want to create a discriminated union with a single case?
It's better to represent simple or primitive types such as `string` in a more specific or explicit manner.
Why? Because `string` doesn't actually mean anything, it can be any value whatsoever (that's a string).
We create a `String50` type here which represents a wrapped string value with a max length of 50.
This constraint can't exist on any string value because `string` is arbitrary, it can be empty, not empty, and have any length.
*)

