# To-Do Task Management Application


## Overview

A web-based To-Do task management application that allows users to register, log in, and perform CRUD operations (Create, Read, Update, Delete) on tasks. The backend is built using .NET API, while the frontend is developed with Angular.


## Technologies
- **Backend**: .NET Core 8
- **Database**: MS SQL
- **ORM**: Entity Framework Core
- **Architecture**: Clean Architecture
- **CQRS**: Command Query Responsibility Segregation
- **Authentication**: JWT (JSON Web Tokens)
- **Frontend**: Angular 18


## Getting Started

### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 8.0)
- [MS SQL Server](https://www.microsoft.com/en-us/sql-serversql-server-downloads) or compatible database
- [Node.js and npm](https://nodejs.org/en) for Angular setup
### Backend Setup (.NET API)


1. **Clone the Repository:**
    ```bash
    git clone https://github.com/nevein25/task-manager
    cd task-manager/src
    ```

2. **Configure the Connection String**
    - Update the `appsettings.json` file with your database connection string.

3. **Apply Database Migrations:**
      ```bash
      dotnet ef database update
      ```
4. **Run the Backend:**
      ```bash
      dotnet run
      ```
    - The API will be available at `https://localhost:7203`

### Fronend Setup (Angular)

1. **Navigate to the frontend folder:**
      ```bash
      cd src/client
      ```

2. **Install the required dependencies:**
      ```bash
      npm install
      ```

3. **Run the Angular Development Server:**
      ```bash
      ng serve
      ```

- The frontend should now be running at http://localhost:4200.