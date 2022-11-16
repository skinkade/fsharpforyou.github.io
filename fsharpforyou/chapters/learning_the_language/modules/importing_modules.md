# Importing Modules

To use another module's functions or types, you can import them with `open`.

```fsharp
open Math // import functions and types from module

let sum = add 10 5
let product = multiply 10 3
```

Another option is to use the fully qualified name of the function or type.

```fsharp
let sum = Math.add 10 5
let product = Math.multiply 10 3
//            ^^^^^^^^^^^^^ fully qualified function call

```

In certain cases, it's beneficial to require qualified access to a function or type.
Especially when dealing with modules that are named after types that contain functions operating on them.
A good example of this is the `List` module.

We can do this by annotating a module with `[<RequireQualifiedAccess>]`.

```fsharp
[<RequireQualifiedAccess>]
module List =
    let double (list: int list) = list |> List.map (fun elem -> elem * 2)

let doubled = List.double [1..10]
```