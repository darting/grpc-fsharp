open System
open Grpc.Core
open Helloworld
open System.Threading.Tasks

type GreeterImpl () =
    inherit Helloworld.Greeter.GreeterBase ()

    override this.SayHello(request: HelloRequest, context : ServerCallContext) : Task<HelloReply> =
        HelloReply(Message = "hello") |> Task.FromResult



[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    let port = 5432
    let server = Server ()
    server.Services.Add(Helloworld.Greeter.BindService(GreeterImpl()))
    server.Ports.Add(ServerPort("localhost", port, ServerCredentials.Insecure)) |> ignore
    server.Start()

    Console.WriteLine("Press any key to stop the server...")
    Console.ReadKey() |> ignore

    server.ShutdownAsync().Wait()

    0
