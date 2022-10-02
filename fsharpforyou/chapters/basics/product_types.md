# Product Types

Product types represent an aggregate or collection of values.
These come in two forms: tuples and records. A tuple represents an aggregate of unnamed values,
while a record represents an aggregate of named values.


Tuples are a finite ordered sequence of comma-separated values.

```fsharp
let coords = 3.0, 5.3, 2.5
```

The signature of `coords` is `float * float * float`.
The length and type of each position are known at compile time and appear in the signature.

We can deconstruct tuple values into their constituent types by using pattern matching.

```fsharp
let x, y, z = coords
// x: 3.0
// y: 5.3
// z: 2.5
```

We could give each of these values names by creating a record type.

```fsharp
type Coord = { X: float; Y: float; Z: int }
```

We can construct an instance of this record type by giving each member a value.

```fsharp
let coordinate = { X = 10.0; Y = 7.0; Z = 5.0 }
```

We can access individual members of a record by using dot notation.

```fsharp
let x = coordinate.X // 10.0
```

Records are immutable, their members can't be changed after creation.
However, we can create an instance of a new record by copying an existing one and partially updating its values.

```fsharp
let coordinates1 = { X = 10.0; Y = 7.0; Z = 5.0 }
let coordinates2 = { coordinates1 with X = 1.0 }
```

The only difference between these two record values is that one has an X value of `10.0`, and the other has an X value of `1.0`.

Anonymous records allow you to construct a record value without defining a new record type.
The syntax is the same as the above record construction syntax with additional vertical bars.

```fsharp
let johnDoe = {| FirstName = "John"; LastName = "Doe"; Age = 25 |}
let firstName = johnDoe.FirstName // "John"
```