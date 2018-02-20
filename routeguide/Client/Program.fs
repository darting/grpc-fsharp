// Learn more about F# at http://fsharp.org

open System
open Grpc.Core
open Routeguide

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    
    let channel = Channel("localhost:5432", ChannelCredentials.Insecure)
    let client = RouteGuide.GreeterClient(channel)

    // let reply = client.SayHello(HelloRequest( Name = "V" ))
    // printfn "reply: %s" reply.Message

    channel.ShutdownAsync().Wait()
    printfn "Press any key to exit..."
    Console.ReadKey() |> ignore
    
    0
    
