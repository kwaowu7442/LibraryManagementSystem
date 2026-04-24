// ================================
// Name: Kwadwo Owusu
// Date: 23/04/2026
// Assignment:  - Library & Book Management System
// 
// ================================

using System;

namespace LibraryManagementSystem
{
    public class MenuService
    {
        private readonly LibraryDatabase _db;

        public MenuService(LibraryDatabase db)
        {
            _db = db;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("   Library & Book Management System");
            Console.WriteLine("==========================================");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n---- Main Menu ----------------------------");
                Console.WriteLine("  1. Add a Book");
                Console.WriteLine("  2. Search Books");
                Console.WriteLine("  3. View All Books");
                Console.WriteLine("  4. Checkout a Book");
                Console.WriteLine("  5. Return a Book");
                Console.WriteLine("  6. Manage Members");
                Console.WriteLine("  0. Exit");
                Console.Write("\nEnter choice: ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1": HandleAddBook();       break;
                    case "2": HandleSearchBooks();   break;
                    case "3": HandleViewAllBooks();  break;
                    case "4": HandleCheckoutBook();  break;
                    case "5": HandleReturnBook();    break;
                    case "6": HandleManageMembers(); break;
                    case "0":
                        Console.WriteLine("\nGoodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\n[!] Invalid selection. Try again.");
                        break;
                }
            }
        }

        private void HandleAddBook()
        {
            Console.WriteLine("\n-- Add New Book --");
            Console.Write("Title           : "); string title  = Console.ReadLine() ?? "";
            Console.Write("Author          : "); string author = Console.ReadLine() ?? "";
            Console.Write("Genre           : "); string genre  = Console.ReadLine() ?? "";
            Console.Write("Publication Year: "); int.TryParse(Console.ReadLine(), out int year);

            var book = new Book(0, title, author, genre, year);

            try
            {
                int newId = _db.AddBook(book);
                Console.WriteLine($"\n[OK] Book added with ID: {newId}");
            }
            catch (NotImplementedException)
            {
                book.DisplayInfo();
                Console.WriteLine("[i] Database not connected yet - Phase 2.");
            }
        }

        private void HandleSearchBooks()
        {
            Console.WriteLine("\n-- Search Books --");
            Console.WriteLine("  1. By Author");
            Console.WriteLine("  2. By Genre");
            Console.Write("Choice: ");
            string sub = Console.ReadLine() ?? "";

            try
            {
                if (sub == "1")
                {
                    Console.Write("Author: ");
                    var results = _db.SearchByAuthor(Console.ReadLine() ?? "");
                    results.ForEach(b => b.DisplayInfo());
                }
                else if (sub == "2")
                {
                    Console.Write("Genre: ");
                    var results = _db.SearchByGenre(Console.ReadLine() ?? "");
                    results.ForEach(b => b.DisplayInfo());
                }
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("[i] Database not connected yet - Phase 2.");
            }
        }

        private void HandleViewAllBooks()
        {
            Console.WriteLine("\n-- All Books --");
            try
            {
                var books = _db.GetAllBooks();
                if (books.Count == 0) { Console.WriteLine("No books found."); return; }
                books.ForEach(b => Console.WriteLine(b));
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("[i] Database not connected yet - Phase 2.");
            }
        }

        private void HandleCheckoutBook()
        {
            Console.WriteLine("\n-- Checkout Book --");
            Console.Write("Book ID   : "); int.TryParse(Console.ReadLine(), out int bookId);
            Console.Write("Member ID : "); int.TryParse(Console.ReadLine(), out int memberId);

            try
            {
                int recordId = _db.CheckoutBook(bookId, memberId);
                Console.WriteLine($"[OK] Checkout successful. Record ID: {recordId}");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("[i] Database not connected yet - Phase 2.");
            }
        }

        private void HandleReturnBook()
        {
            Console.WriteLine("\n-- Return Book --");
            Console.Write("Checkout Record ID: "); int.TryParse(Console.ReadLine(), out int recordId);

            try
            {
                _db.ReturnBook(recordId);
                Console.WriteLine("[OK] Book returned successfully.");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("[i] Database not connected yet - Phase 2.");
            }
        }

        private void HandleManageMembers()
        {
            Console.WriteLine("\n-- Member Management --");
            Console.WriteLine("  1. Add Member");
            Console.WriteLine("  2. View All Members");
            Console.Write("Choice: ");
            string sub = Console.ReadLine() ?? "";

            if (sub == "1")
            {
                Console.Write("Name  : "); string name  = Console.ReadLine() ?? "";
                Console.Write("Email : "); string email = Console.ReadLine() ?? "";
                Console.Write("Phone : "); string phone = Console.ReadLine() ?? "";

                var member = new Member(0, name, email, phone);
                try
                {
                    int newId = _db.AddMember(member);
                    Console.WriteLine($"[OK] Member added with ID: {newId}");
                }
                catch (NotImplementedException)
                {
                    member.DisplayInfo();
                    Console.WriteLine("[i] Database not connected yet - Phase 2.");
                }
            }
            else if (sub == "2")
            {
                try
                {
                    var members = _db.GetAllMembers();
                    members.ForEach(m => Console.WriteLine(m));
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("[i] Database not connected yet - Phase 2.");
                }
            }
        }
    }
}