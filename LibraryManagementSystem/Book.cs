using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Book
    {
        public string ISBN
        {
            get;
        }
        public string Title
        {
            get;
        }
        public string Author
        {
            get;
        }
        public int CopiesAvailable
        {
            get;
            set;
        }
        public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            CopiesAvailable = 1;
        }
    }
}