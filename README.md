
# eCommerce Microservices

This project demonstrates the implementation of an eCommerce system using .NET 8 with a microservices architecture. It is designed to showcase skills with technologies and concepts such as MassTransit, RabbitMQ, MongoDB, SQL Server, and middleware/shared services in .NET.

## Project Structure

The solution consists of the following components:

### 1. eCommerce.ProductApi
- **Purpose:** Manages products (CRUD operations).
- **Database:** MongoDB.
- **Features:** Provides endpoints to create, read, update, and delete products.

### 2. eCommerce.OrderApi
- **Purpose:** Creates orders with products managed by ProductApi.
- **Database:** SQL Server.
- **Features:** Handles order creation and management.

### 3. eCommerce.SharedLibrary
- **Purpose:** Contains reusable components shared across the microservices, such as:
  - Standardized logging formats.
  - Middleware components.
  - Common services.

## Communication Between Services
The services communicate using **MassTransit** with **RabbitMQ** as the message broker, ensuring reliable and efficient asynchronous messaging.

## Technologies Used
- **.NET 8**
- **MongoDB** (for ProductApi)
- **SQL Server** (for OrderApi)
- **MassTransit** and **RabbitMQ** (for service communication)
- **Shared Middlewares and Services**

## Purpose of the Project
This project is a practical demonstration of my knowledge in:
- Building microservices in .NET.
- Integrating different databases (SQL Server and MongoDB).
- Using MassTransit with RabbitMQ for communication between microservices.
- Designing shared libraries for reusable components.

## How to Run
1. Ensure MongoDB and SQL Server are running and accessible.
2. Set up RabbitMQ as the message broker.
3. Build and run the solution.
4. Test the APIs using tools like Postman or Swagger UI.

---
*Created to demonstrate proficiency with microservices and .NET development.*
