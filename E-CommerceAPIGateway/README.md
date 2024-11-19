# API Gateway 

## Overview

The API Gateway built with Ocelot serves as a centralized entry point for accessing and managing the User, Product, and Purchase microservices. It handles routing and aggregation of microservices' functionalities.

## Endpoints

The API Gateway exposes endpoints to access the functionalities provided by the underlying microservices.

### User Microservice

**Access Swagger UI:** `http://localhost:5039/swagger`

- **Create User Account**
  - **Endpoint:** `POST` `/api/user`
  - **Description:** Creates a new user account.

- **Get All Users**
  - **Endpoint:** `GET` `/api/user`
  - **Description:** Retrieves a list of all user accounts.

Refer to the User Microservice for additional user-related endpoints.

### Product Microservice

**Access Swagger UI:** `http://localhost:5039/swagger`

- **Create Product**
  - **Endpoint:** `POST` `/api/product`
  - **Description:** Creates a new product.

- **Get All Products**
  - **Endpoint:** `GET` `/api/product`
  - **Description:** Retrieves a list of all products.

Refer to the Product Microservice for additional product-related endpoints.

## Installation

### Prerequisites

Ensure that you have the following prerequisites installed on your machine:
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started)

### Setup

**1. Clone the repository:**
  ```bash
   git clone https://github.com/Jayalakshmi30/E-CommerceApiGateway
   cd E-CommerceApiGateway
   ```

**2.Build and Run the application locally:**
  ```bash
   dotnet build
   dotnet run
   ```