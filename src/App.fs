module App

open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

let path : Fable.Import.Node.Path.IExports = importDefault "path"

let app = express.Invoke()
let port = 3000
let prefix = "be19"
let rootUrl = sprintf "/%s" prefix
let publicFolder = path.join(Node.Globals.__dirname ,"../public")

let view () =
    html [] [
        head [] [
            link [Href "/be19/style.css"; Rel "stylesheet"]
        ]
        body [] [
            main [] [
                h1 [] [str "Birmingham Express 2019"]
                img [Src "/be19/batman.jpg"]
                br []
            ]
        ]
    ]

    
    
app.``use``(rootUrl, express.``static``.Invoke(publicFolder)) |> ignore

app.get (!^ rootUrl, (fun _ (res: express.Response) _ -> 
    let html = ReactDomServer.renderToString(view())
    res.send(html) |> box)
) |> ignore

app.listen(port, fun _ -> 
    printfn "server started on %i" port
) |> ignore