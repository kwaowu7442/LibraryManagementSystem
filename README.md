Project Name: Library Management System
Project Description
The Library Management System is a C# console application designed to provide an intuitive experience for managing book collections. It allows users to perform CRUD operations—adding, viewing, updating, and deleting books—using a persistent SQLite database to ensure data is saved across sessions.  

Project Tasks
Task 1: Set up the development environment

Install .NET SDK and VS Code.

Configure SQLite libraries (Microsoft.Data.Sqlite).

Task 2: Design the application

Plan the class hierarchy (Base class LibraryItem and derived class Book).

Design the SQLite database schema (Books, Members, and Checkouts tables).

Task 3: Develop the Data Layer

Implement LibraryDatabase.cs to handle connection strings and SQL commands.

Create initialization logic to generate the .db file automatically.

Task 4: Develop the Logic and Models

Create the Book.cs model with inheritance logic.

Implement the MenuService.cs to handle user input and navigation.

Task 5: Test and Debug

Verify naming consistency between ItemId (code) and BookId (SQL).

Perform integration testing to ensure books are correctly saved and deleted.

Task 6: Document the project

Create a comprehensive README file.

Upload project to GitHub and record a video demonstration.

Project Skills Learned
Backend development with C# and .NET.

Database management with SQLite and SQL queries.

Object-Oriented Programming (OOP) principles like Inheritance and Abstraction.

Version control with Git and GitHub.

Troubleshooting compiler errors (like CS0103) and debugging data flow.

Language Used
C#: For core logic and object-oriented structure.

SQL (SQLite): For persistent data storage and retrieval.

Development Process Used
Iterative Development: Focus on building the database connection first, followed by individual features like "Add" and "Delete," with continuous testing between steps.

Notes
Ensure the Microsoft.Data.Sqlite package is installed via NuGet before running.

Use dotnet run to launch the application from the project folder.

Link to Project
https://github.com/kwaowu7442/LibraryManagementSystem

YouTube Video Link
Watch the Demonstration Here
