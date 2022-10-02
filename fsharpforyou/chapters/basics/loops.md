# Loops

Loops allow you to enumerate a sequence of elements, and perform a specific action with every element in the sequence.

```fsharp
let nums = [1; 2; 3; 4; 5]

for elem in nums do
    printfn "%d" elem
```

The loop will iterate through the collection of elements, binding each current element to the name `elem` so that it can be used later down the road. `for` expressions will always produce a unit value, they allow you to operate on every element in the collection.
