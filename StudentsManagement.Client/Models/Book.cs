using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Client.Models
{
    public class Book : UserModifyActivity
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Auther { get; set; }

        public int NoOfCopy { get; set; }

        public int BookCategoryId { get; set; }

        public  SystemCodeDetail BookCategory { get; set; }

        public string BookPhoto { get; set; }

    }
}
