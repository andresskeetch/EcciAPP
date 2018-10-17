using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Enums;

namespace Core.Models.Models
{
    public class ScheduleAllViewModel
    {
        public int ScheduleAllID { get; set; }
        public ClassViewModel Class { get; set; }
        public StateClass State { get; set; }
        public DateTime Date { get; set; }
    }
}
