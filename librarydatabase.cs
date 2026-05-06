// ================================
// Name: Kwadwo Owusu
// Date: 02/05/2026
// Assignment: Library & Book Management System
//
// Description: Handles all SQLite database operations for the
// Library Management System including Books, Members, and
// Checkouts. Implements full CRUD functionality.
// ================================

using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace LibraryManagementSystem
{
    public class LibraryDatabase
    {
        private readonly string _connectionString;

        public LibraryDatabase(string dbPath = "library.db")
        {
            _connectionString = $"Data Source={dbPath}";
        }

        // ===============================
        // CONNECTION
        // ===============================
        private SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        // ===============================
        // INITIALIZE DATABASE
        // ===============================
        public void InitializeDatabase()
        {
            using var conn = GetConnection();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Books (
                    BookId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Author TEXT NOT NULL,
                    Genre TEXT NOT NULL,
                    PublicationYear INTEGER NOT NULL,
                    IsAvailable INTEGER NOT NULL DEFAULT 1
                );

                CREATE TABLE IF NOT EXISTS Members (
                    MemberId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Phone TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Checkouts (
                    RecordId INTEGER PRIMARY KEY AUTOINCREMENT,
                    BookId INTEGER NOT NULL,
                    MemberId INTEGER NOT NULL,
                    CheckoutDate TEXT NOT NULL,
                    ReturnDate TEXT,
                    FOREIGN KEY(BookId) REFERENCES Books(BookId),
                    FOREIGN KEY(MemberId) REFERENCES Members(MemberId)
                );";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("[Database] Initialized successfully.");
        }

        // =========================================================
        // BOOKS - CRUD
        // =========================================================

        // CREATE
        public int AddBook(Book book)
        {
            using var conn = GetConnection();

            string sql = @"
                INSERT INTO Books (Title, Author, Genre, PublicationYear, IsAvailable)
                VALUES (@title, @author, @genre, @year, 1);
                SELECT last_insert_rowid();";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@genre", book.Genre);
            cmd.Parameters.AddWithValue("@year", book.PublicationYear);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // READ ALL
        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using var conn = GetConnection();

            string sql = "SELECT * FROM Books ORDER BY BookId;";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                books.Add(new Book(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt32(4),
                    reader.GetInt32(5) == 1
                ));
            }

            return books;
        }

        // UPDATE (FULL UPDATE FIXED)
        public void UpdateBook(Book book)
        {
            using var conn = GetConnection();

            string sql = @"
                UPDATE Books
                SET Title = @title,
                    Author = @author,
                    Genre = @genre,
                    PublicationYear = @year,
                    IsAvailable = @available
                WHERE BookId = @id;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@genre", book.Genre);
            cmd.Parameters.AddWithValue("@year", book.PublicationYear);
            cmd.Parameters.AddWithValue("@available", book.IsAvailable ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", book.ItemId);

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void DeleteBook(int bookId)
        {
            using var conn = GetConnection();

            string sql = "DELETE FROM Books WHERE BookId = @id;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", bookId);

            cmd.ExecuteNonQuery();
        }

        // =========================================================
        // MEMBERS
        // =========================================================

        public int AddMember(Member member)
        {
            using var conn = GetConnection();

            string sql = @"
                INSERT INTO Members (Name, Email, Phone)
                VALUES (@name, @email, @phone);
                SELECT last_insert_rowid();";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", member.Name);
            cmd.Parameters.AddWithValue("@email", member.Email);
            cmd.Parameters.AddWithValue("@phone", member.Phone);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public List<Member> GetAllMembers()
        {
            var list = new List<Member>();

            using var conn = GetConnection();

            string sql = "SELECT * FROM Members ORDER BY MemberId;";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Member(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                ));
            }

            return list;
        }

        // =========================================================
        // CHECKOUTS
        // =========================================================

        public int CheckoutBook(int bookId, int memberId)
        {
            using var conn = GetConnection();

            string sql = @"
                INSERT INTO Checkouts (BookId, MemberId, CheckoutDate)
                VALUES (@bookId, @memberId, @date);
                SELECT last_insert_rowid();";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bookId", bookId);
            cmd.Parameters.AddWithValue("@memberId", memberId);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));

            int id = Convert.ToInt32(cmd.ExecuteScalar());

            // mark book unavailable
            string update = "UPDATE Books SET IsAvailable = 0 WHERE BookId = @bookId;";
            using var cmd2 = new SqliteCommand(update, conn);
            cmd2.Parameters.AddWithValue("@bookId", bookId);
            cmd2.ExecuteNonQuery();

            return id;
        }

        public void ReturnBook(int recordId)
        {
            using var conn = GetConnection();

            string sql = @"
                UPDATE Checkouts
                SET ReturnDate = @date
                WHERE RecordId = @id;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@id", recordId);
            cmd.ExecuteNonQuery();

            string updateBook = @"
                UPDATE Books
                SET IsAvailable = 1
                WHERE BookId = (
                    SELECT BookId FROM Checkouts WHERE RecordId = @id
                );";

            using var cmd2 = new SqliteCommand(updateBook, conn);
            cmd2.Parameters.AddWithValue("@id", recordId);
            cmd2.ExecuteNonQuery();
        }
    }
}