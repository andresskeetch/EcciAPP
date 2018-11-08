using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Models.Models;
using Microsoft.AspNet.SignalR;

namespace Core.Service
{
    public class Notification : Hub
    {
        public void Send(NotificationViewModel activity)
        {
            // Call the broadcastMessage method to update clients.  
            Clients.All.addNewNotification(activity);
        }
    }
}