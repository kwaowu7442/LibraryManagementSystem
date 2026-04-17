/* Name: Kwadwo Owusu 
   Date: April 17, 2026 
   Purpose: Main program for Phase 2 demonstration */

using System;

class Program
{
    static void Main()
    {
        // Requirement: Name and Assignment Info
        Console.WriteLine("=== PROJECT WEEK 2 ===");
        Console.WriteLine("Assignment: 2.6 Elements Demonstration");
        Console.WriteLine("Student: Kwadwo Owusu\n");

        Console.WriteLine("Welcome! Use the menu to manage the library.");
        
        Library myLibrary = new Library();

        // Adding realistic information to demonstrate the classes
        Book b1 = new Book(101, "C# Programming", "Ruth Smitch");
        EBook e1 = new EBook(102, "AI Basics", "Ruth Smith", 2.5);

        // Demonstrating the Interface usage
        myLibrary.AddItem(b1);
        myLibrary.AddItem(e1);

        // Demonstrating Polymorphism
        myLibrary.DisplayAll();

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}