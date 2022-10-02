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

Let's define two functions for demonstration purposes.

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
Because the `add` function has two parameters,
we have to partially apply a parameter to the `add` function to produce a function that results in an `int` value.

```fsharp
let result =
    5
    |> add 5
    |> double
```

This technique is especially beneficial when dealing with long chains of functions.
Let's demonstrate this using list module functions.

```fsharp
let even x = x % 2 = 0
let double x = x * 2

[0..10]
|> List.filter double
|> List.map even
|> List.iter (printfn "%d")
```