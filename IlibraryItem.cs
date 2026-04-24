// ================================
// Name: Kwadwo Owusu
// Date: 23/04/2026
// Assignment:  Library & Book Management System
// 
// ================================

namespace LibraryManagementSystem
{
    public interface ILibraryItem
    {
        int ItemId { get; set; }
        string Title { get; set; }
        bool IsAvailable { get; set; }

        void DisplayInfo();
    }
}