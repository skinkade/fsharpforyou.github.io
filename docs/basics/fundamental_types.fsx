(**
---
title: Fundamental Types
category: Basics
categoryindex: 2
index: 2
---
*)

(**
# Fundamental Types
Every value in F# has a type. Types describe the kind of value something is and what we can do with it.

## Primitives Types
Primitive types are the most basic types in F# and they form the basis of nearly every program.

`int`: Represents numerical values from `-2,147,483,648` to `2,147,483,647`.  
`float`, `double`: Represents a 64-bit double-precision floating point number. Possible values range from: `-1.79769313486232e308` to `1.79769313486232e308`.    
`float32`, `single`: Represents a 32-bit single-precision floating point number. Possible values range from: `-3.402823e38` to `3.402823e38`.  
`bool`: Represents a `true` or `false` value.  
`char`: Represents a unicode character value.  
`string`: Represents a sequence of `char`s (unicode text).
*)

let integer = 1
let float = 1.0
let bool = true
let char = 'a'
let string = "abcdefg"
(*** include-fsi-output ***)

(**
## Tuples
Tuples are a finite ordered sequence of comma-separated values of differing types.
The length and types of a tuple are known at compile-time and are present in its type signature.
*)

let coordinates = (1.0, 2.0, 3.0)
(*** include-fsi-output ***)

(**
## Unit type
Since every expression in F# must yield or produce a value,
the unit type is used when no other value of interest exists.
The unit type only has a single value:
*)

()
(*** include-fsi-output ***)

(**
Oftentimes, functions that perform an operation and don't have a useful value to return will instead return a unit value. 
*)
printfn "Hello, World!"
(*** include-fsi-output ***)
