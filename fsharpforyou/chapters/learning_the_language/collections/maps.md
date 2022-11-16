# Maps

Maps represent an immutable sequence of key-value pairs in tuple form.

To start, let's construct an empty map and add values to it one by one.
Because maps are immutable, after adding each key-value pair, we will get back a new map with the appropriate additions.

```fsharp
let map = Map.empty
let map1 = Map.add 1 "Hello, World" map
let map2 = Map.add 2 "Hello, World" map1
printfn "%A" map2 // [(1, "Hello, World"); (2, "Hello, World")]
```

You can also construct a map from a sequence or list of key-value pairs.

```fsharp
let mapFromSequence =
    Map.ofSeq
        seq {
            (1, "Hello, World")
            (2, "Hello, World")
        } 

printfn "%A" mapFromSequence // [(1, "Hello, World"); (2, "Hello, World")]

let valuesL = [(1, "Hello, World"); (2, "Hello, World")]
let mapFromList = Map.ofList valuesL
printfn "%A" mapFromList // [(1, "Hello, World"); (2, "Hello, World")]
```

To lookup a value by its key, you can use `Map.find` or `Map.tryFind`.
The latter function returns an optional value,
while the former will throw an exception if the key isn't present in the map.

```fsharp
let map = Map(
    seq {
        (1, "Hello, World")
        (2, "Hello, World")
    })

let value1 = Map.find 1 map
let optionalValue2 = Map.tryFind 2 map

printfn "%A" value1 // "Hello, World"
printfn "%A" optionalValue2 // Some "Hello, World"
```