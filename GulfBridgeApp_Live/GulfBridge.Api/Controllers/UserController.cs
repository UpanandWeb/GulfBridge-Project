using GulfBridge.DAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GulfBridge.Api.Controllers
{
    public class UserController : BaseController
    {
        private IUserDAL userDal;
        public UserController(IUserDAL _userDal)
        {
            this.userDal = _userDal;
        }
    }
}
