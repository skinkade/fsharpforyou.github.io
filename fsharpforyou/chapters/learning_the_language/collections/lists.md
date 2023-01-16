# Lists

Lists are an immutable series of elements implemented as a singly linked list.
We can define a list by surrounding a series of semicolon-separated values with square brackets.

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
```

Because lists are immutable, we can't change the contents of an existing list.
However, we can copy the contents of a list and update it using operators or functions. The result would be a new list with the appropriate changes.

To add an element to the beginning of a list, we can use the CONS operator (`::`).

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let numbers2 = 0 :: numbers
// numbers2 = [0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
//             ^
//             0 is prepended
```

You can combine two lists into one using the `@` operator.

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let numbers2 = numbers @ [11; 12; 13; 14; 15]
// numbers2 = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15]
// the two lists are combined into one.
```

You can access individual elements of a list using its indexer. In F#, lists are indexed by zero, which means the first element in a list has an index of 0, the second has an index of 1, and so on...

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let first = numbers[0] // <- get element at index 0
// first = 1
```

We can produce a list from `a` to `b` using the range operator. If we wanted to produce a sequence of values from `1` to `10` we could use the range `1..10`.

```fsharp
let oneThroughTen = [1..10]
// oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
```

Ranges can also contain a step amount inserted between the start and end index,
which indicates the number of steps per element. The default step is `1` which indicates a single step from one element to the next, ex: `0` to `1`. If we used a step of `2` it would be `0` to `2` instead.

```fsharp
let evenNumbers = [0..2..10]
// [0; 2; 4; 6; 8; 10]
```

The `List` module contains useful functions for working with lists.

These functions include:  
`map` to apply a mapping or transformation function to each element, returning a new list.  
`filter` to filter the elements of a list using a predicate (a function returning a boolean value), returning a new list.  
`iter` to apply a function (must return unit) to each element.

These functions accept other functions, passed as values, that operate on each element of a list, transforming or using it in some way.

```fsharp
let double x = x * 2
let nums = [0..3]
let doubledNums = List.map double nums // [0; 1; 2; 3] -> [0; 2; 4; 6]
//                         ^^^^^^ the transformation function
// each element of the list is doubled.

let isEven x = x % 2 = 0 
//             ^^^^^^^^^ this returns a boolean value

let nums = [0..3]
let evenNums = List.filter isEven nums // [0; 1; 2; 3] -> [0; 2]
//                         ^^^^^^ the predicate or filtering function.
// only even numbers are returned.

let nums = [0..3]
let printNum x = printfn $"Number is: {x}"
//               ^^^^^^^^^^^^^^^^^^^^^^^^^ important: this returns a unit value
List.iter printNum nums
//        ^^^^^^^^ the function to apply to each element.
// output:
// Number is: 0
// Number is: 1
// Number is: 2
// Number is: 3
// each element is printed to the console (standard output).
```

The `List` module contains [many](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html) functions all with similar signatures and effects to the ones listed above.