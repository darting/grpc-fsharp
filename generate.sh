#!/bin/bash

TOOLS_DIR=$HOME/.nuget/packages/grpc.tools/1.9.0/tools/macosx_x64

function genereate () {
    local target=$1
    local output=generated/$target
    mkdir -p $output
    $TOOLS_DIR/protoc -I ./protos --csharp_out $output --grpc_out $output ./protos/$target.proto --plugin=protoc-gen-grpc=$TOOLS_DIR/grpc_csharp_plugin

    # create c# lib
    dotnet new classlib -o=generated/$target/ --force
    cd $output
    rm -rf Class1.cs
    dotnet add package Google.Protobuf
    dotnet add package Google.Protobuf.Tools
    dotnet add package Grpc
    dotnet add package Grpc.Tools
    dotnet restore
}

genereate $1

echo DONE