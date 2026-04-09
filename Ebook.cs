/*
Name: Kwadwo Owusu
Date: 9th April 2026
Purpose: Derived class from Book (Demonstrates INHERITANCE)
*/

using System;

public class EBook : Book
{
    public double FileSizeMB { get; set; }

    public EBook(int id, string title, string author, double fileSize)
        : base(id, title, author) // INHERITANCE
    {
        FileSizeMB = fileSize;
    }

    // Override display method
    public override void Display()
    {
        Console.WriteLine($"[E-BOOK] ID: {Id}, Title: {Title}, Author: {Author}, Size: {FileSizeMB}MB");
    }
}