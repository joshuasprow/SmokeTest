#!/usr/bin/env bash

dotnet publish --runtime=win-x64 --self-contained=true &&
    cp bin/Debug/net5.0/win-x64/publish/SmokeTest.exe dist/SmokeTest.exe
