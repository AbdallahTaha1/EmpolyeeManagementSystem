# Employee Management System

This is a full-stack **Employee Management System** built with:

- **Backend**: ASP.NET Core Web API (C#)
- **Frontend**: Angular, Bootstrap
- **Database**: Entity Framework Core with SQL Server

## Features

- Create, Read, Update, and Delete (CRUD) employees
- Pagination and Search support on the employee list
- Form validation for employee data
- Backend search with filtering by employee name
- Database auto-initialized with 50 sample employees

---

## Getting Started

### Requirements

- Visual Studio 2022+
- .NET 6 or higher
- Node.js (v18+ recommended)
- Angular CLI

---

## Running the Project

To run both the backend and frontend:

1. **Open the solution in Visual Studio**.
2. Set the **solution** to start both the API and the Angular app (this is usually already configured).
3. Click **Start** (`F5` or green play button).

The API and frontend will launch together.

> 🔄 **Important:** If the **frontend loads before the backend** is fully ready, you might get a blank screen or API error. In that case, simply **refresh the browser** after a few seconds.

---

## API Information

- Base URL: `https://localhost:7004/api/Employee`
- Supports:
  - `GET /api/Employee?pageNumber=1&pageSize=10&search=John`
  - `POST /api/Employee`
  - `PUT /api/Employee/{id}`
  - `DELETE /api/Employee/{id}`

---

## Database Setup

- **No manual migration is required.**
- The database is created automatically on first run.
- It includes **50 pre-seeded employee records** for demo/testing.

---

## Folder Structure
<pre>
EmpolyeeManagementSystem/
├── EmpolyeeManagementSystem.Server/           # Backend - ASP.NET Core Web API
│   ├── Controllers/                           # API controllers
│   ├── DTOs/                                  # Data Transfer Objects
│   ├── Models/                                # Entity models
│   ├── Services/                              # Business logic services
│   ├── Data/                                  # Database context and initializer
│   │   ├── ApplicationDbContext.cs            # EF Core database context
│   │   └── DbInitializer.cs                   # Seeds initial data
│   ├── Program.cs                             # Application entry point
│   └── ...                                    # Other backend files
├── empolyeemanagementsystem.client/           # Frontend - Angular application
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/                    # Angular components (e.g., employee list, form)
│   │   │   ├── services/                      # Angular services (API calls)
│   │   │   └── models/                        # TypeScript interfaces/models
│   │   ├── assets/                            # Static assets
│   │   ├── index.html                         # Main HTML file
│   │   └── main.ts                            # Angular entry point
│   ├── angular.json                           # Angular project configuration
│   └── ...                                    # Other frontend files
├── EmpolyeeManagementSystem.sln               # Visual Studio solution file
├── .gitignore                                 # Git ignore file
└── README.md                                  # Project documentation

</pre>

---

## Author

Developed as part of a learning project to demonstrate full-stack CRUD with pagination, filtering, and validation.
