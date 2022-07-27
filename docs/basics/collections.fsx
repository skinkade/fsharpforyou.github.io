(**
---
title: Collections
category: Basics
categoryindex: 2
index: 5
---
*)

(**
# Collections
Collections represent a series of elements of the same type.
There are different types of collections in F#, including: Lists, Arrays, and Sequences

Lists: Lists are an immutable series of elements implemented as singly linked list.  
Arrays: Arrays are a fixed-size mutable series of elements.  
Sequences: Sequences are an immutable series of elements. Unlike arrays and lists, the elements
of a sequence are only computed/evaluated when it is required to do so, which means they are lazily evaluated and can have an infinite members.

## Lists
You can define a list by surrounding a **semicolon** (not comma, commas are for Tuples) separated sequence of values surrounded by square brackets like so:
*)

let list = [1; 2; 3; 4; 5]
(*** include-fsi-output ***)

(**
You can access individual values of a list through its indexer.
In F#, collections are indexed by 0, which means the first element has an index of 0, the second element has an index of 1, and so on...
*)
let firstElement = list[0]
(*** include-fsi-output ***)

(**
You can also access a subsequence of values using a range.
You can create a range by defining the lower bound and upper bound separated by two periods like so:
*)
let threeElements = list[0..2]
(*** include-fsi-output ***)

(**
As you can see from the above example, every element from index 0 to 2 is present in the new list.

Not only can you index a specified range, but you can also construct a list with every element in
a specified range like so: 
*)

let numbers = [0..10]
(*** include-fsi-output ***)

(**
Ranges can also have a "step amount" which dictates how many steps are taken from one element to the next.
A range of ``[0..10]`` with a step amount of 2 will produce even numbers.
The first element is 0 then the next element will be 2... and so on.
We can define a step amount by inserting it between the lower and upper bound like so:
*)

let evenNumbers = [ 0 .. 2 .. 10 ]
(*** include-fsi-output ***)

(**
You can use the CONS operator (``::``) to add an element to the beginning of a list.
As lists are immutable, any "modification" won't modify the original list, but instead will return a
new list with the appropriate changes.
*)
let integers = [1;2;3;4;5]
let integers2 = 0 :: integers
(*** include-fsi-output ***)

(**
If you wanted to append not only an element, but an entire list to the beginning of another,
you would use the ``@`` operator instead like so:
*)
let integers3 = [1;2;3;4;5]
let integers4 = integers @ [6;7;8;9;10]
(*** include-fsi-output ***)

(**
You can use for comprehension to build a list from a ``for`` expression like so:
*)
let doubles = [for i in 0..10 -> i * 2]
(*** include-fsi-output ***)

(**
This reads as: ``for`` every element in the sequence ``0..10``,
bind the current element to the name ``i``, and yield the value ``i * 2``

### List module functions
The list module has useful functions for working with lists.
Some of these functions include:  
``filter`` which will filter elements from a list using a conditional value,  
``map`` which will map every element in a list to a new element,  
``iter`` which allows you to call a function with every element in a list,  
and many more.
*)
let nums = [0..10]
(*** include-value: nums ***)

let filteredNums = List.filter (fun number -> number > 5) nums
(*** include-value: filteredNums ***)

let doubledFilteredNums = List.map (fun number -> number * 2) filteredNums
(*** include-value: doubledFilteredNums ***)

(**
## Arrays
Arrays and lists have very similar construction syntax, however, the square brackets are
accompanied by a vertical bar.
*)
let array = [| 1;2;3;4;5 |]
(*** include-fsi-output ***)

(**
Unlike lists, you can mutate individual elements in an array by using its indexer.
*)
array[0] <- 10
(*** include-value: array ***)


(**
## Sequences
Sequences are constructed using a Computation Expression (you'll learn about these later).
Some examples of sequence expressions are as follows:
*)
let numsSequence = seq { 1..10 }
let doublesSequence = seq { for i in 0..10 -> i * 2 }

(**
As noted in the beginning, the elements of a sequence aren't computed when the sequence is created. They are only computed
when the value is required to perform a certain operation.
*)
let sequence = seq { 0..10 }
Seq.head sequence
(*** include-fsi-output ***)

(**
As you can see from the above example, the first element of the sequence is computed as a result of calling ``Seq.head``.
Any further call to ``Seq.head`` will use the already evaluated value. No further evaluation of the first element is required.
*)
