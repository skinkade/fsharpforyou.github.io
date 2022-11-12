# Sequences

Sequences represent a lazily-evaluated, potentially infinite, sequence of elements.
The laziness of sequences is especially beneficial for very large sets of data where you only need to process a subset of the elements.

You can create sequences using the sequence computation expression
(you'll learn more about computation expressions in a future chapter).

```fsharp
seq { 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 }
```

The sequence module, like the list module, includes helper functions for manipulating sequences in certain ways.
Many of these functions are also present in the list module, such as: `map`, `filter`, `head`, ...

```fsharp
let double x = x * 2

let nums = seq { 1..10 }
let doubled = Seq.map double nums
```