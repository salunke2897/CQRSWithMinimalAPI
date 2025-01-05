
# CQRS with Minimal API

This project demonstrates a basic implementation of the Command and Query Responsibility Segregation (CQRS) pattern with Minimal API in a .NET Core application. It uses MediatR for handling commands and queries, Entity Framework Core for database interaction, and Swagger for API documentation.




## Features

- CQRS Pattern: Separates read and write operations.
- Minimal API
- Entity Framework Core: Provides data persistence.
- Dependency Injection: Built-in support for DI.
- Swagger Integration: Interactive API documentation.

## Prerequisites

- .NET 9 SDK
- SQL Server


## Getting Started

1.Clone the Repository

```bash
git clone <repository-url>
cd CQRSWithMinimalAPI
```
2.Restore Dependencies

```bash
dotnet restore
```
3.Configure the Database

Update the connection string in appsettings.json (located in the API project):

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CQRSWithMinimalAPIDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```
Ensure the SQL Server service is running on your machine.

4.Apply Migrations

Run the following commands to create and apply migrations:
```bash
dotnet ef migrations add InitialCreate --project CQRSWithMinimalAPI.Infrastructure --startup-project CQRSWithMinimalAPI.API
dotnet ef database update --project CQRSWithMinimalAPI.Infrastructure --startup-project CQRSWithMinimalAPI.API
```
5.Run the Application
```bash
dotnet run --project CQRSWithMinimalAPI.API
```
The API will be available at http://localhost:<port>.

## Project Structure
```bash
CQRSWithMinimalAPI
│
├── CQRSWithMinimalAPI.API
│   ├── Controllers
│   ├── Program.cs
│   ├── appsettings.json
│
├── CQRSWithMinimalAPI.Application
│   ├── Commands
│   ├── Queries
│   ├── Interfaces
│
├── CQRSWithMinimalAPI.Domain
│   ├── Entities
│   ├── Common
│   ├── Events
│
├── CQRSWithMinimalAPI.Infrastructure
│   ├── Persistence
│   ├── Repositories
│   ├── Migrations
```
