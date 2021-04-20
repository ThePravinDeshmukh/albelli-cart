#!/bin/bash

dotnet restore
dotnet build
dotnet tool install --global dotnet-ef
cd Albellicart
dotnet ef database update
dotnet run
