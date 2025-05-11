# NASA DONKI UI Test Suite

This project automates UI testing for the NASA DONKI sign up using:

- C# and .NET 8
- [Microsoft.Playwright](https://playwright.dev/dotnet/) for browser automation
- [Reqnroll](https://reqnroll.dev/) for BDD (SpecFlow-compatible)
- [NUnit](https://nunit.org/) for assertions

## Project Structure

NASA.UI.Tests/
-- Pages/
----- SignUpPage.cs # Page Object Models for Sign Up page
-- Features/
----- SignUp.feature # Feature file with Gherkin scenarios
-- Steps/
----- SignUpSteps.cs # Step definitions linked to Gherkin steps
-- Hooks/
----- Hooks.cs # Hooks for setup and teardown
-- playwright.runsettings # Config for Playwright execution mode
-- README.md

## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or later

## Installing Dependencies

Run the following commands:

```bash
dotnet restore
playwright install

## Running Tests

```bash
dotnet test

Or

1. Build the solution

2. Open Test Explorer

3. Click Run All