# Modules

Modules allow you to logically and physically group related code together.

```fsharp
module Math =
    let add x y = x + y
    let multiply x y = x * y
```

Accessibility modifiers can restrict access to code within modules.
The default accessibility is `public` unless otherwise specified.
This means other modules can freely use your module's types and functions.

Other accessibility modifiers include:
`private` which restricts usage to the containing module and
`internal` which restricts usage to the containing assembly.

```fsharp
module Math =
    let add x y = x + y
    let multiply x y = x * y

    let private divide x y = x / y
    //  ^^^^^^^ private modifier

module Operations =
    // I can't use the divide function here.
```

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

In certain cases, it's beneficial to require qualified access of a function or type. Especially when dealing with modules that are named after types that contain functions operating on them. A good example of this is the `List` module. We can do this by annotating a module with `[<RequireQualifiedAccess>]`.

```fsharp
[<RequireQualifiedAccess>]
module List =
    let double (list: int list) = list |> List.map (fun elem -> elem * 2)
```