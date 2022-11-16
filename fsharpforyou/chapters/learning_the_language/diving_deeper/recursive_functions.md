# Recursive Functions

Recursive functions are functions that can call themselves recursively.
One useful example of recursive functions is defining functions that declaratively iterate over elements of a sequence, such as a list.

Let's look at an example of a recursive function that exists in the standard library.

```fsharp
let nums = [0..10]
let sum = List.fold (+) 0 nums
```

The fold function is made up of 3 parts:
A `folder` which is a function that takes a `state` value and a `collection` of elements. The folder function is then applied using the current element in the list and the current state. After the function application, a new state value will be returned, which is then used for the subsequent item in the collection. This is repeated until there are no more elements in the collection to process and the state value is returned.

`folder: (+)`  
`state: 0`  
`list: [0..10]`

1st iteration:  
`first element in the list: 0`  
`operation: (+) 0 0`  
`new state: 0` 

2nd iteration:  
`second element in the list: 1`  
`operation: (+) 0 1`  
`new state: 1`

and so on...

Now that you hopefully understand how `List.fold` works, let's implement this ourselves using recursion.

```fsharp
// notice the "rec" keyword here.
let rec fold (folder: 'State -> 'T -> 'State) (state: 'State) (elems: 'T list) =
    match elems with
    | [] ->
        // if the list is empty, return the state.
        state
    | x :: xs ->
        // Apply the `folder` to the current element and the current state.
        let newState = folder state x

        // call this function recursively with the new state, and the subsequent elements.
        fold folder newState xs

let res = fold (+) 0 [0..10]
```

Most recursive functions follow the same pattern. Apply a function to each element within a sequence, and pass either the result of the computation, the subsequence elements, or both, into the function recursively.

```fsharp
let rec forEach (f: 'a -> unit) (list: 'a list) =
    match list with
    | [] -> ()
    | x :: xs ->
        f x

        // only pass the subsequent elements recursively.
        forEach f xs

forEach (printfn "%d") [0..10]
```