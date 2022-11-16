# Classes and Members

F#, being a multi-paradigm language, has support for object programming.

Classes are a way of encapsulating data and behavior and can inherit or implement behavior from other classes/interfaces.
Members are functions or values that exist on an instance of an object. These members are what encapsulate data and behavior in F#

Let's start off with the basics. First, we can define a `type Person` that is constructed with `firstName` and `lastName` parameters.

```fsharp
type Person(firstName: string, lastName: string) = ...
```

Then, we'll need member values to expose the `firstName` and `lastName` parameters as public read-only (immutable) values.

```fsharp
type Person(firstName: string, lastName: string) =
    member val FirstName = firstName with get
    member val LastName = lastName with get
```

Finally, we can construct an instance of the type person by supplying it with the desired `firstName` and `lastName` values.

```fsharp
let person = Person("John", "Doe")
person.FirstName // "John"
```

Classes can also encapsulate behavior (functions!).
These are a bit different than let bindings, as they usually are uncurried and exist on instances of a class.

```fsharp
type Person(firstName: string, lastName: string) =
    member val FirstName = firstName with get
    member val LastName = lastName with get

    member this.Greet() = $"Hello {this.FirstName} {this.LastName}!"
//         ^^^^                    ^^^^             ^^^^
// note the usage of `this` in the above example
// this is used to access values of the current instance.
// the name `this` is arbitrary and can be anything, or even discard with `_`
// although `this` is common as it's used in other languages as well.

let person = Person("John", "Doe")
let greeting = person.Greet() // "Hello John Doe!"
```