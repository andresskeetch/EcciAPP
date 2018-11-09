using Core.Service.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Core.Service.Controllers
{
    [RoutePrefix("api/Notification")]
    public class NotificationController : ApiController
    {
        [HttpGet]
        [Route("{userID}/GetNotifications")]
        public IHttpActionResult GetTodayActivities(int userID)
        {
            try
            {
                NotificationLogic noty = new NotificationLogic();
                return Ok(noty.GetNotificationsUser(userID));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
