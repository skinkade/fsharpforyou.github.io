# Generics

Generic type parameters are placeholders for types that will be filled in by the caller. Generic types allow us to parameterize the types of values being used in bindings, function calls, or type definitions.

For example, you can have an `int list`, a `string list`, or a `float list`. Each of these will only contain values of their respective types. A `string list` cannot contain `float` values and a `float list` cannot contain `string` values. This is an example of generic type parameters in action.

You can define a generic type parameter using an apostrophe followed by the name of the type parameter.

```fsharp
type Option<'a> =
    | None
    | Some of 'a
// 'a is a generic type
// it will be filled in by the caller
```

The `'a` in the above definition denotes a generic type parameter.
If you wanted to define two generic type parameters you could use `'a` and `'b`.
Sometimes, context-specific names are more appropriate choices, such as `'success` and `'error`, to model success and error types.

This option can be an `Option<string>`, `Option<int>`, `Option<float>`, ... etc.
The generic type parameter is passed in (or inferred) when a value of the type is created.

```fsharp
let intOption = Some 10 // Option<int>
let stringOption = Some "Hello, World!" // Option<string>
let floatOption: Option<float> = None
//               ^^^^^^^^^^^^^
// here we annotate the type because the compiler can't
// infer the generic type parameter of a `None` value
// as it has no data associated with it.
```

You can also define generic type parameters in functions and pass them to your desired type. Here we can accept a value of our generic option type, passing a generic type parameter to it in the process. 

```fsharp
let acceptOption (option: Option<'a>) =
//                        ^^^^^^^^^^
//                        a generic option.
    printfn $"{option}"

acceptOption intOption // <- Option<int>
acceptOption stringOption // <- Option<string>
acceptOption floatOption // <- Option<float>
```