﻿using Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Communication
{
    public static class Constants
    {
        public static string uri = "http://solmedco-001-site4.etempurl.com/api";
        //public static string uri = "http://localhost/servicio/api";

        public static string uriSignalR = "http://solmedco-001-site4.etempurl.com/";

        public static string uriLogin = "Account/Login";

        public static string uriScheduleToday = "schedule/{0}/GetTodayActivities";

        public static string uriSchedule = "schedule/{0}/GetActivities";

        public static string uriScheduleUpdate = "schedule/{0}/UpdateActivity";

        public static string uriGetNotification = "Notification/{0}/GetNotifications";


    }
}
