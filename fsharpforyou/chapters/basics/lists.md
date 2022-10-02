# Lists

Lists are an immutable series of elements implemented as a singly linked list.
We can define a list by surrounding a series of semicolon-separated values with square brackets.

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
```

You can append an element to the beginning of a list using the `::` operator.

```fsharp
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let numbers2 = 0 :: numbers
```

You can append a list to the beginning or end of another list by using the `@` operator.

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
```

Ranges can also contain a step amount, which indicates the number of steps per element.
The step is inserted between the start and end index.

```fsharp
let evenNumbers = [0..2..10]
```

We can match against the values of a list using pattern matching

```fsharp
let nums = [1; 2; 3; 4; 5]

match nums with
| [] -> printfn "List is empty"
| [1] -> printfn "List has a single element: 1"
| [1; 2; 3; 4; 5] -> printfn "List has 5 elements in ascending order"
```

You can also deconstruct the list into its head and tail elements using pattern matching.  
Given a list of `[1; 2; 3; 4; 5]` the head would be `1` and the tail would be `[2; 3; 4; 5]`.

```fsharp
let nums = [1; 2; 3; 4; 5]

match nums with
| [] -> printfn "List is empty"
| head :: tail -> printfn "head is %d, tail is %A" head tail
```

In this case, the second pattern would match any list with at least one element (the tail can be empty).
You could expand this pattern to include any number of elements before the tail.

```fsharp
match nums with
| [] ->
    printfn "List is empty"

| first :: second :: tail ->
    printfn "First is %d, Second is %d, Tail is %A" first second tail

| head :: tail ->
    printfn "head is %d, tail is %A" head tail
```