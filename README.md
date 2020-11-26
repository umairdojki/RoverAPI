# RoverAPI

The solution consists of 2 ASP.NET projects:

## RoverAPI

This is a Class Library targetting .NET Standard 2.0. It contains the logic to issue commands to the Rover to navigate around the planet 

## RoverAPITests

This contains the Unit test coverage for the **RoverAPI** project. It references **RoverAPI** as a dependency so it can call the methods on the library and do Assertions. It uses NUnit testing framework targetting .NET Core 3.1

To run the tests on the command line, please download the .NET Core SDK for your environment from https://dotnet.microsoft.com/download/dotnet-core/3.1. Navigate to the path of the project and run `dotnet test` (This will run dotnet restore and build commands implicitly)

```
E.g.
cd C:\code\RoverAPI\RoverAPITests
dotnet test
```
