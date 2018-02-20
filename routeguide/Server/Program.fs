open System
open Grpc.Core
open System.Threading.Tasks

type RouteGuideSercieImpl () =
    inherit RouteGuide.RouteGuideBase ()
    



[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    let port = 5432
    let server = Server ()
    server.Services.Add(Routeguide.RouteGuide.BindService(RouteGuideSercieImpl()))
    server.Ports.Add(ServerPort("localhost", port, ServerCredentials.Insecure)) |> ignore
    server.Start()

    Console.WriteLine("Press any key to stop the server...")
    Console.ReadKey() |> ignore

    server.ShutdownAsync().Wait()

    0
