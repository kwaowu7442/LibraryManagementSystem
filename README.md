# Library Management System

## ✔ Project Description
The **Library Management System** is a C# application that provides a digital interface for managing library resources. It allows users to handle a collection of books by performing standard administrative tasks through a structured menu interface, ensuring that library data is stored securely and updated in real-time using a local database.

## ✔ Features
The application implements full CRUD (Create, Read, Update, Delete) functionality:
*   **Add Book**: Register new books into the system with details like Title, Author, Genre, and Publication Year.
*   **View Books**: Display a comprehensive list of all books currently stored in the library database.
*   **Update Book**: Modify the details or availability status of an existing book record.
*   **Delete Book**: Permanently remove a book record from the system using its unique Item ID.

## ✔ Tech Used
*   **Language**: C# (.NET)
*   **Database**: SQLite (via `Microsoft.Data.Sqlite`)
*   **Architecture**: Object-Oriented Programming (OOP) with Inheritance (utilizing `LibraryItem` as a base class).

## ✔ How to Run
1.  **Clone or Download**: Ensure all `.cs` files and the `.csproj` file are in the same folder.
2.  **Open Terminal**: Navigate to the project directory.
3.  **Execute**: Run the command `dotnet run`.
4.  **Database**: The system will automatically initialize the SQLite database on first launch.

## ✔ YouTube Video Link
[Click here to watch the Project Demonstration](INSERT_YOUR_YOUTUBE_URL_HERE)

## ✔ Project Summary
This project demonstrates the practical application of **C# and SQLite** to build a functional management tool. By implementing **Inheritance**, the system cleanly separates general library item logic from specific book data. The use of a local database ensures data persistence, allowing the library's state to be saved even after the application closes. This project highlights core software engineering principles including database connectivity, CRUD operations, and user-centric console interface design.
