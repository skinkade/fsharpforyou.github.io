(**
---
title: Types
category: Basics
categoryindex: 2
index: 2
---
*)

(**
# Types

## Primitives Types
``int``: Represents numerical values from ``-2,147,483,648`` to ``2,147,483,647``.  
``float``: Represents a floating point numerical value. Possible values range from: ``-1.79769313486232e308`` to ``1.79769313486232e308``.    
``bool``: Represents a ``True`` or ``false`` value.  
``char``: Represents a unicode character value.  
``string``: Represents a sequence of ``char``s (unicode text).
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
Since every expression in F# must evaluate to a value,
the unit type is used when no other value of interest exists.
The unit type only has a single value: ``()``
*)

()
(*** include-fsi-output ***)

(**
Often times, functions that perform an operation and don't have a useful value to return will instead return a unit value. 
*)
printfn "Hello, World!"
(*** include-fsi-output ***)

