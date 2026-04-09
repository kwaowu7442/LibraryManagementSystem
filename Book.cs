/*
Name: Kwadwo Owusu
Date: 9th April 2026
Purpose: Base class representing a book (Inheritance base class)
*/

using System;

public class Book
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

    // Method to display book info
    public virtual void Display()
    {
        Console.WriteLine($"ID: {Id}, Title: {Title}, Author: {Author}");
    }
}