using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class Notification
    {
        private DateTime _date;
        public string Description { get; set; }
        public int ID { get; set; }
        public DateTime Date
        {
            get
            {
                DateTime runtimeKnowsThisIsUtc = DateTime.SpecifyKind(
                    _date,
                    DateTimeKind.Utc);
                return runtimeKnowsThisIsUtc.ToLocalTime();
            }
            set
            {
                _date = value;
            }
        }
        public ScheduleAll ScheduleAll { get; set; }
        public Person Person { get; set; }
    }
}
