# The Option Type

The option type allows you to represent optional values.

The option type is defined as:

```fsharp
type Option<'value> =
    | Some of 'value
    | None
```

