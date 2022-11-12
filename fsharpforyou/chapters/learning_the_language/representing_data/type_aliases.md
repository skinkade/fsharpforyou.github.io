# Type Aliases

Types aliases are abbreviations for existing types.
These are often used to give more context to a primitive type or to shorten type annotations.

```fsharp
type EmailAddress = string
```

Because the `EmailAddress` type is an alias or abbreviation for `string`, the two can be used interchangeably.

```fsharp
let contact (emailAddress: EmailAddress) = $"Sending an email to {emailAddress}"

contact "johndoe@site.com" // "Sending an email to johndoe@site.com"
```

This can often be used to give more context to a primitive type, such as `string`, without wrapping it in a stricter type.
<!-- If you're expecting strictness here, where `EmailAddress` has to be a valid email, don't.  -->