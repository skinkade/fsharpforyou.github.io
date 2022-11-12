# Accessibility Modifiers

Accessibility modifiers can restrict access to code within modules.

The default accessibility is `public` unless otherwise specified.
This means other modules can freely use your module's types and functions without restrictions.

Other accessibility modifiers include:  
`private` which restricts usage to the containing module and  
`internal` which restricts usage to the containing assembly.  

Access modifiers come directly after `let` in bindings and function declarations.

```fsharp
module Math =
    let add x y = x + y
    let multiply x y = x * y

    let private divide x y = x / y
    //  ^^^^^^^ private modifier

    let internal divide2 x y = x / y
    //  ^^^^^^^^ internal modifier.

module Operations =
    // We can't use the `divide` function here.
    // However, we can use the `divide2` function here.
```