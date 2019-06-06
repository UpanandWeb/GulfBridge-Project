using GulfBridge.DAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GulfBridge.Api.Controllers
{
    public class AdminController : BaseController
    {
        private IAdminDAL adminDal;
        public AdminController(IAdminDAL _adminDal)
        {
            this.adminDal = _adminDal;
        }

      
    }
}
