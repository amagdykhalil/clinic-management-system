# 🚑 clinic management system

## 🛠️ Technologies & Libraries

- **.NET 9** - Latest .NET framework
- **ASP.NET Core** - Web framework
- **Entity Framework Core** - ORM for data access
- **SQL Server** - Database engine
- **ASP.NET Identity** - User management system
- **JWT Authentication** - Token-based authentication
- **MediatR** - CQRS and mediator pattern implementation
- **Serilog with Seq** - Structured logging
- **Docker & Docker Compose** - Containerization
- **Azure Key Vault** - Secure secret management (optional)

## 📁 Solution Structure

```sh

  ├── CMS.sln
  ├── README.md
  ├── docker-compose.dcproj
  ├── docker-compose.override.yml # Docker Compose override for local development
  ├── docker-compose.yml
  ├── launchSettings.json
  ├── src
  │   ├── API                  # ASP.NET Core Web API project
  │   ├── Core
  │   │   ├── CMS.Application  # Application layer: business logic, CQRS, MediatR, validation
  │   │   └── CMS.Domain       # Domain layer: entities, enums, core business models
  │   └── Infrastructure
  │       ├── CMS.Infrastructure # Infrastructure services: email, authentication
  │       └── CMS.Persistence    # Persistence layer: Entity Framework, repositories, migrations
  │   ├── CMS.Shared           # Shared  email templates
  └── tests
      ├── CMS.IntegrationTests  # Integration tests for infrastructure and persistence layers
      ├── CMS.Tests.Common      # Shared test utilities and data generators
      └── CMS.UnitTests
```

## 📊 Logging

The application uses Serilog with Seq for structured logging. Logs can be viewed:

- Local Development: [http://localhost:5341](http://localhost:5341)
- Docker Environment: [http://localhost:8081](http://localhost:8081)

## 📚 API Documentation

The API documentation is available at:
`https://localhost:<port>/scalar/v1`
(where <port> corresponds to the running API port)

