using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class ClassViewModel
    {
        public int ClassID { get; set; }
        public string Name { get; set; }
        public CourseViewModel Course { get; set; }
        public ClassRoomViewModel ClassRoom { get; set; }
        public PersonViewModel Teacher { get; set; }
        public ScheduleViewModel Schedule { get; set; }
    }
}
