using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Library
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();
        private List<Transaction> transactions = new List<Transaction>();

        //Books
        public void AddBook(Book book)
        {
            Book AlreadyAvailableBook = books.FirstOrDefault(b => b.ISBN == book.ISBN);

            if (AlreadyAvailableBook == null)
            {
                books.Add(book);
                Console.WriteLine("\nNew book added to the library.\n");
            }
            else
            {
                AlreadyAvailableBook.CopiesAvailable++;
                Console.WriteLine("\nCopy of the book added to the library\n");
            }
        }

        public void RemoveBook(string isbn)
        {
            Book bookToRemove = books.FirstOrDefault(b => b.ISBN == isbn);

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine("\nBook removed from the library.\n");
            }
            else
            {
                Console.WriteLine("\nBook not found.\n");
            }
        }

        public Book SearchBook(string title)
        {
            return books.FirstOrDefault(b => b.Title == title);
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("All Books in the Library:");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("ISBN\t\tBook Name\t\tAuthor\t\tCopies");
            Console.WriteLine("--------------------------------------------------------------");

            foreach (var book in books)
            {
                Console.WriteLine($"{book.ISBN}\t\t{book.Title}\t\t{book.Author}\t{book.CopiesAvailable}");
            }
            Console.WriteLine();
        }

        public void LendBook(string isbn, string memberId, DateTime dueDate)
        {
            Book bookToLend = books.FirstOrDefault(b => b.ISBN == isbn);
            Member member = members.FirstOrDefault(m => m.MemberId == memberId);

            if (bookToLend == null)
            {
                Console.WriteLine("\nBook not found.\n");
                return;
            }

            if (member == null)
            {
                Console.WriteLine("\nMember not found.\n");
                return;
            }

            if (bookToLend.CopiesAvailable > 0)
            {
                bookToLend.CopiesAvailable--;
                transactions.Add(new Transaction(bookToLend, member, dueDate));
                Console.WriteLine("\nBook lent successfully.\n");
            }
            else
            {
                Console.WriteLine("\nAll copies of this book are currently lent out.\n");
            }
        }

        public void ReturnBook(string isbn)
        {
            Transaction transaction = transactions.FirstOrDefault(t => t.Book.ISBN == isbn && t.ReturnDate == DateTime.MinValue);

            if (transaction != null)
            {
                Book bookToReturn = books.FirstOrDefault(b => b.ISBN == isbn);

                transaction.ReturnDate = DateTime.Now;
                int fine = CalculateFine(transaction);

                if (fine > 0)
                {
                    Console.WriteLine($"\nBook returned. Fine: Rs. {fine}\n");
                    bookToReturn.CopiesAvailable++;
                }
                else
                {
                    Console.WriteLine("\nBook returned. No fine.\n");
                    bookToReturn.CopiesAvailable++;
                }
            }
            else
            {
                Console.WriteLine("\nTransaction not found.\n");
            }
        }

        public void ViewLendingInformation()
        {
            Console.WriteLine("Lending Information:");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Book\t\tISBN\tMember ID\tMember Name\tDue Date");
            Console.WriteLine("------------------------------------------------------------------------------");

            foreach (var transaction in transactions)
            {
                Console.WriteLine($"{transaction.Book.Title}\t{transaction.Book.ISBN}\t{transaction.Member.MemberId}\t{transaction.Member.Name}\t{transaction.DueDate}");
            }
            Console.WriteLine();
        }

        public void DisplayOverdueBooks()
        {
            Console.WriteLine("Overdue Books:");
            DateTime currentDate = DateTime.Now;

            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Book\t\tISBN\tMember ID\tMember Name\tDue Date");
            Console.WriteLine("------------------------------------------------------------------------------");

            foreach (var transaction in transactions)
            {
                if (transaction.ReturnDate == DateTime.MinValue && currentDate > transaction.DueDate)
                {
                    Console.WriteLine($"{transaction.Book.Title}\t{transaction.Book.ISBN}\t{transaction.Member.MemberId}\t{transaction.Member.Name}\t{transaction.DueDate}");
                }
            }
            Console.WriteLine();
        }


        //Members
        public void RegisterMember(Member member)
        {
            members.Add(member);
            Console.WriteLine("\nMember registered.\n");
        }

        public void RemoveMember(string memberId)
        {
            Member memberToRemove = members.FirstOrDefault(m => m.MemberId == memberId);

            if (memberToRemove != null)
            {
                members.Remove(memberToRemove);
                Console.WriteLine("\nMember removed.\n");
            }
            else
            {
                Console.WriteLine("\nMember not found.\n");
            }
        }

        public Member SearchMember(string memberId)
        {
            return members.FirstOrDefault(m => m.MemberId == memberId);
        }

        public void DisplayAllMembers()
        {
            Console.WriteLine("All Members in the Library:");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Member ID\t\tName\t\t\tContact No.");
            Console.WriteLine("-----------------------------------------------------------");

            foreach (var member in members)
            {
                Console.WriteLine($"{member.MemberId}\t\t{member.Name}\t\t{member.ContactNumber}");
            }
            Console.WriteLine();
        }


        private int CalculateFine(Transaction transaction)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan overduePeriod = currentDate - transaction.DueDate;

            if (overduePeriod.TotalDays <= 7)
            {
                return (int)overduePeriod.TotalDays * 50;
            }
            else
            {
                return 7 * 50 + (int)(overduePeriod.TotalDays - 7) * 100;
            }
        }
    }
}