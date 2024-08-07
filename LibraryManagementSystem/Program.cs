using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main()
        {
            Library library = new Library();

            //Existing Books
            library.AddBook(new Book("10001", "HelloWorld", "Harper Moore"));
            library.AddBook(new Book("10002", "The Bird", "Noah Thompson"));
            library.AddBook(new Book("10003", "Black Widow", "Emma Davis"));

            //Existing Memebers
            library.RegisterMember(new Member("20230001", "Emily Johnson", "0711234567"));
            library.RegisterMember(new Member("20230002", "David Smith", "0771231234"));
            library.RegisterMember(new Member("20230003", "Sarah Brown", "0761112223"));

            Console.Clear();

            while (true)
            {
                Console.WriteLine("#######################################################################################################################");
                Console.WriteLine("Library Management System");
                Console.WriteLine("-------------------------");

                //Books
                Console.WriteLine("1.Add Book");
                Console.WriteLine("2.Remove Book");
                Console.WriteLine("3.Search Book");
                Console.WriteLine("4.Display All Available Books");
                Console.WriteLine("5.Lend Book");
                Console.WriteLine("6.Return Book");
                Console.WriteLine("7.View Lending Information");
                Console.WriteLine("8.Display Overdue Books\n");

                //Members
                Console.WriteLine("9.Register Member");
                Console.WriteLine("10.Remove Member");
                Console.WriteLine("11.Search Member");
                Console.WriteLine("12.Display All Registered Members");

                Console.WriteLine("0.Exit\n");

                Console.Write("Enter a number from the above choices: ");

                int choice = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();

                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();

                        library.AddBook(new Book(isbn, title, author));
                        break;
                    case 2:
                        Console.Write("Enter ISBN of the book to remove: ");
                        isbn = Console.ReadLine();

                        library.RemoveBook(isbn);
                        break;
                    case 3:
                        Console.Write("Enter Title of the book to search: ");
                        title = Console.ReadLine();

                        Book foundBook = library.SearchBook(title);

                        if (foundBook != null)
                        {
                            Console.WriteLine($"\nBook found: ISBN - {foundBook.ISBN} | Title - {foundBook.Title} | Author - {foundBook.Author}\n");
                        }
                        else
                        {
                            Console.WriteLine("\nBook not found.\n");
                        }
                        break;
                    case 4:
                        library.DisplayAllBooks();
                        break;
                    case 5:
                        Console.Write("Enter ISBN of the book to lend: ");
                        isbn = Console.ReadLine();

                        Console.Write("Enter Member ID: ");
                        string memberId = Console.ReadLine();

                        Console.Write("Enter Due Date (yyyy-mm-dd): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        library.LendBook(isbn, memberId, dueDate);
                        break;
                    case 6:
                        Console.Write("Enter ISBN of the book to return: ");
                        isbn = Console.ReadLine();

                        library.ReturnBook(isbn);
                        break;
                    case 7:
                        library.ViewLendingInformation();
                        break;
                    case 8:
                        library.DisplayOverdueBooks();
                        break;
                    case 9:
                        Console.Write("Enter Member ID: ");
                        memberId = Console.ReadLine();

                        Console.Write("Enter Name: ");
                        string memberName = Console.ReadLine();

                        Console.Write("Enter Contact Number: ");
                        string contactNumber = Console.ReadLine();

                        library.RegisterMember(new Member(memberId, memberName, contactNumber));
                        break;
                    case 10:
                        Console.Write("Enter Member ID to remove: ");
                        memberId = Console.ReadLine();

                        library.RemoveMember(memberId);
                        break;
                    case 11:
                        Console.Write("Enter Member ID to search: ");
                        memberId = Console.ReadLine();

                        Member foundMember = library.SearchMember(memberId);

                        if (foundMember != null)
                            Console.WriteLine($"\nMember found: Member ID - {foundMember.MemberId} | Name - {foundMember.Name} | Contact No. - {foundMember.ContactNumber}\n");
                        else
                            Console.WriteLine("\nMember not found.\n");
                        break;
                    case 12:
                        library.DisplayAllMembers();
                        break;
                    case 0:
                        Console.WriteLine("Closing Library Management System. Have a nice day!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }
            }
        }
    }
}


