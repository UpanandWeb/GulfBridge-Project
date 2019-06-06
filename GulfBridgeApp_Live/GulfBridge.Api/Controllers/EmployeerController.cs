using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GulfBridge.DAL.DAL;
using AutoMapper;
using GulfBridge.Entity.Entity;

namespace GulfBridge.Api.Controllers
{
    [RoutePrefix("api/employer")]
    [Authorize]
    public class EmployeerController : ApiController
    {

        public EmployerDAL empDal = new EmployerDAL();

        [Route("GetEmployeer")]
        public HttpResponseMessage GetEmployeer(string UserId)
        {
            var result=Mapper.Map<DAL.dbContext.EmployerDetail,EmployerDetails>(empDal.GetEmployeer(UserId));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("GetEmpApplicantsbyStatus")]
        public HttpResponseMessage GetEmpApplicantsbyStatus(string UserId,int status)
        {
            var result = empDal.GetEmpApplicantsbyStatus(UserId,status);
            return Request.CreateResponse(result);
        }
    }
}
