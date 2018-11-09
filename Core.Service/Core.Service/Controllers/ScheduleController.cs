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
                ScheduleLogic logic = new ScheduleLogic();
                return Ok(logic.GetTodayActivities(personID));
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
                ScheduleLogic logic = new ScheduleLogic();
                return Ok(logic.GetActivities(personID));
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
                ScheduleLogic logic = new ScheduleLogic();
                return Ok(logic.Update(activity, personID));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
