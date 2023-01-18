# Type Aliases

Types aliases are abbreviations for existing types. As aliases or abbreviations, these are often used to create a shorter and reusable name for an existing type.  

```fsharp
type Strings = string list
```

Because the `Strings` type is an abbreviation for `string list`, the two can be used interchangeably.

```fsharp
let commas (strings: Strings) =
    String.concat "," strings

commas ["Hello"; "World"] // "Hello,World"
//     ^^^^^^^^^^^^^^^^^^
//     passing a string list where
//     a `Strings` is expected.
```