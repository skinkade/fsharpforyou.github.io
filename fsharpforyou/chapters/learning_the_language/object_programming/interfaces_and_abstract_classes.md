# Interfaces and Abstract Classes

Interfaces and abstract classes allow you to write abstract members that serve as behavior for classes to inherit or implement.

```fsharp
type IDrawable =
    abstract member Draw : float * float -> unit 
```

The above drawable interface provides a `Draw` member that implementors must provide an implementation for.
These interfaces serve as contracts that must be fulfilled by the client.

```fsharp
type Square(size: int) =
    interface IDrawable =
        member this.Draw(x: float, y: float) =
            ...
```

In the above example, the square object implements the interface `IDrawable` and provides an implementation for the `Draw` member that matches the signature defined in the interface.

Objects can also inherit functionality from other objects. Inheriting creates a hierarchical relationship between two objects (parent and child), where the child has all the behavior of the parent, but overrides/implements (abstract) members that are present in the parent object.

```fsharp
type Rockstar() =
    member _.PlayMusic() = ...
    abstract member Sing: unit -> unit

type FreddieMercury() =
    inherit Rockstar()
    override this.Sing() = ...

let rockstar = Rockstar()
rockstar.PlayMusic()

let freddie = FreddieMercury()
freddie.PlayMusic() // inherits behavior of the parent.
freddie.Sing() // overrides abstract behavior in the parent.
```