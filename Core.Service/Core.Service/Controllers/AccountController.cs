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
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        public IHttpActionResult Login(Login user)
        {
            try
            {
                return Ok(AccountLogic.Authenticate(user));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

    }
}
