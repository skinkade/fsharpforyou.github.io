# Tuples

Tuples are a finite ordered sequence of comma-separated values of differing types.
The length and types of a tuple are known at compile-time and are present in its type signature.

```fsharp
let coords = 10.0, 2.0, 5.0 // float * float * float
```

Tuples represent an aggregate of unnamed values.
If you wanted to represent a person, which contains a `firstName`, `lastName`, and `age`, you could do so with a tuple value.

```fsharp
let person = "John", "Doe", 25
//           ^^^^^   ^^^^   ^^
//           first   last   age
```
