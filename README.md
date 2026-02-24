# OnlineStore API – Clean Onion Architecture

A production-ready **ASP.NET Core Web API** built using Onion Architecture principles, implementing enterprise-level design patterns, JWT authentication, caching, and payment integration.

---

## 📌 Architecture Overview

This project follows **Onion Architecture** to ensure:

- Separation of concerns  
- Maintainability  
- Testability  
- Scalability  
- Loose coupling  

The project is divided into **4 main layers**:

---

## 🔷 Project Layers

### 1️⃣ Core Layer
- **Entities** – Domain models representing database tables  
- **DTOs** – Data Transfer Objects for API communication  
- **Interfaces**  
  - `IService` – Business service contracts  
  - `IRepository` – Repository contracts  
- **Specifications** – Reusable query specifications for repositories  

> Fully decoupled from EF Core or any infrastructure dependencies  

---

### 2️⃣ Services Layer
- Implements the **business logic**  
- Service classes that implement the `IService` interfaces  
- Handles mapping between **Core Layer** and **Repository Layer**  
- Can access current user info via **JWT claims**  

---

### 3️⃣ Repository Layer
- **Generic Repository Implementations**  
- **Unit of Work Pattern**  
- EF Core DbContexts:  
  - `AppDbContext` → Application data  
  - `IdentityDbContext` → Users & Roles management  
- Handles database persistence, queries, and migrations  

---

### 4️⃣ API Layer (Presentation Layer)
- RESTful **Controllers & Endpoints**  
- JWT **Authentication & Authorization**  
- Middleware (Error Handling, Logging, etc.)  
- **Swagger Documentation**  

---

## 🔐 Authentication & Authorization

- Uses **JWT (JSON Web Token)** for secure authentication  
- Features:  
  - User Login / Registration  
  - Token Generation  
  - Extract Current Logged-in User from Token  
  - Role-based access control  
  - Secure endpoints using `[Authorize]`  
- Current user info is accessed via claims in JWT  

---

## 🏗️ Patterns & Principles Used

- Onion Architecture  
- Generic Repository Pattern  
- Unit of Work Pattern  
- Specification Pattern  
- Dependency Injection  
- SOLID Principles  
- Clean Code Practices  

---

## ⚡ Technologies Used

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- Redis (Caching)  
- Stripe API (Payment Gateway)  
- AutoMapper  
- FluentValidation  
- Swagger  

---

## 🔴 Redis Caching

Redis is used for:

- Caching product listings  
- Reducing database load  
- Improving API response times  
- Time-based expiration strategy  

**Example:**

- Cache duration: 10 minutes  
- Key-based caching system  

> ⚠ Redis is an external service. It is **not included** in the project. You need to run Redis locally or via any preferred method.  

---

## 💳 Stripe Payment Integration

Secure online payments are handled using **Stripe API**.

Implemented features:

- Create Payment Intent  
- Confirm Payment  
- Handle Webhooks  
- Store Payment Status in Database  

---

## 🗄️ Database

- **Code First Approach**  
- Fluent API configurations  
- **Automatic database migration** on application startup  

### ✅ Auto Migration Feature

- Applies pending migrations automatically when the project runs  
- Ensures smooth developer setup  
- Removes need for manual migration commands during development  

> ⚠ **For production**, consider using a controlled migration deployment instead of automatic migrations.  

---
