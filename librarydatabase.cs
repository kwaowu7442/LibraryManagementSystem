// ================================
// Name: Kwadwo Owusu
// Date: 23/04/2026
// Assignment:  - Library & Book Management System
// 
// ================================

using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class LibraryDatabase
    {
        private readonly string _connectionString;

        public LibraryDatabase(string dbPath = "library.db")
        {
            _connectionString = $"Data Source={dbPath}";
        }

        // ── Books ──────────────────────────────────────

        public int AddBook(Book book)
        {
            // TODO Phase 2: INSERT INTO Books (Title, Author, Genre, PublicationYear, IsAvailable)
            //               VALUES (@title, @author, @genre, @year, 1);
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public List<Book> GetAllBooks()
        {
            // TODO Phase 2: SELECT * FROM Books;
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public List<Book> SearchByAuthor(string author)
        {
            // TODO Phase 2: SELECT * FROM Books WHERE Author LIKE '%@author%';
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public List<Book> SearchByGenre(string genre)
        {
            // TODO Phase 2: SELECT * FROM Books WHERE Genre LIKE '%@genre%';
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public void UpdateBookAvailability(int bookId, bool isAvailable)
        {
            // TODO Phase 2: UPDATE Books SET IsAvailable = @isAvailable WHERE BookId = @bookId;
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public void DeleteBook(int bookId)
        {
            // TODO Phase 2: DELETE FROM Books WHERE BookId = @bookId;
            throw new NotImplementedException("Coming in Phase 2.");
        }

        // ── Members ────────────────────────────────────

        public int AddMember(Member member)
        {
            // TODO Phase 2: INSERT INTO Members (Name, Email, Phone) VALUES (@name, @email, @phone);
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public List<Member> GetAllMembers()
        {
            // TODO Phase 2: SELECT * FROM Members;
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public Member GetMemberById(int memberId)
        {
            // TODO Phase 2: SELECT * FROM Members WHERE MemberId = @memberId;
            throw new NotImplementedException("Coming in Phase 2.");
        }

        // ── Checkouts ──────────────────────────────────

        public int CheckoutBook(int bookId, int memberId)
        {
            // TODO Phase 2:
            //   INSERT INTO Checkouts (BookId, MemberId, CheckoutDate) VALUES (@bookId, @memberId, @date);
            //   UPDATE Books SET IsAvailable = 0 WHERE BookId = @bookId;
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public void ReturnBook(int recordId)
        {
            // TODO Phase 2:
            //   UPDATE Checkouts SET ReturnDate = @date WHERE RecordId = @recordId;
            //   UPDATE Books SET IsAvailable = 1 WHERE BookId = (SELECT BookId FROM Checkouts WHERE RecordId = @recordId);
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public List<CheckoutRecord> GetCheckoutsByMember(int memberId)
        {
            // TODO Phase 2: SELECT * FROM Checkouts WHERE MemberId = @memberId;
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public List<CheckoutRecord> GetActiveCheckouts()
        {
            // TODO Phase 2: SELECT * FROM Checkouts WHERE ReturnDate IS NULL;
            throw new NotImplementedException("Coming in Phase 2.");
        }

        public void InitializeDatabase()
        {
            // TODO Phase 2: Create all three tables if they don't exist
            throw new NotImplementedException("Coming in Phase 2.");
        }
    }
}