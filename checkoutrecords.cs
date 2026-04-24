// ================================
// Name: Kwadwo Owusu
// Date: 23/04/2026
// Assignment:  - Library & Book Management System
//

using System;

namespace LibraryManagementSystem
{
    public class CheckoutRecord
    {
        public int RecordId { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool IsReturned => ReturnDate.HasValue;

        public CheckoutRecord(int recordId, Book book, Member member,
                              DateTime checkoutDate, DateTime? returnDate = null)
        {
            RecordId = recordId;
            Book = book ?? throw new ArgumentNullException(nameof(book));
            Member = member ?? throw new ArgumentNullException(nameof(member));
            CheckoutDate = checkoutDate;
            ReturnDate = returnDate;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine($"  Record ID     : {RecordId}");
            Console.WriteLine($"  Book          : {Book.Title}");
            Console.WriteLine($"  Member        : {Member.Name}");
            Console.WriteLine($"  Checkout Date : {CheckoutDate:yyyy-MM-dd}");
            Console.WriteLine($"  Return Date   : {(IsReturned ? ReturnDate!.Value.ToString("yyyy-MM-dd") : "Not yet returned")}");
            Console.WriteLine($"  Status        : {(IsReturned ? "Returned" : "Active")}");
            Console.WriteLine("==========================================");
        }

        public override string ToString()
        {
            string returnInfo = IsReturned
                ? $"Returned: {ReturnDate!.Value:yyyy-MM-dd}"
                : "Not yet returned";

            return $"[{RecordId}] \"{Book.Title}\" - {Member.Name} | Checked out: {CheckoutDate:yyyy-MM-dd} | {returnInfo}";
        }
    }
}