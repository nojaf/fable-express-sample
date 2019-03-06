module App

open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React

let app = express.Invoke()
let port = 3000

let view () =
    h1 [] [str "Hello World"]

app.get (!^ "/", (fun _ (res: express.Response) _ -> 
    let html = ReactDomServer.renderToString(view())
    res.send(html) |> box)
) |> ignore

app.listen(port, fun _ -> 
    printfn "server started on %i" port
) |> ignore