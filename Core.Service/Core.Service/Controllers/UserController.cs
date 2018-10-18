using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Service.Logic;
using Core.Models.Models;

namespace Core.Service.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("{personID}/gettodayactivities")]
        public IHttpActionResult GetTodayActivities(int personID)
        {
            try
            {

                return Ok(UserLogic.GetTodayActivities(personID));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
