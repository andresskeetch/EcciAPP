using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Core.Service
{
    public class Notification : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.  
            Clients.All.broadcastMessage(name, message);
        }
        public void DragView(float rawX, float initX, float rawY, float initY)
        {
            Clients.Others.UpdateView(rawX, initX, rawY, initY);

        }
    }
}