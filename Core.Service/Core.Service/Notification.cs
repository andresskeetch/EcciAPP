using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Models.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Core.Service
{

    [HubName("NotificationHub")]
    public class Notification : Hub
    {
        public void Send(NotificationViewModel activity)
        {
            // Call the broadcastMessage method to update clients.  
            Clients.All.Notificate(activity);
        }

        internal static void SetStaticNotification(NotificationViewModel notification)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<Notification>();
            context.Clients.All.Notificate(notification);
        }
    }
}