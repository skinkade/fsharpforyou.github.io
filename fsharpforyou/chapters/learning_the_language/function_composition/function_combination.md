# Function Combination

Function combination, or simply, composition, is the act of chaining multiple functions together to form a new, larger workflow.
We can achieve this by combining multiple functions together such as `f` and `g` are composed to create a new function which resembles: `f(g(5))`

We can achieve this using the composition (`>>`) operator.

```fsharp
let addFive x = x + 5
let double x = x * 2
let negative x = x * -1

let workflow = addFive >> double >> negative
let result = workflow 10 // result: -30
```

The expression `addFive >> double >> negative` creates a new function where
the value `x` will be passed into the composed function `negative(double(addFive(x)))`