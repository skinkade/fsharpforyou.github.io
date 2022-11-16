# Let Bindings

Now that we understand the purpose of expressions and values, we can begin to use them.

A let binding allows us to bind a name to a value.

```fsharp
let ten = 10
```

From left to right, this reads as: `let` the name `ten` be bound to the value `10`.
The type of `ten` will be an `int`.

We usually don't have to specify types as the compiler will infer them from their usage.
In this case, `10` is inferred as an integer although it can easily be several other numerical types.
If the compiler doesn't have enough information to infer your desired type, you can add a type annotation to override it.

```fsharp
let ten: float = 10
```

Because let bindings bind a value to a name.
You can replace `10` with any expression that produces a value of `10` to achieve the same result.

```fsharp
let ten = 5 + 5
```

By default, let bindings are immutable. This means we can't change their values after creation.
Immutability is preferred as it ensures that values won't be changed unexpectedly and results in code that's easier to reason about.