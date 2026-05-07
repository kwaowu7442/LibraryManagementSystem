# Project Name: Library Management System

## Project Description
Library Management System is a C# console application designed to provide users with an efficient way to manage a collection of library books. The system allows users to perform full CRUD operations, including adding new books, viewing all books, updating existing book details, and deleting books from the system. The application uses a SQLite database to store data, ensuring that all records remain saved even after the program is closed.

## Project Tasks
- **Task 1: Set up the development environment**
  - Install .NET SDK and Visual Studio Code
  - Configure SQLite library (Microsoft.Data.Sqlite)
- **Task 2: Design the application**
  - Plan the class structure using a base class (LibraryItem) and derived class (Book)
  - Design the SQLite database schema
- **Task 3: Develop the Data Layer**
  - Implement LibraryDatabase.cs to manage database connection and SQL operations
  - Create logic to initialize and generate the database file automatically
- **Task 4: Develop the Logic and Models**
  - Create Book.cs model using object-oriented principles
  - Implement MenuService.cs to handle user input and navigation
- **Task 5: Test and Debug**
  - Test all CRUD operations (Create, Read, Update, Delete)
  - Fix naming inconsistencies between C# and database fields (e.g., BookId vs ItemId)
  - Ensure proper integration between application and database
- **Task 6: Document the project**
  - Create a comprehensive README file
  - Upload project to GitHub
  - Record a video demonstration of the application

## Project Skills Learned
- C# console application development
- Object-Oriented Programming (inheritance, abstraction, polymorphism, composition)
- SQLite database integration and management
- CRUD operations implementation
- Debugging and error handling
- Git and GitHub version control
- Software documentation

## Language Used
- **C#**: For application logic and structure
- **SQL (SQLite)**: For database storage and management

## Development Process Used
- Iterative development approach focusing on building and testing each feature step by step, starting from database setup, then class design, followed by CRUD implementation and final integration with the user interface.

## Notes
- Ensure Microsoft.Data.Sqlite is installed before running the project
- Run the application using dotnet run from the project directory
- All CRUD operations should be tested through the console menu system

## Link to Project
[Library Management System Repository](https://github.com/kwaowu7442/LibraryManagementSystem)

## How its works
https://streamable.com/w5ucjx

## License
This project is for academic purposes and does not include a formal license.
