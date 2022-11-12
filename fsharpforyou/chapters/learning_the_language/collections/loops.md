# Loops

Loops allow you to enumerate a sequence of elements, and perform a specific action with every element in the sequence.

```fsharp
let nums = [1; 2; 3; 4; 5]

for elem in nums do
    printfn $"{elem}"
```

The for expression accepts a pattern for each element in the sequence.
In this instance we're supplying `elem`, utilizing the variable pattern, which binds a value to a name.
If we wanted to deconstruct a value, we could supply an alternative pattern.
Here we will demonstrate this with a list of tuple values.

```fsharp
let coords = [ (1, 2); (3, 4); (5, 6) ]

for (x, y) in coords do
    printfn $"X: {x}, Y: {y}"
```