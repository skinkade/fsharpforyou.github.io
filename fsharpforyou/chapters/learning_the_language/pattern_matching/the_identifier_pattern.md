# The Identifier Pattern

The identifier pattern allows us to match against a discriminated union's case (its identifier) and optionally, supply a pattern for the data associated with the case.

```fsharp
type ContactInfo =
    | EmailAddress of string
    | PhoneNumber of string

let contact contactInfo =
    match contactInfo with
    | EmailAddress email -> $"Sending an email to {email}"
    | PhoneNumber number -> $"Sending a text message to {number}"

let emailAddress = EmailAddress "johndoe@provider.com"
contact emailAddress // "Sending an email to johndoe@provider.com"
```

In the above match expression, we match against the discriminated union's identifier and bind the value associated with it to a name using the variable pattern. Because the identifier patterns allow us to specify a pattern for the case's data, we can have conditional branches using the identifier and constant pattern like so:

```fsharp
type ContactInfo =
    | EmailAddress of string
    | PhoneNumber of string

let contact contactInfo =
    match contactInfo with
    | EmailAddress "johndoe@provider.com" -> "Not contacting, this is a dummy email"
    | PhoneNumber "000-000-0000" -> "Not contacting, this is a dummy phone number"
    | EmailAddress email -> $"Sending an email to {email}"
    | PhoneNumber number -> $"Sending a text message to {number}"

contact (EmailAdress "johndoe@provider.com")
// "Not contacting, this is a dummy email"

contact (PhoneNumber "000-000-0000")
// "Not contacting, this is a dummy phone number"
```