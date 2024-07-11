# Simple CRUD Task - PinewoodTask Application

## Overview

PinewoodTask is a sample application demonstrating the use of ASP.NET Core Web API with Entity Framework Core and Razor Pages. The application features a customer management system with both API endpoints and a Razor-based UI. The project also includes a Dapper-based repository for relational database operations.

## Project Structure

### 1. API
The API layer provides RESTful endpoints for managing customers. This layer is built using ASP.NET Core Web API and Swagger for API documentation.

### 2. Core
The Core layer contains the business logic and entity definitions. It includes:
- **Entities**: Definitions of data models (e.g., `Customer`).
- **DTOs**: Data Transfer Objects for transferring data between layers.
- **Interfaces**: Interface definitions for services and repositories.

### 3. Application
The Application layer implements the business logic and services. It includes:
- **Services**: Implementations of business logic using repositories.
- **Mappings**: AutoMapper configurations for mapping between entities and DTOs.

### 4. Infrastructure
The Infrastructure layer handles data access and repository implementations. It includes:
- **Repositories**: Implementations using both Entity Framework Core (InMemory) and Dapper for data access.
- **Database Context**: EF Core database context definition for InMemory database.

### 5. UI
The UI layer is an ASP.NET Core Razor Pages project providing a web interface for managing customers. It uses Bootstrap for styling.

## Features

### 1. API Endpoints
- **GET /Customer/{id}**: Retrieve a customer by ID.
- **GET /Customer**: Retrieve all customers with pagination.
- **POST /Customer/add**: Add a new customer.
- **POST /Customer/edit**: Edit an existing customer.
- **POST /Customer/delete**: Delete a customer by ID.

Swagger documentation is available for all API endpoints when running the API project.

### 2. Razor Pages
- **Index**: Display all customers in a table with options to add, edit, and delete.
- **Create**: Form to add a new customer.
- **Edit**: Form to edit an existing customer.
- **Delete**: Confirmation and deletion of a customer.

### 3. Database
- **InMemory Database**: The application uses Entity Framework Core InMemory database for data storage, which can be easily replaced with other database providers.
- **Dapper**: A separate repository implementation using Dapper for relational database operations.

## Running the Project

### Running the API with Swagger
1. Open the solution in your preferred IDE (e.g., Visual Studio).
2. Set the API project as the startup project.
3. Run the project.
4. Navigate to `http://localhost:<port>/swagger` to access the Swagger UI.

### Running the Razor UI
1. Open the solution in your preferred IDE (e.g., Visual Studio).
2. Set the UI project as the startup project.
3. Run the project.
4. Navigate to `http://localhost:<port>` to access the Razor Pages UI.

## Repository and Services

### Repositories
- **Entity Framework Core Repository**: Uses EF Core for data access and is configured with an InMemory database.
- **Dapper Repository**: Uses Dapper for data access, suitable for relational databases.

### Services
- The services layer uses the repositories to perform business logic and is consumed by the controllers in both API and UI layers.

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/your-username/PinewoodTask.git
    ```

2. Navigate to the project directory:
    ```sh
    cd PinewoodTask
    ```

3. Restore dependencies:
    ```sh
    dotnet restore
    ```

4. Run the project:
    - For API: Set the API project as the startup project and run.
    - For UI: Set the UI project as the startup project and run.
