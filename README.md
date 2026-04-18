# WebApiShop

A RESTful API for an online shop built with **ASP.NET Core** and **.NET 9**.

## Architecture

The project follows a **3-layer architecture** with clear separation of concerns:

| Layer | Project | Responsibility |
|---|---|---|
| **Application** | `WebApiShop` | Controllers, middleware, configuration |
| **Services** | `Services` | Business logic |
| **Repositories** | `Repositories` | Data access via Entity Framework Core |
| **DTOs** | `DTOs` | Data Transfer Objects (records) |
| **Entities** | `Entities` | Database entity models |
| **Tests** | `TestProject` | Unit tests & integration tests |

Layers communicate through **dependency injection** for loose coupling. All data access is **asynchronous** to improve scalability.

## Tech Stack

- **.NET 9** / C# 13
- **ASP.NET Core** Web API
- **Entity Framework Core** (Database-First approach with SQL Server)
- **AutoMapper** – Entity ↔ DTO mapping
- **NLog** – Structured logging to file
- **Swagger / OpenAPI** – API documentation (development)

## API Endpoints

### Users
| Method | Route | Description |
|---|---|---|
| `GET` | `/api/Users` | Get all users |
| `GET` | `/api/Users/{id}` | Get user by ID |
| `POST` | `/api/Users` | Register a new user |
| `POST` | `/api/Users/Login` | Login with credentials |

### Products
| Method | Route | Description |
|---|---|---|
| `GET` | `/api/Products` | Get all products |
| `GET` | `/api/Products/Filter` | Get products with filtering & pagination |

### Categories
| Method | Route | Description |
|---|---|---|
| `GET` | `/api/Categories` | Get all categories |

### Orders
| Method | Route | Description |
|---|---|---|
| `GET` | `/api/Orders/{id}` | Get order by ID |
| `POST` | `/api/Orders` | Place a new order |

### Password
| Method | Route | Description |
|---|---|---|
| `POST` | `/api/Password/PasswordScore` | Evaluate password strength |

## Middleware

- **ErrorHandlingMiddleware** – Global exception handling; catches all unhandled exceptions, logs them via NLog, and returns a structured JSON error response with status 500.
- **RatingMiddleware** – Logs all incoming HTTP traffic (host, method, path, referer, user agent, timestamp) to a `Rating` table in the database for analytics.

## Database Entities

- **User** – UserId, FirstName, LastName, Email, Password, IsAdmin
- **Product** – ProductId, ProductName, Price, CategoryId, Description, ImageUrl
- **Category** – CategoryId, CategoryName
- **Order** – OrderId, OrderDate, OrderSum, UserId
- **OrderItem** – Links orders to products with quantities
- **Rating** – Stores HTTP request traffic data

## Configuration

Application settings are stored separately from code in `appsettings.json`:
- Connection strings for SQL Server
- Logging configuration

NLog configuration is defined in `nlog.config`.

## Testing

The project includes two types of tests:

- **Unit Tests** – Test individual components in isolation (e.g., `OrderRepositoryUnitTesting`, `CategoryRepositoryUnitTesting`, `UserRepositoryUnitTesting`)
- **Integration Tests** – Test components working together with a real database context via `DataBaseFixture` (e.g., `OrderRepositoryIntegrationTests`, `CategoryRepositoryIntegrationTests`, `UserRepositoyIntegrationTests`, `ProductRepositoryIntegrationTests`)
- **Validation Tests** – `OrderSumValidationTests` for verifying order sum calculations

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/Yocheved4427/WebApiShop.git
   ```

2. Update the connection string in `WebApiShop/appsettings.json` to point to your SQL Server instance.

3. Run the application:
   ```bash
   cd WebApiShop
   dotnet run --project WebApiShop
   ```

4. Open the Swagger UI at `https://localhost:<port>/swagger` to explore the API.

### Running Tests

```bash
dotnet test
```
