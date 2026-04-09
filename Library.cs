/*
Name: Kwadwo Owusu
Date: 6 April 2026
Purpose: Library class that contains books (Demonstrates COMPOSITION)
*/

using System;
using System.Collections.Generic;

public class Library
{
    // COMPOSITION: Library HAS a list of books
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added successfully!");
    }

    public void DisplayBooks()
    {
        Console.WriteLine("\n--- Library Books ---");

        foreach (var book in books)
        {
            book.Display();
        }
    }
}