/* Name: Kwadwo Owusu 
   Date: April 16, 2026 
   Purpose: Derived class demonstrating Inheritance and Polymorphism */

using System;

public class EBook : Book
{
    public double FileSizeMB { get; set; }

    public EBook(int id, string title, string author, double fileSize)
        : base(id, title, author) 
    {
        FileSizeMB = fileSize;
    }

    // DEMONSTRATION OF POLYMORPHISM: Overriding the Display method
    public override void Display()
    {
        Console.WriteLine($"[E-BOOK] ID: {Id}, Title: {Title}, Author: {Author}, Size: {FileSizeMB}MB");
    }
}