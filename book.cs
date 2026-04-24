// ================================
// Name: Kwadwo Owusu
// Date: 23/04/2026
// Assignment:  Library & Book Management System
// 
// ================================

using System;

namespace LibraryManagementSystem
{
    public class Book : LibraryItem
    {
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }

        public Book(int bookId, string title, string author, string genre,
                    int publicationYear, bool isAvailable = true)
            : base(bookId, title, isAvailable)
        {
            Author = author;
            Genre = genre;
            PublicationYear = publicationYear;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine($"  ID     : {ItemId}");
            Console.WriteLine($"  Title  : {Title}");
            Console.WriteLine($"  Author : {Author}");
            Console.WriteLine($"  Genre  : {Genre}");
            Console.WriteLine($"  Year   : {PublicationYear}");
            Console.WriteLine($"  Status : {AvailabilityLabel()}");
            Console.WriteLine("==========================================");
        }

        public override string ToString()
        {
            return $"[{ItemId}] \"{Title}\" by {Author} ({PublicationYear}) - {AvailabilityLabel()}";
        }
    }
}