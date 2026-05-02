// ================================
// Name: Kwadwo Owusu
// Date: 02/05/2026
// Assignment: Library & Book Management System
//
// Description: LibraryDatabase class that handles all SQLite database
//              interactions for the Library Management System.
//              Implements CRUD operations for Books, Members, and
//              Checkout records. Creates and manages the database
//              connection and all three tables.
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

        // Returns a new open SQLite connection
        private SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        // Creates all three tables if they do not already exist
        public void InitializeDatabase()
        {
            using var conn = GetConnection();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Books (
                    BookId          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title           TEXT    NOT NULL,
                    Author          TEXT    NOT NULL,
                    Genre           TEXT    NOT NULL,
                    PublicationYear INTEGER NOT NULL,
                    IsAvailable     INTEGER NOT NULL DEFAULT 1
                );

                CREATE TABLE IF NOT EXISTS Members (
                    MemberId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name     TEXT NOT NULL,
                    Email    TEXT NOT NULL,
                    Phone    TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Checkouts (
                    RecordId     INTEGER PRIMARY KEY AUTOINCREMENT,
                    BookId       INTEGER NOT NULL,
                    MemberId     INTEGER NOT NULL,
                    CheckoutDate TEXT    NOT NULL,
                    ReturnDate   TEXT,
                    FOREIGN KEY (BookId)   REFERENCES Books(BookId),
                    FOREIGN KEY (MemberId) REFERENCES Members(MemberId)
                );";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("[Database] Tables initialized successfully.");
        }

        // ── Books ──────────────────────────────────────────────────────

        // Insert a new book and return its generated ID
        public int AddBook(Book book)
        {
            using var conn = GetConnection();

            string sql = @"
                INSERT INTO Books (Title, Author, Genre, PublicationYear, IsAvailable)
                VALUES (@title, @author, @genre, @year, 1);
                SELECT last_insert_rowid();";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@title",  book.Title);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@genre",  book.Genre);
            cmd.Parameters.AddWithValue("@year",   book.PublicationYear);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Retrieve all books from the database
        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using var conn = GetConnection();

            string sql = "SELECT BookId, Title, Author, Genre, PublicationYear, IsAvailable FROM Books ORDER BY BookId;";

            using var cmd    = new SqliteCommand(sql, conn);
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

        // Search books by author name (partial match)
        public List<Book> SearchByAuthor(string author)
        {
            var books = new List<Book>();
            using var conn = GetConnection();

            string sql = "SELECT BookId, Title, Author, Genre, PublicationYear, IsAvailable FROM Books WHERE Author LIKE @author ORDER BY BookId;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@author", $"%{author}%");

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

        // Search books by genre (partial match)
        public List<Book> SearchByGenre(string genre)
        {
            var books = new List<Book>();
            using var conn = GetConnection();

            string sql = "SELECT BookId, Title, Author, Genre, PublicationYear, IsAvailable FROM Books WHERE Genre LIKE @genre ORDER BY BookId;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@genre", $"%{genre}%");

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

        // Update a book's availability status (1 = available, 0 = checked out)
        public void UpdateBookAvailability(int bookId, bool isAvailable)
        {
            using var conn = GetConnection();

            string sql = "UPDATE Books SET IsAvailable = @isAvailable WHERE BookId = @bookId;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@isAvailable", isAvailable ? 1 : 0);
            cmd.Parameters.AddWithValue("@bookId",      bookId);
            cmd.ExecuteNonQuery();
        }

        // Delete a book from the database by its ID
        public void DeleteBook(int bookId)
        {
            using var conn = GetConnection();

            string sql = "DELETE FROM Books WHERE BookId = @bookId;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bookId", bookId);
            cmd.ExecuteNonQuery();
        }

        // ── Members ────────────────────────────────────────────────────

        // Insert a new member and return their generated ID
        public int AddMember(Member member)
        {
            using var conn = GetConnection();

            string sql = @"
                INSERT INTO Members (Name, Email, Phone)
                VALUES (@name, @email, @phone);
                SELECT last_insert_rowid();";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name",  member.Name);
            cmd.Parameters.AddWithValue("@email", member.Email);
            cmd.Parameters.AddWithValue("@phone", member.Phone);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Retrieve all members from the database
        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();
            using var conn = GetConnection();

            string sql = "SELECT MemberId, Name, Email, Phone FROM Members ORDER BY MemberId;";

            using var cmd    = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                members.Add(new Member(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                ));
            }

            return members;
        }

        // Retrieve a single member by their ID; returns null if not found
        public Member? GetMemberById(int memberId)
        {
            using var conn = GetConnection();

            string sql = "SELECT MemberId, Name, Email, Phone FROM Members WHERE MemberId = @memberId;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@memberId", memberId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Member(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                );
            }

            return null;
        }

        // ── Checkouts ──────────────────────────────────────────────────

        // Record a checkout: marks the book unavailable and inserts a checkout record
        public int CheckoutBook(int bookId, int memberId)
        {
            using var conn = GetConnection();

            string insertSql = @"
                INSERT INTO Checkouts (BookId, MemberId, CheckoutDate)
                VALUES (@bookId, @memberId, @date);
                SELECT last_insert_rowid();";

            using var insertCmd = new SqliteCommand(insertSql, conn);
            insertCmd.Parameters.AddWithValue("@bookId",   bookId);
            insertCmd.Parameters.AddWithValue("@memberId", memberId);
            insertCmd.Parameters.AddWithValue("@date",     DateTime.Now.ToString("yyyy-MM-dd"));
            int recordId = Convert.ToInt32(insertCmd.ExecuteScalar());

            string updateSql = "UPDATE Books SET IsAvailable = 0 WHERE BookId = @bookId;";
            using var updateCmd = new SqliteCommand(updateSql, conn);
            updateCmd.Parameters.AddWithValue("@bookId", bookId);
            updateCmd.ExecuteNonQuery();

            return recordId;
        }

        // Record a return: sets the return date and marks the book available again
        public void ReturnBook(int recordId)
        {
            using var conn = GetConnection();

            string updateCheckout = "UPDATE Checkouts SET ReturnDate = @date WHERE RecordId = @recordId;";
            using var cmd1 = new SqliteCommand(updateCheckout, conn);
            cmd1.Parameters.AddWithValue("@date",     DateTime.Now.ToString("yyyy-MM-dd"));
            cmd1.Parameters.AddWithValue("@recordId", recordId);
            cmd1.ExecuteNonQuery();

            string updateBook = @"
                UPDATE Books SET IsAvailable = 1
                WHERE BookId = (SELECT BookId FROM Checkouts WHERE RecordId = @recordId);";
            using var cmd2 = new SqliteCommand(updateBook, conn);
            cmd2.Parameters.AddWithValue("@recordId", recordId);
            cmd2.ExecuteNonQuery();
        }

        // Retrieve all checkout records for a specific member
        public List<CheckoutRecord> GetCheckoutsByMember(int memberId)
        {
            var records = new List<CheckoutRecord>();
            using var conn = GetConnection();

            string sql = @"
                SELECT c.RecordId, c.CheckoutDate, c.ReturnDate,
                       b.BookId, b.Title, b.Author, b.Genre, b.PublicationYear, b.IsAvailable,
                       m.MemberId, m.Name, m.Email, m.Phone
                FROM Checkouts c
                JOIN Books   b ON c.BookId   = b.BookId
                JOIN Members m ON c.MemberId = m.MemberId
                WHERE c.MemberId = @memberId
                ORDER BY c.RecordId;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@memberId", memberId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var book = new Book(
                    reader.GetInt32(3), reader.GetString(4), reader.GetString(5),
                    reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8) == 1);

                var member = new Member(
                    reader.GetInt32(9), reader.GetString(10),
                    reader.GetString(11), reader.GetString(12));

                DateTime checkoutDate = DateTime.Parse(reader.GetString(1));
                DateTime? returnDate  = reader.IsDBNull(2) ? null : DateTime.Parse(reader.GetString(2));

                records.Add(new CheckoutRecord(reader.GetInt32(0), book, member, checkoutDate, returnDate));
            }

            return records;
        }

        // Retrieve all checkout records that have not been returned yet
        public List<CheckoutRecord> GetActiveCheckouts()
        {
            var records = new List<CheckoutRecord>();
            using var conn = GetConnection();

            string sql = @"
                SELECT c.RecordId, c.CheckoutDate, c.ReturnDate,
                       b.BookId, b.Title, b.Author, b.Genre, b.PublicationYear, b.IsAvailable,
                       m.MemberId, m.Name, m.Email, m.Phone
                FROM Checkouts c
                JOIN Books   b ON c.BookId   = b.BookId
                JOIN Members m ON c.MemberId = m.MemberId
                WHERE c.ReturnDate IS NULL
                ORDER BY c.RecordId;";

            using var cmd    = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var book = new Book(
                    reader.GetInt32(3), reader.GetString(4), reader.GetString(5),
                    reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8) == 1);

                var member = new Member(
                    reader.GetInt32(9), reader.GetString(10),
                    reader.GetString(11), reader.GetString(12));

                DateTime checkoutDate = DateTime.Parse(reader.GetString(1));

                records.Add(new CheckoutRecord(reader.GetInt32(0), book, member, checkoutDate, null));
            }

            return records;
        }
    }
}