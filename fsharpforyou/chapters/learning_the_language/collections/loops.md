# Loops

`for...in` expressions allow us to enumerate over a sequence of values and use the value in an expression body. The result of the expression body is ignored. Oftentimes, a unit-returning function will be called with the current value.

```fsharp
let nums = [1; 2; 3; 4; 5]

for elem in nums do
    printfn $"{elem}"
```

You can also iterate over a range of numbers using the range operator like so:

```fsharp
for i in 0..10 do
    printfn $"Number: {i}"
```

