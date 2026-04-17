/* Name: Kwadwo Owusu 
   Date: April 17, 2026 
   Purpose: Library class using Interface-based list */

using System;
using System.Collections.Generic;

public class Library
{
    // Updated to use the Interface type for the list
    private List<ILibraryItem> items = new List<ILibraryItem>();

    public void AddItem(ILibraryItem item)
    {
        items.Add(item);
        Console.WriteLine("Item added to collection!");
    }

    public void DisplayAll()
    {
        Console.WriteLine("\n--- Current Library Collection ---");
        foreach (var item in items)
        {
            // DEMONSTRATION OF POLYMORPHISM: 
            // The compiler calls the correct Display() version for Book or EBook.
            item.Display();
        }
    }
}