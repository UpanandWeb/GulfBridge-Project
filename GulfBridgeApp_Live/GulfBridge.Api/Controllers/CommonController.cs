using AutoMapper;
using GulfBridge.DAL.IDAL;
using GulfBridge.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GulfBridge.DAL.DAL;
using System.IO;
using System.Configuration;

namespace GulfBridge.Api.Controllers
{
    [RoutePrefix("api/common")]
    public class CommonController : ApiController
    {
        //private ICommonDAL commonDal;
        // private IMapper mapper;
        //public CommonController(ICommonDAL _commonDal)
        //{
        //    this.commonDal = _commonDal;
        //}
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CommonController));
        public CommonDAL commonDal = new CommonDAL();

        [HttpGet]
        [Route("getAppType")]
        public HttpResponseMessage GetApplicationTypes()
        {
            
            return Request.CreateResponse(Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.Mst_ApplicationType>, IEnumerable<CommonType>>(commonDal.GetApplicationTypes()));
        }

        [HttpGet]
        [Route("getAppCategory")]
        public HttpResponseMessage GetAppCategory()
        {
            return Request.CreateResponse(Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.Mst_ApplicationCategory>, IEnumerable<CommonType>>(commonDal.GetAppCategory()));
        }

        [HttpGet]
        [Route("getAppSubCategory")]
        public HttpResponseMessage GetAppSubCategory()
        {
            return Request.CreateResponse(Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.Mst_App_Sub_Category>, IEnumerable<CommonType>>(commonDal.GetAppSubCategory()));
        }


        [HttpGet]
        [Route("getCountries")]
        public HttpResponseMessage GetCountries()
        {
            return Request.CreateResponse(Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.Mst_Countries>, IEnumerable<CommonType>>(commonDal.GetCountries()));
        }

        [HttpGet]
        [Route("getCountriesCode")]
        public HttpResponseMessage GetCountriesCode()
        {
            return Request.CreateResponse(Mapper.Map<object, IEnumerable<CountryCodeType>>(commonDal.GetCountriesCode()));
        }

        [HttpGet]
        [Route("getCities")]
        public HttpResponseMessage GetCities()
        {
            return Request.CreateResponse(Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.Mst_City>, IEnumerable<CommonType>>(commonDal.GetCities()));
        }

        [HttpGet]
        [Route("getNationality")]
        public HttpResponseMessage GetNationality()
        {
            return Request.CreateResponse(Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.Mst_Nationality>, IEnumerable<CommonType>>(commonDal.GetNationality()));
        }

        [HttpGet]
        [Route("getVisaType")]
        public HttpResponseMessage GetVisaType()
        {
            return Request.CreateResponse(Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.Mst_VisaType>, IEnumerable<CommonType>>(commonDal.GetVisaType()));
        }

        [HttpGet]
        [Route("getpaymentinfo")]
        public HttpResponseMessage GetPayment(int appcategory,int apptypeid)
        {
            return Request.CreateResponse(commonDal.GetPayment(appcategory, apptypeid));
        }

        [HttpGet]
        [Route("getlicencetype")]
        public HttpResponseMessage GetLicenceType()
        {
            return Request.CreateResponse(commonDal.GetLicenceType());
        }

        [HttpGet]
        [Route("getjobdesig")]
        public HttpResponseMessage GetJobDesig()
        {
            return Request.CreateResponse(commonDal.GetJobDesig());
        }

        [HttpGet]
        [Route("getemplytype")]
        public HttpResponseMessage GetEmplyType()
        {
            return Request.CreateResponse(commonDal.GetEmplyType());
        }


        [HttpGet]
        [Route("getstatus")]
        public HttpResponseMessage GetStatus()
        {
            return Request.CreateResponse(commonDal.GetStatus());
        }

        [HttpGet]
        [Route("getapplicantstatus")]
        public HttpResponseMessage GetApplicantStatus()
        {
            return Request.CreateResponse(commonDal.GetApplicantStatus());
        }


    }
}
