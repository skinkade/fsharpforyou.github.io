# Maps

Maps represent an immutable collection of key-value pairs.

You can think of a collection of key-value pairs as a collection of 2-element tuples, where the first element is the key, and the second is the value.

```fs
let keyValuePairs = [
    "Key1", "Value1"
    "Key2", "Value2"
]
```

This list of key-value pairs can be converted directly into a map using the `Map.ofList` module function.

```fsharp
let keyValuePairs = [
    "Key1", "Value1"
    "Key2", "Value2"
]

let map = Map.ofList keyValuePairs
// map = Map<string, string>
//           ^^^^^^  ^^^^^^
//           key     value
```

You can access the values of a map by looking up their respective keys using the `Map.find` or `Map.tryFind` value. The `try` variant will throw an exception (error) if the key does not exist. The `tryFind` variant will yield an optional value, which is a type that represents the presence or absence of a value (this will be covered more later).

```fsharp
let value1 = Map.find "Key1" map // "Value1"
let value2 = Map.find "Key2" map // "Value2"

let value1Option = Map.tryFind "Key1" map // Some "Value1"
let value2Option = Map.tryFind "Key2" map // Some "Value2"
let value3Option = Map.tryFind "test" map // None <- does not exist in map
```

Maps, like lists, are immutable. After adding or removing an element, we will get back a new map with the appropriate additions or deletions.

```fsharp
let map1 = Map.add "Key3" "Value3" map
(*
map1 =
  [
    ("Key1", "Value1")
    ("Key2", "Value2")
    ("Key3", "Value3")
  ]
*)

let map2 = Map.add "Key4" "Value4" map1
(*
map2 =
  [
    ("Key1", "Value1")
    ("Key2", "Value2")
    ("Key3", "Value3")
    ("Key4", "Value4")
  ]
*)
```