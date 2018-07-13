#!/usr/bin/env bash
cd ..
dotnet restore ./HairSalon
dotnet build ./HairSalon
dotnet restore ./HairSalon.Tests/
