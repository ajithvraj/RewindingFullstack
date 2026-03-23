# 🛒 Product Management API

A clean and scalable ASP.NET Core Web API built using Clean Architecture principles.
This project demonstrates professional backend development practices including layered architecture, DTO usage, global exception handling, and structured API responses.

---

## 🚀 Features

* ✅ CRUD operations for Products
* ✅ Clean Architecture (API → Application → Infrastructure → Domain)
* ✅ Repository Pattern
* ✅ Service Layer (business logic separation)
* ✅ DTOs for request/response handling
* ✅ Global Exception Handling Middleware
* ✅ Standard API Response Format
* ✅ Pagination support
* ✅ Logging with ILogger

---

## 🏗️ Architecture

```
Controller → Service → Repository → Database
```

### Layers:

* **API Layer** → Controllers, Middleware
* **Application Layer** → Services, Interfaces, DTOs, ApiResponse
* **Domain Layer** → Entities
* **Infrastructure Layer** → Database & Repository Implementation

---

## 🧰 Tech Stack

* ASP.NET Core Web API (.NET 8)
* Entity Framework Core
* SQL Server
* C#
* Git & GitHub

---

## 📂 Project Structure

```
ProductManagement.Api/
ProductManagement.Application/
ProductManagement.Domain/
ProductManagement.Infrastructure/
```

---

## ⚙️ Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/yourrepo.git
   ```

2. Navigate to project:
   ```bash
   cd ProductManagement.Api
   ```

3. Update connection string in:
   ```
   appsettings.json
   ```

4. Run the project:
   ```bash
   dotnet run
   ```

5. Open Swagger:
   ```
   [https://localhost:xxxx/swagger](https://localhost:xxxx/swagger)
   ```

---

## 📌 API Base URL

```
/api/products
```

---

## 📊 API Response Format

```json
{
"success": true,
"message": "Request successful",
"data": {},
"errors": null
}
```

---

## 👨‍💻 Author

**Ajith V Raj**

* GitHub: https://github.com/ajithvraj
* LinkedIn: https://linkedin.com/in/ajith-v-raj-a02527208/

---
