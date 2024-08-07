using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Member
    {
        public string MemberId
        {
            get;
        }
        public string Name
        {
            get;
        }
        public string ContactNumber
        {
            get;
        }
        public Member(string memberId, string name, string contactNumber)
        {
            MemberId = memberId;
            Name = name;
            ContactNumber = contactNumber;
        }
    }
}