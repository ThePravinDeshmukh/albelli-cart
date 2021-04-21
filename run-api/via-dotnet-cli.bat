#!/bin/bash

cd ..\src\Albellicart

dotnet restore

START dotnet run

START Http://localhost:5000/ui/playground