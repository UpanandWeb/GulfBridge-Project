using AutoMapper;
using GulfBridge.Api.App_Start;
using GulfBridge.DAL.DAL;
using GulfBridge.DAL.IDAL;
using GulfBridge.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GulfBridge.Api.Controllers
{
    //[Authorize]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        //private IAccountDAL accountDal;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AccountController));
        public static string RefNumberKey = ConfigurationManager.AppSettings["RefNumberKey"];
        public static string GBSRefNo = ConfigurationManager.AppSettings["GBSRefNo"];
        //public AccountController(IAccountDAL _accountDal)
        //{
        //    this.accountDal = _accountDal;
        //}
        public AccountDAL accountDal = new AccountDAL();
        public ExternalPlugin external = new ExternalPlugin();


        [HttpGet]
        [Route("GetApplicants")]
        public HttpResponseMessage GetApplicants()
        {
            var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(accountDal.GetApplicants());
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("sendotpemail")]
        public HttpResponseMessage SendOtpEmail(string email)
        {
            var password = ExternalPlugin.CreateRandomPassword();
            bool issuccess = ResetPassword(email, password);
            if (issuccess)
            {
                EmailTemplate emailtemplate = new EmailTemplate();
                emailtemplate.Email = email;
                emailtemplate.Subject = "User Forgot Password Alert";
                emailtemplate.Body = "Password to login : " + password;
                var result = ExternalPlugin.SendEmail(emailtemplate);
            }
            return Request.CreateResponse(issuccess);
        }

        public bool ResetPassword(string email, string password)
        {
            var result = accountDal.ResetPassword(email, password);
            return result;
        }

        //[HttpPost]
        //[Route("PostApplicant")]
        //public HttpResponseMessage PostApplicant(ApplicantDetail app)
        //{
        //    app.RefNumber=ExternalPlugin.GenerateRandomNo().ToString();
        //    var result = accountDal.SaveApplicant(Mapper.Map<ApplicantDetail, GulfBridge.DAL.dbContext.ApplicantDetail>(app));
        //    return Request.CreateResponse(result);
        //}


        [HttpPost]
        [Route("PostApplicant")]
        public HttpResponseMessage PostApplicant(ApplicantRegistration app)
        {
            ApplicantDetail applicantdetals = null;
            bool result = false;
            try
            {
                app.AspNetUser.PasswordHash = ExternalPlugin.CreateRandomPassword();
                //app.AspNetUser.PasswordHash = "123456";
                //app.AspNetUser.PasswordHash=ExternalPlugin.EncodePasswordToBase64(app.AspNetUser.PasswordHash);
                var userrecor = accountDal.SaveUser(Mapper.Map<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>(app.AspNetUser));
                if (userrecor != null)
                {
                    //string data = RefNumberKey + ExternalPlugin.GenerateRandomNo().ToString();
                    //var rec = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(accountDal.GetApplicants());
                    //DateTime dateref = Convert.ToDateTime("2018-10-24");
                    //rec = rec.Where(a => a.CreatedOn <= dateref).ToList();
                    //rec = rec.Where(a => a.RefNumber == data).ToList();
               
                    //if (rec == null)
                    //app.ApplicantDetail.RefNumber = data;
                    //else
                    //{ 
                    // string data1 = RefNumberKey + ExternalPlugin.GenerateRandomNo().ToString();
                    // app.ApplicantDetail.RefNumber = data1;
                    //}
  
                    app.ApplicantDetail.RefNumber = RefNumberKey + ExternalPlugin.GenerateRandomNo().ToString()+ ExternalPlugin.GenerateRandomText().ToString();
                    DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
                    string datewithtime = date.Year.ToString() + date.Month.ToString("00") + date.Day.ToString("00") + date.TimeOfDay.Hours.ToString("00") + date.TimeOfDay.Minutes.ToString("00");
                    app.ApplicantDetail.GBSRefNo = GBSRefNo + "" + datewithtime;
                    app.ApplicantDetail.UserId = userrecor.Id;
                    applicantdetals = Mapper.Map<GulfBridge.DAL.dbContext.ApplicantDetail, ApplicantDetail>(accountDal.SaveApplicant(Mapper.Map<ApplicantDetail, GulfBridge.DAL.dbContext.ApplicantDetail>(app.ApplicantDetail)));
                    app.AplicantPersonalInfo.ApplicantId = applicantdetals.Id;
                }
                if (app.AplicantPersonalInfo != null)
                {
                    result = accountDal.SaveApplicantPersonal(Mapper.Map<AplicantPersonalInfo, GulfBridge.DAL.dbContext.AplicantPersonalInfo>(app.AplicantPersonalInfo));
                    if (result)
                    {
                        EmailTemplate email = new EmailTemplate();

                        email.Email = app.AspNetUser.Email;
                        app.AspNetUser.UserName = app.ApplicantDetail.FullName;
                        email.Subject = "PSV User Login Password";
                        email.Body = ExternalPlugin.ReadEmailTemplate(app.AspNetUser);
                        result = ExternalPlugin.SendEmail(email);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("class:AccountController , method:PostApplicant  Exception is :", e);
            }
            return Request.CreateResponse(result);
        }




        [HttpPost]
        [Route("PostEmployeer")]
        public HttpResponseMessage PostEmployeer(AspNetUser emper)
        {
            bool result = false;
            try
            {
                emper.UserType = 2;
                emper.IsActive = false;
                var userrecor = accountDal.SaveUser(Mapper.Map<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>(emper));
                if (userrecor != null)
                    result = true;

            }
            catch (Exception e)
            {
                logger.Error("Exception is:" + e.Message + "Exception StackTrace" + e.StackTrace + "Exception Cls Name:AccountController & Method Name:PostEmployeer");
                result = false;
            }
            return Request.CreateResponse(result);
        }


        [HttpPost]
        [Route("PostEmployeerInfo")]
        public HttpResponseMessage PostEmployeer(EmployeerModel emper)
        {
            bool result = false;
            try
            {
                emper.usersinfo.UserType = 2;
                emper.usersinfo.IsActive = true;
                var userrecor = accountDal.SaveUser(Mapper.Map<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>(emper.usersinfo));
                if (userrecor != null)
                {
                    var userreo = Mapper.Map<GulfBridge.DAL.dbContext.AspNetUser, AspNetUser>(userrecor);
                    emper.EmpDetails.UserId = userreo.Id;
                    emper.EmpDetails.IsActive = true;
                    emper.EmpDetails.CreatedOn = DateTime.UtcNow;
                    var empstatus = accountDal.SaveEmplrDetails(Mapper.Map<EmployerDetails, GulfBridge.DAL.dbContext.EmployerDetail>(emper.EmpDetails));
                    if (empstatus != null)
                    {
                        var emprecord = Mapper.Map<GulfBridge.DAL.dbContext.EmployerDetail, EmployerDetails>(empstatus);
                        foreach (ApplicantDetail appl in emper.ApplicantList)
                        {
                            appl.UserId = userrecor.Id;
                            appl.RefNumber = ExternalPlugin.GenerateRandomNo().ToString();
                            appl.IsActive = true;
                            appl.CreatedOn = DateTime.UtcNow;
                            appl.Status = 1;
                            //appl.EmployerId = emprecord.Id;
                        }
                        result = accountDal.SaveEmplrApplicants(Mapper.Map<List<ApplicantDetail>, List<GulfBridge.DAL.dbContext.ApplicantDetail>>(emper.ApplicantList));
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception is:" + e.Message + "Exception StackTrace" + e.StackTrace + "Exception Cls Name:AccountController & Method Name:PostEmployeer");
                result = false;
            }
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("login")]
        public HttpResponseMessage Login(string email, string password)
        {
            var result = accountDal.Login(email, password);
            var user = Mapper.Map<GulfBridge.DAL.dbContext.AspNetUser, AspNetUser>(result);
            return Request.CreateResponse(user);
        }

        [HttpGet]
        [Route("IsValidEmail")]
        public HttpResponseMessage IsValidEmail(string email, string UserId)
        {
            var result = accountDal.IsValidEmail(email, UserId);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("IsApplicantEmail")]
        public HttpResponseMessage IsApplicantEmail(string email)
        {
            var result = accountDal.IsApplicantEmail(email);
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("ResetPassword")]
        public HttpResponseMessage ResetPassword(ChangePasswordEntity chng)
        {
            var result = accountDal.ResetPassword(chng.UserId, chng.OldPassword, chng.NewPassword);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getApplicantRefDob")]
        public HttpResponseMessage GetApplicantRefDob(string refNo, DateTime dob)
        {
            ApllicantStatusEntity apsten = null;
            var result = accountDal.GetApplicantRefDob(refNo, dob);
            if (result!=null)
            {
                apsten = new ApllicantStatusEntity();
                apsten.ApplicantDetail = result;
                if (apsten.ApplicantDetail.IsPaymentDone == true)
                {
                    apsten = GetOtherStatusReport(apsten);
                }
            }
            return Request.CreateResponse(apsten);
        }

        public ApllicantStatusEntity GetOtherStatusReport(ApllicantStatusEntity apsten)
        {
            apsten.AcademicStatus = Mapper.Map<object, List<AcademicStatus>>(accountDal.GetAcademicReport(apsten.ApplicantDetail.Id));
            apsten.LicenseStatus = Mapper.Map<object, List<LicenseStatus>>(accountDal.GetLicenseReport(apsten.ApplicantDetail.Id));
            apsten.WorkExpStatus = Mapper.Map<object, List<WorkExpStatus>>(accountDal.GetWorkExpReport(apsten.ApplicantDetail.Id));
            apsten.CogsStatus = Mapper.Map<object, List<CogsStatus>>(accountDal.GetCogsReport(apsten.ApplicantDetail.Id));
            apsten.LogbookStatus = Mapper.Map<object, List<LogbookStatus>>(accountDal.GetLogbookReport(apsten.ApplicantDetail.Id));
            return apsten;
        }


    }
}
