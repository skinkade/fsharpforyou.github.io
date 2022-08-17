(**
---
title: Installing F#
category: Introduction
categoryindex: 1
index: 1
---
*)

(**
# Installing F#
First, you have to install [.NET](https://dotnet.microsoft.com/en-us/download).

Once you've done that, you're done! You've installed `F#`! Wow!

For editors, we recommend [VS Code](https://code.visualstudio.com/) with the [Ionide](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp) extension.

You're more than welcome to use any editor that strikes your fancy. Except maybe not Microsoft Word.
*)

(**
## Our first program
There are a couple of ways we can run `F#` code.
To open an interactive session where we can enter code and have it immediately evaluated,
fire up your friendly local command prompt and type `dotnet fsi`.
Once you're jacked in, do the following:
*)

printfn "Hello world!";;

(**
Incredible. Do you feel the power coursing through your veins?

Type a few more things just to get your adrenaline flowing.

Make sure to include the `;;` at the end. This won't be required in
regular `F#` code, but is important to tell the interactive session
we're ready to be evaluated.
*)

let numbers = [ 0..99 ];;
(*** include-value: numbers ***)

List.sum numbers;;
(*** include-it ***)

(**
To exit the interpreter, type `#quit;;` and hit enter OR press `Ctrl D`.
*)