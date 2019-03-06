module App

open Fable.Core.JsInterop
open Fable.Import

let app = express.Invoke()
let port = 3000

app.get (!^ "/", (fun _ (res: express.Response) _ -> res.send("works") |> box)) |> ignore

app.listen(port, fun _ -> 
    printfn "server started on %i" port
) |> ignore