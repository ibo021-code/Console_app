using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_app
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GroupNO { get; set; }
        public Group group { get; set; }
        public string Type { get; set; }
    }
}
