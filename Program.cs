/*
Name: Kwadwo Owusu
Date: 9th April 2026
Purpose: Main program demonstrating input/output, inheritance, and composition
*/

using System;

class Program
{
    static void Main()
    {
        // Week indicator
        Console.WriteLine("=== PROJECT WEEK 1 ===");
        Console.WriteLine("Library Management System");
        Console.WriteLine("By Owusu\n");

        // Welcome message
        Console.WriteLine("Welcome! You can add and view books.");
        Console.WriteLine("Enter the number of your choice.\n");

        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n1. Add Book");
            Console.WriteLine("2. Add EBook");
            Console.WriteLine("3. View Books");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                Book book = new Book(id, title, author);
                library.AddBook(book);
            }
            else if (choice == "2")
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                Console.Write("Enter File Size (MB): ");
                double size = double.Parse(Console.ReadLine());

                // INHERITANCE used here
                EBook ebook = new EBook(id, title, author, size);
                library.AddBook(ebook);
            }
            else if (choice == "3")
            {
                library.DisplayBooks();
            }
            else if (choice == "0")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}