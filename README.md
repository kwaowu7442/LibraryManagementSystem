

# Project Name: Library Management System

## Project Description
The Library Management System is a C# console application designed to provide an intuitive experience for managing book collections. It allows users to perform CRUD operations,adding, viewing, updating, and deleting books, using a persistent SQLite database to ensure data is saved across sessions.

## Project Tasks
- **Task 1: Set up the development environment**[cite: 1]
  - Install .NET SDK and VS Code[cite: 1].
  - Configure SQLite libraries (`Microsoft.Data.Sqlite`)[cite: 1].
- **Task 2: Design the application**[cite: 1]
  - Plan the class hierarchy (Base class `LibraryItem` and derived class `Book`)[cite: 1].
  - Design the SQLite database schema[cite: 1].
- **Task 3: Develop the Data Layer**[cite: 1]
  - Implement `LibraryDatabase.cs` to handle connection strings and SQL commands[cite: 1].
  - Create initialization logic to generate the `.db` file automatically[cite: 1].
- **Task 4: Develop the Logic and Models**[cite: 1]
  - Create the `Book.cs` model with inheritance logic[cite: 1].
  - Implement the `MenuService.cs` to handle user input and navigation[cite: 1].
- **Task 5: Test and Debug**[cite: 1]
  - Verify naming consistency between `ItemId` (code) and `BookId` (SQL)[cite: 1].
  - Perform integration testing to ensure books are correctly saved and deleted[cite: 1].
- **Task 6: Document the project**[cite: 1]
  - Create a comprehensive README file[cite: 1].
  - Upload project to GitHub and record a video demonstration[cite: 1].

## Project Skills Learned
- Backend development with C# and .NET[cite: 1].
- Database management with SQLite and SQL queries[cite: 1].
- Object-Oriented Programming (OOP) principles like Inheritance and Abstraction[cite: 1].
- Version control with Git and GitHub[cite: 1].
- Troubleshooting compiler errors (like CS0103) and debugging data flow[cite: 1].

## Language Used
- **C#**: For core logic and object-oriented structure[cite: 1].
- **SQL (SQLite)**: For persistent data storage and retrieval[cite: 1].

## Development Process Used
- **Iterative Development**: Focus on building the database connection first, followed by individual features like "Add" and "Delete," with continuous testing between steps.

## Notes
- Ensure the `Microsoft.Data.Sqlite` package is installed via NuGet before running[cite: 1].
- Use `dotnet run` to launch the application from the project folder[cite: 1].

## Link to Project
[LibraryManagementSystem Repository](https://github.com/kwaowu7442/LibraryManagementSystem)[cite: 1]

## YouTube Video Link
[Watch the Demonstration Here](INSERT_YOUR_URL_HERE)[cite: 1]

