(**
---
title: Modules
category: Basics
categoryindex: 2
index: 10
---
*)

(**
# Modules
Modules allow you to logically and physically group together related code.
Modules can contain types, functions, bindings, and other modules.
*)

module Math =
    let add x y = x + y
    let multiply x y = x * y
(*** include-fsi-output ***)

(**
You can use types and functions from other modules by importing them using
the ``open`` keyword followed by the module name.
*)
open Math

let operation number = number |> add 3 |> multiply 4

let operationResult = operation 40
(*** include-fsi-output ***)

(**
As you can see from the above example. We import the functions from the ``Math`` module
and call them like any other function. You can also access module members by their fully qualified name without importing the module.
*)
let res = Math.add 3 5
(*** include-fsi-output ***)

(**
You can annotate a module with ``[<AutoOpen>]`` to automatically import/open it without requiring ``open ...``.
The primary purpose of this is to automatically import let bindings and utility functions
to allow other modules to call them without requiring  an import.
This can however cause clutter if you use it too much and it should be avoided in a lot of cases.
*)

[<AutoOpen>]
module Helpers =
    let log x = printfn $"Something happened! {x}"

log "I called a module function without an `open`"
(*** include-output ***)

(**
Sometimes it makes sense to require qualified access for various reasons including: name conflicts, clarity/semantics, and integration
with other qualified function calls. You can do this with the ``[<RequireQualifiedAccess>]`` attribute.
Here we require qualified access to seamlessly integrate our function with other List module functions in the pipeline
and avoid naming conflicts with other ``double`` functions that may exist elsewhere.
*)
[<RequireQualifiedAccess>]
module List =
    let double list =
        list |> List.map (fun elem -> elem * 2)

let result = 
    [1..10]
    |> List.filter (fun x -> x % 2 = 0)
    |> List.double
(*** include-value: result ***)

(**
We can restrict access to certain functions, types, and their constructors
by using accessibility modifiers.  
``public`` indicates that a function or type can be accessed by any module.  
``private`` indicates that a function or type can be accessed by only the same module.  
``internal`` indicates that a function or type can be accessed within the same assembly.
*)

module AccessibilityModifiers =
    // a private type
    // can only be used within this module.
    type private Customer = { FirstName: string; LastName: string }

    type Person =
        // a private constructor
        // this type can only be constructed
        // within this module.
        // this type can be used, but not constructed, elsewhere.
        private
            { FirstName: string
              LastName: string }

    // a private function.
    // can only be called within this module
    let private operation x = x * 5 / 2

    // a internal function.
    // can only be called within this assembly.
    let internal operation2 x = x * 5