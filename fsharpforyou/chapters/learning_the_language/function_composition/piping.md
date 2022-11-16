# Piping

Piping allows us to pass an initial value through one or more functions and collect the result.
It is a way of composing smaller functions into a larger workflow.

Passing a value into a function.

```fsharp
f x
```

Is equivalent to piping the value into the function.

```fsharp
x
|> f
```

Another way of demonstrating this is to define our own `|>` operator.

```fsharp
let inline (|>) value func = func value
```

Let's use these functions to demonstrate the power of piping and composition.

```fsharp
let add x y = x + y
let double x = x * 2
```

Here, we can pass two values into the add function, and then pass the result into the double function.

```fsharp
let ten = add 5 5
let result = double ten
```

We can improve this code by composing these functions using the pipe operator.
The pipe operator allows us to pass a value into a single parameter function.

Because the `add` function has a signature of `int -> int -> int`,
we can partially apply a single parameter to the add function to produce a `int -> int` function.
Piping a single value into this new function will produce an `int` result.

```fsharp
let result =
    5
    |> add 5
    |> double
```

Piping is especially beneficial when dealing with long chains of functions.
Let's demonstrate this using list module functions.

```fsharp
let even x = x % 2 = 0
let double x = x * 2

[0..10]
|> List.filter double
|> List.map even
|> List.iter (printfn "%d")
```

To add or remove a step from this workflow, all that's required is adding or removing a single pipe.