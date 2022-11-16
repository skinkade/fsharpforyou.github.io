# Lists

Lists are an immutable series of elements implemented as a singly linked list.
We can define a list by surrounding a series of semicolon-separated values with square brackets.

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
```

You can prepend an element to the beginning of a list using the `::` operator.

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let numbers2 = 0 :: numbers
// numbers2 = [0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
```

You can combine two lists using the `@` operator.

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let numbers2 = numbers @ [11; 12; 13; 14; 15]
```

You can access individual elements of a list by their index. Like most languages, F# is indexed by 0.
The first element is 0, the second is 1, the third is 2, and so on...

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let first = numbers[0]
```

We can use ranges in lists to produce elements from a start and end point.

```fsharp
let oneThroughTen = [1..10]
// [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
```

Ranges can also contain a step amount inserted between the start and end index,
which indicates the number of steps per element.

```fsharp
let evenNumbers = [0..2..10]
// [0; 2; 4; 6; 8; 10]
```

The `List` module contains useful functions for working with lists.

These functions include:  
`map` to apply a mapping or transformation function to each element, returning a new list.  
`filter` to filter the elements of a list using a predicate (a function returning a boolean value), returning a new list.  
`iter` to apply a function (must return unit) to each element

```fsharp
let double x = x * 2
let nums = [0..10]
let doubledNums = List.map double nums
//                         ^^^^^^ the transformation function

let isEven x = x % 2 = 0 
//             ^^^^^^^^^ this returns a boolean value

let nums = [0..10]
let evenNums = List.filter isEven nums
//                         ^^^^^^ the predicate or filtering function.

let nums = [0..10]
let printNum x = printfn $"Number is: {x}"
//               ^^^^^^^^^^^^^^^^^^^^^^^^^ important: this returns a unit value
List.iter printNum nums
//        ^^^^^^^^ the function to apply to each element.
```

The `List` module contains **many** functions all with similar signatures and effects to the ones listed above.