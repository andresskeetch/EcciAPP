using Core.Models.Models;
using Core.Service.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Service.Logic
{
    public class NotificationLogic : BaseLogic
    {
        public IEnumerable<NotificationViewModel> GetNotificationsUser(int UserID)
        {
            // hace falta agregar el filtro por usuario.
            return NotificationMapping.MapToViewModel(db.Notification);
            
        }
    }
}