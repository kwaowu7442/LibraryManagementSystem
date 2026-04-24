// ================================
// Name: Kwadwo Owusu
// Date: 23/04/2026
// Assignment:  Library & Book Management System
// 
// ================================

namespace LibraryManagementSystem
{
    public abstract class LibraryItem : ILibraryItem
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public bool IsAvailable { get; set; }

        protected LibraryItem(int itemId, string title, bool isAvailable = true)
        {
            ItemId = itemId;
            Title = title;
            IsAvailable = isAvailable;
        }

        public abstract void DisplayInfo();

        protected string AvailabilityLabel() => IsAvailable ? "Available" : "Checked Out";
    }
}