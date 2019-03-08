module App

open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

let path : Fable.Import.Node.Path.IExports = importDefault "path"
let http : Fable.Import.Node.Http.IExports = importDefault "http"

let app = express.Invoke()
let port = 9000
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
                h1 [] [str "Birmingham Express 2019!"]
                img [Src "/be19/batman.jpg"]
                br []
            ]
            script [Id "__bs_script__"] [ str """//<![CDATA[document.write("<script async src='http://HOST:3000/browser-sync/browser-sync-client.js?v=2.26.3'><\/script>".replace("HOST", location.hostname));//]]"""]
        ]
    ]

    
    
app.``use``(rootUrl, express.``static``.Invoke(publicFolder)) |> ignore

app.get (!^ rootUrl, (fun _ (res: express.Response) _ -> 
    let html = ReactDomServer.renderToString(view())
    res.send(html) |> box)
) |> ignore

app.listen(port, fun _ -> 
    printfn "server started on %i" port
    #if DEBUG
    // http.get("http://localhost:3000/__browser_sync__?method=reload")
    #endif
) |> ignore