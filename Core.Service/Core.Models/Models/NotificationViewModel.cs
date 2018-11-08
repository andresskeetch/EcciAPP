using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class NotificationViewModel
    {
        public string Description { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public ScheduleAllViewModel ScheduleAll { get; set; }
        public PersonViewModel Person { get; set; }
    }
}
