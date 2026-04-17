/* Name: Kwadwo Owusu
   Date: April 17, 2026 
   Purpose: Interface for Phase 2 (Demonstration of Interfaces) */

public interface ILibraryItem
{
    // These properties already exist in your Book class
    int Id { get; set; }
    string Title { get; set; }
    
    // This is the method we will use for polymorphism
    void Display();
}