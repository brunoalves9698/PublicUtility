# PublicUtility

Landis Gyr´s Home Work

## About this Project

This project is a Home Work for Landis Gyr´s.

There was a concern for the project to follow good object oriented programming practices and clean code.

## Features

- Architectural
  - Division into layers
  - Principles of SOLID and Clean Code

- Database InMemory
  - Repository Pattern (EF 3.0.1)
  
- Tests
  - Unitary Tests (MS Test)
  
- Documentation
  - Swagger
  
## Documentation

To access the documentation navigate to the endpoint /swagger
  
## Getting Started

### Prerequisites

To run this project in the development mode, you'll need to have a basic environment to run a .NET Core Application. You can get it [here](https://dotnet.microsoft.com/download).

### Installing

**Cloning the Repository**

```
$ git clone https://github.com/brunoalves9698/publicutility.git

$ cd publicutility
```

### Configuring the Database

Go to the [https://github.com/brunoalves9698/PublicUtility/blob/master/src/PublicUtility.Api/appsettings.json](https://github.com/brunoalves9698/publicutility/blob/master/src/publicutility.Api/appsettings.Development.json) file and edit the 'Server' value into 'connectionString' key for the SqlServer of your machine.

It should looks like this:

"connectionString": "Server=YOUR_SQL_SERVER_PROVIDER\SQLEXPRESS;DataBase=MovieCine;Trusted_Connection=true;"

### Running

With all dependencies installed and the environment properly configured, you can now run the app:

```
$ dotnet run 
```

## Built With

- [.NET Core 3](https://docs.microsoft.com/pt-br/dotnet/core/)
- [EF Core 3](https://docs.microsoft.com/pt-br/ef/core/get-started/?tabs=netcore-cli)
