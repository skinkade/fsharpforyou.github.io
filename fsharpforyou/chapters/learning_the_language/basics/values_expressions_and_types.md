# Values, Expressions, and Types

Let's start by understanding one of the most fundamental concepts in F#. Values and expressions.

```fsharp
5 + 5
```

This is an expression. But what does that mean?
An expression is simply, a block of code that produces a value.
Unlike some other languages, everything in F# is an expression, and therefore, produces a value.

The expression `5 + 5` will evaluate to a value of `10`.
This value has a type of `int`. 

Types denote the _type_ of a value and what operations we can perform on it.
For instance, you can add two numbers together, but you can't add a non-number to a number.

These expressions can be organized into blocks. The last expression in a block of code is what produces a value for the block as a whole. An example of a block (which isn't valid F# code) is:

```fsharp
twenty =
// beginning of a block
    ten = 10
    ten + ten // <- yields a value
// end of a block
```

The fundamental types used in most F# programs are `int`, `float`, `bool`, `char`, `string`, and `unit`.
These types are called primitives, as they are basic data types that contain simple values and are the foundation for other, more complex types.

What do these primitive types represent?  
`int` represents a 32-bit numerical value.  
`float` represents a 64-bit double-precision floating-point numerical value.  
`char` represents a Unicode character value.  
`string` represents a sequence of `char` values.  
`bool` represents a `true` or `false` value, often used in conditional logic.

```fsharp
10              // int
10.0            // float
'a'             // char
"Hello, World!" // string
true            // bool
```