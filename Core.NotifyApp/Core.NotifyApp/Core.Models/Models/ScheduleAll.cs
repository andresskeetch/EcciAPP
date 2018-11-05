using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Enums;
using Xamarin.Forms;

namespace Core.Models.Models
{
    public class ScheduleAll
    {
        public int ScheduleAllID { get; set; }

        public Class Class { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateTo
        {
            get {
                return Date.AddHours(2);
            }
        }


        public StateClass State { get; set; }

        public string EventName
        {
            get {
                return string.Format("Estado {0} \n{1} \n{2} - {3} \nSede {4} - {5}", 
                    ClassState,
                    DateString,
                    Class.Name,
                    Class.Course.Name,
                    Class.ClassRoom.Seat.Name,
                    Class.ClassRoom.Name
                    );
            }
        }

        public string DateString {
            get {
                return string.Format("Hora : {0} - {1}",
                    Date.ToString("HH: mm"),
                    Date.AddHours(2).ToString("HH:mm"));
            }
        }

        public Color Color {
            get {
                if (this.State == StateClass.Active)
                {
                    if (Tools.Tools.GetDateTime() >= this.Date && Tools.Tools.GetDateTime() < this.Date.AddHours(2))
                    {
                        return Color.FromHex("#ffff99");

                    }
                    else if (this.Date > DateTime.Now)
                    {
                        return Color.FromHex("#ccffff");
                    }
                    else
                    {
                        return Color.FromHex("#ffcccc");
                    }

                }
                else
                {
                    return Color.FromHex("#cccccc");
                }
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
