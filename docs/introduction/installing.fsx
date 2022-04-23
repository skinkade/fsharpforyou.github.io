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
Some more documentation using `Markdown`.
*)

let helloWorld() = printfn "Hello world!"

(**
## Second-level heading
With some more documentation
*)

let numbers = [ 0 .. 99 ]
(*** include-value: numbers ***)

List.sum numbers
(*** include-it ***)
