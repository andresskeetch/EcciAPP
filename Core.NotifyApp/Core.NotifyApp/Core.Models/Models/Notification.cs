using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class Notification
    {
        public string Description { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public ScheduleAll ScheduleAll { get; set; }
        public Person Person { get; set; }
    }
}
