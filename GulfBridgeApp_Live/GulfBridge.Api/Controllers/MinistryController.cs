using AutoMapper;
using GulfBridge.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GulfBridge.DAL.IDAL;
using GulfBridge.DAL.DAL;
using System.Configuration;

namespace GulfBridge.Api.Controllers
{
    [RoutePrefix("api/ministry")]
    [Authorize]
    public class MinistryController : ApiController
    {
        //public IMinistryDAL ministryDal;
        //public MinistryController(IMinistryDAL _ministryDal)
        //{
        //    this.ministryDal = _ministryDal;
        //}
        public MinistryDAL ministryDal = new MinistryDAL();


        [HttpGet]
        [Route("GetApplicants")]
        public HttpResponseMessage GetApplicants()
        {
            //var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(ministryDal.GetApplicants());
            var result = ministryDal.GetApplicants();
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("GetApplicantSearch")]
        public HttpResponseMessage GetApplicants(string name)
        {
            //var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(ministryDal.GetApplicants(name));
            var result = ministryDal.GetApplicants(name);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("GetApplicantByRefNumber")]
        public HttpResponseMessage GetApplicantByRefNumber(string RefNo)
        {
            //var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(ministryDal.GetApplicants(name));
            var result = ministryDal.GetApplicantByRefNumber(RefNo);
            if (result != null)
            {
                string rooturl = ConfigurationManager.AppSettings["WebUrl"];
                result=result.Replace("~/", rooturl);
            }
            return Request.CreateResponse(result);
        }



        [HttpGet]
        [Route("GetApplicantByDate")]
        public HttpResponseMessage GetApplicantByDate(DateTime? StartDate=null, DateTime? EndDate = null)
        {

            if (StartDate == null || EndDate == null || !StartDate.HasValue || !EndDate.HasValue)
                return Request.CreateResponse("Please enter start date and end date");
            var result = ministryDal.GetApplicantByDate(StartDate.Value,EndDate.Value);
            return Request.CreateResponse(result);
        }



    }
}
