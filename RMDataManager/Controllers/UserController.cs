﻿using Microsoft.AspNet.Identity;

using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;

using System.Linq;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            var id = RequestContext.Principal.Identity.GetUserId();
            var _userData = new UserData();

            return _userData.GetUserById(id).FirstOrDefault();
        }
    }
}