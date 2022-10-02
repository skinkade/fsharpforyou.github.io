# Sequences

Sequences represent a lazily-evaluated, potentially infinite, sequence of elements.

Unlike other forms of collections (lists and arrays). Sequences only produce a value when one is requested. This is beneficial for very large sets of data where you may or may not need to process individual elements.

You can create sequences using the sequence computation expression (you'll learn more about CEs in a future chapter).

```fsharp
seq { for i in 0..1000 -> i * 2 }
```
