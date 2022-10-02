# Generics

Generic type parameters are placeholders for existing types.
They can be swapped out for differing types.

Take a list for example you can have an `int list` or `string list` or `float list` and so on.
Each of these lists can only contain values of their respective types.
This is an example of generic types in action. 

Instead of a function or a type accepting a value with a certain type,
you can replace it with a generic type parameter to allow for other types to be passed instead.

```fsharp
type Option<'a> =
    | None
    | Some of 'a
```

The `'a` in the above definition denotes a generic type parameter. The `a` can be replaced with anything but cannot be duplicated.
If you wanted to define two generic type parameters you could use `'a` and `'b`. 

This option can be an `Option<string>`, `Option<int>`, `Option<float>`, ... etc.
The generic type parameter is passed in (or inferred) when a value of the type is created.

```fsharp
let intOption = Some 10 // Option<int>
let stringOption = Some "Hello, World!" // Option<string>
let floatOption: Option<float> = None
```

