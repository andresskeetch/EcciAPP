using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Enums;

namespace Core.Models.Models
{
    public class ScheduleAll
    {
        public int ScheduleAllID { get; set; }

        public Class Class { get; set; }

        public DateTime Date { get; set; }

        public StateClass State { get; set; }



        public string DateString {
            get {
                return string.Format("Hora : {0} - {1}",
                    Date.ToString("HH: mm"),
                    Date.AddHours(2).ToString("HH:mm"));
            }
        }

        public string ClassState
        {
            get
            {
                if (this.State == StateClass.Active)
                {
                    if (Tools.Tools.GetDateTime() >= this.Date && Tools.Tools.GetDateTime() < this.Date.AddHours(2))
                    {
                        return "En progreso";

                    }
                    else if (this.Date > DateTime.Now)
                    {
                        return "Activa";

                    }
                    else
                    {
                        return "Realizada";
                    }

                }
                else
                {
                    return "Cancelada";
                }
            }
        }
    }
}
