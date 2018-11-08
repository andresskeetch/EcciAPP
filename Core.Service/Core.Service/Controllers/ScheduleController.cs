using Core.Models.Models;
using Core.Service.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Core.Service.Controllers
{
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        [HttpGet]
        [Route("{personID}/gettodayactivities")]
        public IHttpActionResult GetTodayActivities(int personID)
        {
            try
            {
                return Ok(ScheduleLogic.GetTodayActivities(personID));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("{personID}/getactivities")]
        public IHttpActionResult GetActivities(int personID)
        {
            try
            {
                return Ok(ScheduleLogic.GetActivities(personID));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("{personID}/UpdateActivity")]
        public IHttpActionResult UpdateActivity(int personID, ScheduleAllViewModel activity )
        {
            try
            {
                return Ok(ScheduleLogic.Update(activity, personID));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
