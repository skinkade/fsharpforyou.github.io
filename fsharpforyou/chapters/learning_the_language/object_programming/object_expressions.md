# Object Expressions

An object expression allows us to create an anonymous object from an existing base type, or interface/abstract class.

```fsharp
type IDrawable =
    abstract member Draw : float * float -> unit 

let square =
    { new IDrawable with
        member this.Draw(x: float, y: float) =
            printfn $"Drawing a square @ X: {x}, Y: {y}" }

let circle =
    { new IDrawable with
        member this.Draw(x: float, y: float) =
            printfn $"Drawing a circle @ X: {x}, Y: {y}" }

square.Draw(0.0, 0.0)
circle.Draw(5.0, 5.0)
```