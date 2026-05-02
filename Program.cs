// ================================
// Name: Kwadwo Owusu
// Date: 02/05/2026
// Assignment: Library & Book Management System
//
// Description: Main entry point for the Library Management System.
//              Initializes the SQLite database, creates all tables,
//              and launches the interactive menu service.
// ================================

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new LibraryDatabase("KwadwoOwusu_library.db");
            db.InitializeDatabase();

            var menu = new MenuService(db);
            menu.Run();
        }
    }
}