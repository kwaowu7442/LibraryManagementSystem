/* Name: Kwadwo Owusu
   Date: April 16, 2026 
   Purpose: Base class updated to implement ILibraryItem */

using System;

public class Book : ILibraryItem // Now implements the interface
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    // This fulfills the interface requirement
    public virtual void Display()
    {
        Console.WriteLine($"[BOOK] ID: {Id}, Title: {Title}, Author: {Author}");
    }
}