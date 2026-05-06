// ================================
// Name: Kwadwo Owusu
// Date: 02/05/2026
// Assignment: Library & Book Management System
//
// Description: Handles all user interaction through the console.
//              Provides menu options and connects user actions
//              to the SQLite database via LibraryDatabase.
// ================================

using System;
using System.Collections.Generic;

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
                Console.WriteLine("  1. Add Book");
                Console.WriteLine("  2. View All Books");
                Console.WriteLine("  3. Update Book");
                Console.WriteLine("  4. Delete Book");
                Console.WriteLine("  0. Exit");
                Console.Write("\nEnter choice: ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ViewBooks();
                        break;
                    case "3":
                        UpdateBook();
                        break;
                    case "4":
                        DeleteBook();
                        break;
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

        // ===============================
        // ADD BOOK
        // ===============================
        private void AddBook()
        {
            Console.WriteLine("\n-- Add New Book --");

            Console.Write("Title           : ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Author          : ");
            string author = Console.ReadLine() ?? "";

            Console.Write("Genre           : ");
            string genre = Console.ReadLine() ?? "";

            Console.Write("Publication Year: ");
            int.TryParse(Console.ReadLine(), out int year);

            var book = new Book(0, title, author, genre, year, true);

            try
            {
                int id = _db.AddBook(book);
                Console.WriteLine($"\n[OK] Book added successfully with ID: {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] {ex.Message}");
            }
        }

        // ===============================
        // VIEW BOOKS
        // ===============================
        private void ViewBooks()
        {
            Console.WriteLine("\n-- All Books --");

            try
            {
                List<Book> books = _db.GetAllBooks();

                if (books.Count == 0)
                {
                    Console.WriteLine("No books found.");
                    return;
                }

                foreach (var book in books)
                {
                    book.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] {ex.Message}");
            }
        }

        // ===============================
        // UPDATE BOOK
        // ===============================
        private void UpdateBook()
        {
            Console.WriteLine("\n-- Update Book --");

            Console.Write("Book ID: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.Write("New Title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("New Author: ");
            string author = Console.ReadLine() ?? "";

            Console.Write("New Genre: ");
            string genre = Console.ReadLine() ?? "";

            Console.Write("New Publication Year: ");
            int.TryParse(Console.ReadLine(), out int year);

            var updatedBook = new Book(id, title, author, genre, year, true);

            try
            {
                _db.UpdateBook(updatedBook);
                Console.WriteLine("[OK] Book updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] {ex.Message}");
            }
        }

        // ===============================
        // DELETE BOOK
        // ===============================
        private void DeleteBook()
        {
            Console.WriteLine("\n-- Delete Book --");

            Console.Write("Book ID: ");
            int.TryParse(Console.ReadLine(), out int id);

            try
            {
                _db.DeleteBook(id);
                Console.WriteLine("[OK] Book deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] {ex.Message}");
            }
        }
    }
}