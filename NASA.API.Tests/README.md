# NASA DONKI API Test Suite

This project contains automated tests for NASA's DONKI API endpoints (`CME`, `FLR`, etc.) using:

- C# and .NET 8
- [SpecFlow](https://specflow.org/) for BDD
- [RestSharp](https://restsharp.dev/) for HTTP calls
- [NUnit](https://nunit.org/) for test assertions

## Project structure

NASA.API.Tests/

-- Client/
---- DonkiApiClient.cs # Handles API requests
-- Features/
---- CME.feature # Feature files with BDD scenarios
---- FLR.feature
-- Steps/
---- CMESteps.cs # Step definitions for CME
---- FLRSteps.cs # (Optional) Steps for FLR
---- SharedSteps.cs # Shared step definitions (e.g., common assertions)
-- README.md

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Visual Studio 2022+ (or Rider) with **SpecFlow extension** (or Reqnroll)
- Internet connection (for hitting NASA’s public API)

## Installing Dependencies

Open terminal or package manager console and run:

dotnet restore

## Running Tests

CLI
dotnet test

Test Explorer
1) Build solution
2) Open Test Explorer window
3) Play Button

## Tags

Execute specific tests using tags

dotnet test --filter "TestCategory=smoke"