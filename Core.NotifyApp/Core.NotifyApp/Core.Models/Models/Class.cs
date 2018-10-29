using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public Person Teacher { get; set; }
        public Schedule Schedule { get; set; }
    }
}
