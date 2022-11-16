# The Result and Option Types

The result type allows you to represent success and failure states within your application
and the option type allows you to represent optional values.

The result and option types are defined as follows:

```fsharp
type Result<'success, 'error> =
    | Ok of 'success
    | Error of 'error

type Option<'value> =
    | Some of 'value
    | None
```

We can use these built-in types to represent success, failure, and optional states like so:

```fsharp
let success = Ok "a successful result" // Result<string, 'a>
let failure = Error "a failure" // Result<'a, string>

let optionalInt = Some 10 // int option
let nothing = None // 'a option <-- can't infer the type parameter yet.
```

The result and option module contains useful functions for working with these values.
Two of these are `bind` and `map` which transform the inner result or option value.

```fsharp
let success = Ok 10 // Result<int, 'a>
let successAsString = Result.map string success // Ok "10"
//                               ^^^^^^
//                               the transforming function.

let failure = Error "this is an error"
let failureAsString = Result.map string failure // Error "this is an error"
//                                      ^^^^^^^
//                                      result isn't transformed as it's an error value.

let optionalInt = Some 10
let optionalString = Option.map string optionalInt // Some "10"

let nothing = None
let nothingMapped = Option.map string nothing // None
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

You can think of `Result` and `Option` as a context. The `bind` and `map` functions extract the happy (`Ok` or `Some`) value from that context, transform it with a transforming function, and yield a new value of the same context. The difference between `bind` and `map` is the transformer functions. `map`'s transformer functions simply transform `'a` to `'b` while `bind`'s transformer function rewraps the value into the context, ex: `'a -> Result<'b, 'error>`.