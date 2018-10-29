using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Hour { get; set; }
    }
}
