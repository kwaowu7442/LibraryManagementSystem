// ================================
// Name: Kwadwo Owusu
// Date: 02/05/2026
// Assignment: Library & Book Management System
//
// Description: Entry point for the application. Initializes the
// SQLite database and launches the console-based menu system.
// ================================

using System;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Kwadwo Owusu Library Management System";

                // Initialize database
                var db = new LibraryDatabase("KwadwoOwusu_library.db");
                db.InitializeDatabase();

                // Start menu system
                var menu = new MenuService(db);
                menu.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("==================================");
                Console.WriteLine("Application Error");
                Console.WriteLine("==================================");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}