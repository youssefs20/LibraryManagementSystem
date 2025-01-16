
# **Library Management System - ASP.NET Core MVC**

## **Table of Contents**
1. [Project Overview](#project-overview)
2. [Features](#features)
3. [Technologies Used](#technologies-used)
4. [Setup and Installation](#setup-and-installation)
5. [Project Structure](#project-structure)
6. [Usage](#usage)
7. [Authentication and Roles](#authentication-and-roles)
8. [Future Improvements](#future-improvements)

---

## **Project Overview**

The **Library Management System** is a web application built using ASP.NET Core MVC to manage book checkouts, returns, member management, and penalties for late returns. It is designed for both librarians and members, providing role-based access control.

---
## **Team Members**

1.  **George Medhat Makram Wessa**
2.  **Abdelrahman Ahmed Abdelrahman**
3.  **Ahmed Ibrahim Mohamed Ibrahim** 
4.  **Bishoy Maged Makram Wessa**
5.  **Karin Kheir Abdallah**
6.  **Youssef Sameh Mohamed**
---
## **Features**

- **Book Management**: Add, edit, delete, and view books in the library.
- **Member Management**: Register, view, and manage members.
- **Checkout and Return**: Handle the checkout and return of books, with due date tracking.
- **Penalty System**: Automatically calculate penalties for overdue returns.
- **Search**: Search and filter books by title, author, or genre.
- **User Authentication**: Role-based access for librarians and members.

---

## **Technologies Used**

- **ASP.NET Core MVC**: Backend framework for building the application.
- **Entity Framework Core**: ORM for database management and migrations.
- **SQL Server**: Database to store book, member, and transaction data.
- **Identity Server**: Used for user authentication and role-based access.
- **Bootstrap**: For responsive UI design.
- **C#**: Main programming language.

---

## **Setup and Installation**

### **Option 1: Using the Provided RAR File**
- Download the project as a `.rar` file (provided separately).
- Extract the `.rar` file to your preferred directory.
- Open the project in Visual Studio (or your preferred IDE).

### **Option 2: Cloning from Repository (Link will be provided later)**
- The link to the repository will be shared once available.

### **Prerequisites**
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or any IDE supporting .NET

### **Installation Steps**

1. **Open the Project**:
   - Extract the provided `.rar` file and open the solution in Visual Studio.

2. **Set Up the Database**:
   - In `appsettings.json`, configure the connection string to match your SQL Server instance:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=your_server_name;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```

3. **Run Migrations**:
   - Open the Package Manager Console in Visual Studio and run:
     ```bash
     update-database
     ```

4. **Run the Application**:
   - Press `F5` or use the following command to run the application:
     ```bash
     dotnet run
     ```

---

## **Project Structure**

### **Folders and Files**
- **/Controllers**: Contains all controllers for managing requests (e.g., `BookController.cs`, `MemberController.cs`).
- **/Models**: Contains all data models (e.g., `Book.cs`, `Member.cs`, `Checkout.cs`, `Penalty.cs`).
- **/Views**: Contains all Razor views for rendering the UI (e.g., `Views/Book/Index.cshtml`).
- **/Repositories**: Data access layer that interacts with the database.
- **/Migrations**: Entity Framework Core migrations to manage the database schema.

### **Key Files**
- **appsettings.json**: Configuration file for connection strings and app settings.
- **Startup.cs**: Configures services and the request pipeline.
- **Program.cs**: Main entry point of the application.

---

## **Usage**

### **Accessing the Application**

Once the application is running, you can access it via the browser:
- **Librarian Role**: Has full access to manage books, members, checkouts, and penalties.
- **Member Role**: Can view books, their borrowing history, and penalties.

### **Key Features**

1. **Manage Books**:
   - Go to `/Books` to view the list of books.
   - Add a new book by clicking the **Add Book** button.
   - Edit or delete a book by selecting the respective options.

2. **Manage Members**:
   - Go to `/Members` to view the list of members.
   - Add a new member, view their borrowing history, or edit their details.

3. **Checkout Books**:
   - Go to `/Checkouts` to manage book checkouts.
   - Select a book and member to complete the checkout process.

4. **Return Books**:
   - Go to `/Returns` to record book returns and calculate penalties if overdue.

5. **Search**:
   - Use the search bar on the **Books** page to find books by title, author, or genre.

---

## **Authentication and Roles**

- **Librarian Role**: Librarians have administrative privileges to manage books, members, checkouts, returns, and penalties.
- **Member Role**: Members can only view available books, their borrowing history, and penalties.

You can create new users through the registration page, with role assignments managed by the administrator.

---

## **Future Improvements**

- **Notifications**: Add email or SMS notifications for overdue books or upcoming due dates.
- **Advanced Search**: Add more search filters, such as by publication year or book category.
- **Analytics**: Include reporting features to track borrowing trends, popular books, etc.
- **UI Enhancements**: Improve UI/UX for better navigation and user experience.

---

## **Conclusion**

This documentation provides an overview of the **Library Management System**, outlining the key features, setup instructions, and structure of the project. Use the provided `.rar` file to access the project files and follow the setup instructions to get started.

