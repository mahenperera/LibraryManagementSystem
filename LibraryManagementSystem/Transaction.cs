using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Transaction
    {
        public Book Book
        {
            get;
        }
        public Member Member
        {
            get;
        }
        public DateTime IssueDate
        {
            get;
        }
        public DateTime DueDate
        {
            get;
        }
        public DateTime ReturnDate
        {
            get;
            set;
        }
        public Transaction(Book book, Member member, DateTime dueDate)
        {
            Book = book;
            Member = member;
            IssueDate = DateTime.Now;
            DueDate = dueDate;
            ReturnDate = DateTime.MinValue;
        }
    }   
}