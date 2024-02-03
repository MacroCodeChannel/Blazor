using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Client.Models
{
    public class Parent : UserModifyActivity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public int GenderId { get; set; }

        public SystemCodeDetail Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int ParentTypeId { get; set; }

        public SystemCodeDetail ParentType { get; set; }

        public DateTime DOB { get; set; }

        public int Photo { get; set; }
    }
}
