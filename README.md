

--- D R A F T  -----------------------------

## 🧾 Project Description

### 📦 **Auctions App**

This is a full-stack application for managing online auctions. It includes:

* **Backend**: ASP.NET Core Web API with Entity Framework Core and MS SQL Server
* **Frontend**: React + TypeScript (Vite) with Redux Toolkit
* **DevOps**: Version control via Azure DevOps (repository, tasks, CI/CD planned)

---

### 🗂️ **Solution Structure**

```
Auctions/
├── api/         → ASP.NET Core Web API
├── front/       → React + TypeScript frontend
├── docs/        → Flow diagrams, architecture notes
```

---

### 🧩 **Backend: API (.NET Core)**

* Uses **EF Core Code First** with **SQL Server LocalDB**
* Entities mapped via **DTOs** using **AutoMapper**
* Controllers follow RESTful conventions (`GET`, `POST`, `PUT`, `DELETE`)
* Swagger enabled for API testing

---

### 🔢 **Database Model**

#### 🔸 Level 1 (Entities)

| Table      | Fields                          |
| ---------- | ------------------------------- |
| `Auctions` | Id, Name, AuctionDate           |
| `Products` | Id, Name, Category, Subcategory |
| `Sellers`  | Id, Name, Email                 |
| `Buyers`   | Id, Name, Email                 |

#### 🔹 Level 2 (Relations)

| Table            | Description                                                            |
| ---------------- | ---------------------------------------------------------------------- |
| `InitialOffers`  | AuctionId, ProductId, SellerId, StartPrice                             |
| `TradeResults`   | AuctionId, ProductId, SellerId, BuyerId, FinalPrice                    |
| `TradeProcesses` | AuctionId, ProductId, BuyerId, OfferedPrice, OfferedAt, IsWinningOffer |

---

### 💻 **Frontend: Vite + React + Redux Toolkit**

* Vite-based fast React setup
* Redux Toolkit for state management
* Axios for API integration
* TypeScript used throughout

---

### 🧪 **Current Functionality**

* ✅ Auctions API: implemented with DTO and AutoMapper
* ✅ Swagger tested
* ✅ React + Redux + Axios app scaffolding complete

---
Вот, Александр Петрович, чёткий и лаконичный блок **“How to Run”** для `README.md`, чтобы сразу было понятно, как запустить **и API, и frontend**.

---

## 🚀 How to Run

### 🔧 Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* [Node.js (v18+)](https://nodejs.org/)
* [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

---

### 🟦 Backend (ASP.NET Core API)

```bash
cd api
dotnet restore
dotnet ef database update    # Apply EF Core migrations and create DB
dotnet run
```

API will be available at:
`https://localhost:PORT/swagger`

> Replace `PORT` with the actual port printed in the console.

---

### 🟦 Frontend (Vite + React + Redux)

```bash
cd front
npm install
npm run dev
```

Frontend will be available at:
`http://localhost:5173`

> Ensure the backend is running before accessing pages that use the API.

---

### 🔗 Connecting Frontend to API

In `front/.env` or config file, set:

```
VITE_API_URL=https://localhost:PORT
```

Use the correct `PORT` from backend launch (Swagger URL).

# Auctions App

Fullstack проект с CI/CD:

- ASP.NET Core API (.NET 8, SQLite)
- React + Vite + TypeScript
- Redux (будет)
- CI/CD: GitHub + Render (backend), Netlify (frontend)

## Deployment URLs

- 🌐 Frontend: https://dazzling-squirrel-8410b1.netlify.app
- 🛠 API: https://auctions-ajay.onrender.com/api/auctions



--- D R A F T  -----------------------------