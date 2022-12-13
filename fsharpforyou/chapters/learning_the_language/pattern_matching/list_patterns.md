# List Patterns

The list pattern allows us to match against the contents of a list, providing a pattern for each element at a given index.

```fsharp
let describe numbers =
    match numbers with
    | [] -> "Empty list"
    | [1] -> "Single element: 1"
    | [1; 2] -> "Two elements: 1, 2"
    | [_; _] -> "Two unknown elements"
    | _ -> "Unknown description"

describe [1] // "Single element: 1"
describe [1; 2] // "Two elements: 1, 2"
describe [5; 6] // "Two unknown elements"
```

The cons pattern allows you to separate a list into its head and tail bindings. The head of a list is the first element, and the tail is every other element.

```fsharp
let describe numbers =
    match numbers with
    | [] -> "Empty list"
    | head :: tail -> $"Head: {head}, Tail: {tail}"

describe [] // "Empty list"
describe [1] // "Head: 1, Tail: []"
descrube [1; 2; 3] // "Head: 1, Tail: [2; 3]"
```

This variant of the cons pattern will match against any list with at least a single element. However, you can also separate a list into N number of elements and the tail by adding additional bindings.

```fsharp
let describe numbers =
    match numbers with
    | [] -> "Empty list"
    | first :: second :: tail ->
        $"First: {first}, Second: {second}, Tail: {tail}"
    | head :: tail ->
        $"Head: {head}, Tail: {tail}"

describe [1; 2; 3] // "First: 1, Second: 2, Tail: [3]"
```