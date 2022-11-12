# Statically Resolved Type Parameters

Statically resolved type parameters allow you to constrain generic types at compile time.
These parameters will be replaced by the actual type at runtime.
A statically resolved type parameter is denoted with a `^`.

The inline function:
```fsharp
let inline add x y = x + y
```

Is expanded to:

```fsharp
let inline add (x: ^A) (y: ^B): ^C 
  when (^A or ^B): (static member (+): ^A * ^B -> ^C) =
    x + y
```

What's going on here? First, we define 3 statically resolved type parameters: `^A`, `^B`, and `^C`.
Next, we require that either `^A` or `^B` has a `static member` named `(+)` that matches the signature of `^A * ^B -> ^C`.

Why do we do this? Well.. since these type parameters are resolved at compile time, to be able to invoke `a + b`, we have to ensure this operator actually exists to apply the function call. After all... operators are just regular old functions.