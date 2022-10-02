# Recursive Functions

Recursive functions are functions that can call themselves recursively. One useful example of recursive functions is defining functions that declaratively iterate over elements of a sequence, such as a list.

```fsharp
let rec forEach (f: 'a -> unit) (list: 'a list) =
    match list with
    | [] -> ()
    | x :: xs ->
        f x
        forEach f xs
//      ^^^^^^^^^^^^ call this function recursively with the tail of the list
```

```fsharp
let rec map (f: 'a -> 'b) (list: 'a list) =
    match list with
    | [] -> []
    | x :: xs -> f x :: map f xs
```

```fsharp
let rec fold (f: 'State -> 'a -> 'State) (state: 'State) (list: 'a list) =
    match list with
    | [] -> state
    | x :: xs ->
      let newState = f state x
      fold f newState xs
```
