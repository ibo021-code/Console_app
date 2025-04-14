using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_app
{
    public class Group
    {
        public string NO { get; set; }
        public string Category { get; set; }
        public bool IsOnline { get; set; }
        public int limit
        {
            get
            {
                if (IsOnline)
                {
                    return 15;
                }
                else
                {
                    return 10;
                }
            }
        }
        public List<Student> students { get; set; } = new List<Student>();
    }
}
