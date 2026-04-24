// ================================
// Name: Kwadwo Owusu
// Date: 23/04/2026

// ================================

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new LibraryDatabase("library.db");
            // Phase 2: db.InitializeDatabase();

            var menu = new MenuService(db);
            menu.Run();
        }
    }
}