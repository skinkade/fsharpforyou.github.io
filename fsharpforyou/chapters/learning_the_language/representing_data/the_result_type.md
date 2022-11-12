# The Result Type

The result type allows you to represent success and failure states within your application.

Result is defined as follows:

```fsharp
type Result<'success, 'error> =
    | Ok of 'success
    | Error of 'error
```

We can use this built-in result type to represent success and failure states like so:

```fsharp
let success = Ok "a successful result" // Result<string, 'a>
let failure = Error "a failure" // Result<'a, string>
```

The result module contains useful functions for working with result values.
Two of these are `bind` and `map` which are transformer functions, transforming the inner result value.

```fsharp
let success = Ok 10 // Result<int, 'a>
let successAsString = Result.map string success // Ok "10"
//                               ^^^^^^
//                               the transforming function.

let failure = Error "this is an error"
let failureAsString = Result.map string failure // Error "this is an error"
//                                      ^^^^^^^
//                                      result isn't transformed as it's an error value.
```

```fsharp
let stringToIntConstrained value =
    let number = int value
    if number > 100 then Ok number else Error "number is greater then 100" 
//                       ^^^^^^^^^      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//                       this function returns a new Result value.

let success = Ok "10"
let successAsInt = Result.bind stringToIntConstrained success // Ok 10
//                             ^^^^^^^^^^^^^^^^^^^^^^
//                             the transforming function

let success' = Ok "150"
let successAsInt' = Result.bind stringToIntConstrained success' // Error "number is greater then 100"
```

The key difference between `Result.bind` and `Result.map` are the transformer functions.
`Result.map` transformers the inner `Ok` value and rewraps it in a new `Ok` value, the transformer function is `'okValue -> 'newOkValue`.
While `Result.bind` expects the transformer function to return a result, the transformer function is `'okValue -> Result<'success, 'error>`.