using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Tools
{
    public static class Tools
    {
        public static DateTime GetDateTime()
        {
            try
            {

                TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                zona = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
                return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, zona);
            }
            catch
            {
                return DateTime.Now;
            }
        }
    }
}
