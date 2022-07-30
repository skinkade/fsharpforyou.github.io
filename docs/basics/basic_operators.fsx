(**
---
title: Basic Operators
category: Basics
categoryindex: 2
index: 3
---
*)

(**
# Operators
Operators are special functions that take one or more values and yield another value.

### Arithmetic Operators:
Arithmetic operators are concerned with mathematical operations such as `add`, `subtract`, `multiply`, `divide`,
and yield the result of such operations.  
`+`: add two numbers  
`-`: subtract two numbers  
`*`: multiply two numbers  
`/`: divide two numbers  
`**`: power  
`%`: modulo (remainder after the division of two numbers)  
*)
let addition = 5 + 2 // 5 plus 2
let subtraction = 5 - 2 // 5 minus 2
let multiplication = 5 * 2 // 5 times 2
let division = 5 / 2 // 5 divided by 2
let modulo = 5 % 2 // the remainder of 5 divided by 2
let exponent = 5.0 ** 2.0 // 5 to the power of 2
(*** include-fsi-output ***)

(**
### Logical operators:
Logical operators perform comparison operations on two values and yield boolean (true or false) values.
Example: `is ... equal to ...` or `is ... greater then ...`  

`=`: equality  
`<>`: inequality  
`<`: less than  
`>`: greater than  
`<=`: less than or equal to  
`>=`: greater than or equal to  
`&&`: logical OR  
`||`: logical AND  
`not`: logical NOT, negates a boolean value.  
*)
let equals = 5 = 5 // is 5 equal to 5
let notEquals = 5 <> 5 // is 5 NOT equal to 5
let lessThan = 5 < 5 // is 5 less than 5
let greaterThan = 5 > 5 // is 5 greater than 5
let lessThanOrEqualTo = 5 <= 5 // is 5 less than or equal to 5
let greaterThanOrEqualTo = 5 >= 5 // is 5 greater than or equal to 5
let logicalAnd = 5 = 5 && 6 = 6 // is 5 equal to 5 AND 6 equal to 6
let logicalOr = 5 = 5 || 6 = 7 // is 5 equal to 5 OR six equal to 7
let falseValue = not (true) // true -> false
let trueValue = not (false) // false -> true
(*** include-fsi-output ***)
