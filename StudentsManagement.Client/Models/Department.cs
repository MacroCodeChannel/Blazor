using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Client.Models
{
    public class Department : UserModifyActivity
    {
        public int Id { get; set; } 

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
