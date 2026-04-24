// ================================
// Name: Kwadwo Owusu
// Date: 23/04/2026
// Assignment:  Library & Book Management System
// 
// ================================

using System;

namespace LibraryManagementSystem
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Member(int memberId, string name, string email, string phone)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine($"  Member ID : {MemberId}");
            Console.WriteLine($"  Name      : {Name}");
            Console.WriteLine($"  Email     : {Email}");
            Console.WriteLine($"  Phone     : {Phone}");
            Console.WriteLine("==========================================");
        }

        public override string ToString()
        {
            return $"[{MemberId}] {Name} | {Email} | {Phone}";
        }
    }
}