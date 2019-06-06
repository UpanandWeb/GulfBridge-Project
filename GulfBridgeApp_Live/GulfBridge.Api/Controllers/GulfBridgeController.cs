using AutoMapper;
using GulfBridge.Api.App_Start;
using GulfBridge.DAL.DAL;
using GulfBridge.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace GulfBridge.Api.Controllers
{
    [RoutePrefix("api/gulfbridge")]
    [Authorize]
    public class GulfBridgeController : BaseController
    {
        //public IGulfBridgeDAL gulfBridgeDal;
        //public GulfBridgeController(IGulfBridgeDAL _gulfBridgeDal)
        //{
        //    this.gulfBridgeDal = _gulfBridgeDal;
        //}
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(GulfBridgeController));
        public GulfBridgeDAL gulfBridgeDal = new GulfBridgeDAL();


        [HttpGet]
        [Route("GetApplicants")]
        public HttpResponseMessage GetApplicants()
        {
            //var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(gulfBridgeDal.GetApplicants());
            var result = gulfBridgeDal.GetApplicants();
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("GetApplicantslistbydates")]
        public HttpResponseMessage GetApplicantslistbydates(DateTime fromdate, DateTime todate)
        {

            //var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(gulfBridgeDal.GetApplicants());
            var result = gulfBridgeDal.GetApplicantsListByDates(fromdate, todate);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("GetEmployeesList")]
        public HttpResponseMessage GetEmployeesList()
        {
            var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.EmployerDetail>, IEnumerable<EmployerDetails>>(gulfBridgeDal.GetEmployeesList());
            //var result = gulfBridgeDal.GetEmployeesList();
            return Request.CreateResponse(result);
        }



        [Route("GetEmployeeByID")]
        public HttpResponseMessage GetEmployeeByID(int empid)
        {
            //var result = Mapper.Map<GulfBridge.DAL.dbContext.EmployerDetail>, EmployerDetails(gulfBridgeDal.GetEmployeeDetailsByID(empid));
            var result = gulfBridgeDal.GetEmployeeDetailsByID(empid);
            return Request.CreateResponse(result);
        }

        [Route("UpdateEmployeeByID")]//changed by geetha
        public HttpResponseMessage UpdateEmployeeByID(EmployerDetails empdet)
        {
            AspNetUser user = new AspNetUser();
            user.Email = empdet.EmployerEmailaddress;
            user.PhoneNumber = empdet.EmployeerContactNo;
            user.Id = empdet.UserId;
            user.UserType = 2;
            var users = Mapper.Map<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>(user);
            var update1 = gulfBridgeDal.SaveUser(users);
            var result = Mapper.Map<EmployerDetails, GulfBridge.DAL.dbContext.EmployerDetail>(empdet);
            var update = gulfBridgeDal.SaveEmployeer(result);
            return Request.CreateResponse(update);
        }

        [HttpGet]
        [Route("DeleteEmployeeByID")]
        public HttpResponseMessage DeleteEmployeeByID(int empid)
        {
            var update = gulfBridgeDal.DeleteEmployeeByID(empid);
            return Request.CreateResponse(update);
        }

        [HttpGet]
        [Route("GetApplicantSearch")]
        public HttpResponseMessage GetApplicants(string name)
        {
            //var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(gulfBridgeDal.GetApplicants(name));
            var result = gulfBridgeDal.GetApplicants(name);
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("GetApplicantsbyStatus")]
        public HttpResponseMessage GetApplicantsbyStatus(int status)
        {
            var result = gulfBridgeDal.GetApplicantsbyStatus(status);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("GetApplicantInfo")]
        public HttpResponseMessage GetApplicantsInfo(int id)
        {
            var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(gulfBridgeDal.GetApplicantsInfo(id));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("GetEmplrActlist")]
        public HttpResponseMessage GetEmplrActivationList()
        {
            var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.AspNetUser>, IEnumerable<AspNetUser>>(gulfBridgeDal.GetEmplrActivationList());
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("UpdateRemarks")]
        public HttpResponseMessage UpdateRemarks(ApplicantDetail app)
        {
            var result = gulfBridgeDal.UpdateRemarks(Mapper.Map<ApplicantDetail, GulfBridge.DAL.dbContext.ApplicantDetail>(app));
            return Request.CreateResponse(result);
        }

        [Route("GetUserInfo")]
        public HttpResponseMessage GetUserInfo(string UserId)
        {
            var result = Mapper.Map<GulfBridge.DAL.dbContext.AspNetUser, AspNetUser>(gulfBridgeDal.GetUserInfo(UserId));
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("ActivateUser")]
        public HttpResponseMessage ActivateUser(AspNetUser user)
        {
            user.PasswordHash = "123456";
            user.IsActive = true;
            var result = gulfBridgeDal.ActivateUser(Mapper.Map<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>(user));
            return Request.CreateResponse(result);
        }

        [Route("GetEmpApplicantList")]
        public HttpResponseMessage GetApplicantList(string UserId)
        {
            //var result = Mapper.Map<IEnumerable<GulfBridge.DAL.dbContext.ApplicantDetail>, IEnumerable<ApplicantDetail>>(gulfBridgeDal.GetApplicantList(UserId));
            var result = gulfBridgeDal.GetApplicantList(UserId);
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("saveEmployeer")]
        public HttpResponseMessage SaveEmployeer(EmployerDetails emp)
        {
            logger.Info("Employeer SApi Called");
            bool result = false;
            try
            {
                AspNetUser user = new AspNetUser();
                user.Email = emp.EmployerEmailaddress;
                user.PhoneNumber = emp.EmployeerContactNo;
                user.UserType = 2;
                user.IsActive = true;
                user.PasswordHash = ExternalPlugin.CreateRandomPassword();
                // user.PasswordHash = "123456";
                user = Mapper.Map<GulfBridge.DAL.dbContext.AspNetUser, AspNetUser>(gulfBridgeDal.SaveUser(Mapper.Map<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>(user)));
                emp.UserId = user.Id;
                result = gulfBridgeDal.SaveEmployeer(Mapper.Map<EmployerDetails, GulfBridge.DAL.dbContext.EmployerDetail>(emp));
                if (result)
                {
                    EmailTemplate email = new EmailTemplate();
                    AspNetUser userinfo = new AspNetUser();
                    userinfo.Email = emp.EmployerEmailaddress;
                    userinfo.PasswordHash = user.PasswordHash;
                    userinfo.UserName = emp.EmployerName;
                    email.Email = emp.EmployerEmailaddress;
                    email.Subject = "PSV User Login and Password";

#if DEBUG
#else
                    email.CC_Email = "employer@gbsqchp.com";     
#endif
                    email.Body = ExternalPlugin.ReadEmailTemplate(userinfo);
                    result = ExternalPlugin.SendEmail(email);
                    logger.Info("Employeer Send Email Completed");
                }
            }
            catch (Exception e)
            {
                logger.Error("class:GulfBridgeController , method:SaveEmployeer  Exception is :", e);
            }
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("saveAdminUser")]
        public HttpResponseMessage SaveAdminUser(AspNetUser user)
        {
            logger.Info("Admin User Api Called");
            bool result = false;
            try
            {
                user.IsFirstLogin = true;                
                user.PasswordHash = ExternalPlugin.CreateRandomPassword();
                user = Mapper.Map<GulfBridge.DAL.dbContext.AspNetUser, AspNetUser>(gulfBridgeDal.SaveUser(Mapper.Map<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>(user)));
                if (user != null && !string.IsNullOrEmpty(user.Id))
                {
                    EmailTemplate email = new EmailTemplate();
                    AspNetUser userinfo = new AspNetUser();
                    email.Email = userinfo.Email = user.Email;
                    userinfo.PasswordHash = user.PasswordHash;
                    userinfo.UserName = user.UserName;

                    email.Subject = "PSV User Login and Password";
#if DEBUG
#else
                    email.CC_Email = "employer@gbsqchp.com";     
#endif
                    email.Body = ExternalPlugin.ReadEmailTemplate(userinfo);
                    result = ExternalPlugin.SendEmail(email);

                    logger.Info("AdminUser Send Email Completed");
                }
            }
            catch (Exception e)
            {
                logger.Error("class:GulfBridgeController , method:SaveAdminUser  Exception is :", e);
            }
            return Request.CreateResponse(result);
        }

        [Route("GetAdminUserID")]
        public HttpResponseMessage GetAdminUserID(string userid)
        {
            var result = gulfBridgeDal.GetAdminUserID(userid);

            return Request.CreateResponse(result);
        }

        [Route("UpdateAdminUserByID")]
        public HttpResponseMessage UpdateAdminUserByID(AspNetUser user)
        {
            var result = Mapper.Map<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>(user);
            var update = gulfBridgeDal.SaveUser(result);
            return Request.CreateResponse(update);
        }

        [HttpGet]
        [Route("DeleteAdminUserByID")]
        public HttpResponseMessage DeleteAdminUserByID(string userid)
        {
            var update = gulfBridgeDal.DeleteAdminUserByID(userid);
            return Request.CreateResponse(update);
        }

        [HttpGet]
        [Route("GetAdminList")]
        public HttpResponseMessage GetAdminList()
        {
            var result = gulfBridgeDal.GetAdminList();
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("personalStatus")]
        public HttpResponseMessage PersonalStatus(int ApplicantId, int IdentityStatus)
        {
            var result = gulfBridgeDal.personalStatus(ApplicantId, IdentityStatus);
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("getAcademicstatus")]
        public HttpResponseMessage GetAcademicStatus(int ApplicantId, int Id)
        {
            var result = gulfBridgeDal.GetAcademicStatus(ApplicantId, Id);
            return Request.CreateResponse(result);
        }



        [HttpPost]
        [Route("saveAcademicstatus")]
        public HttpResponseMessage SaveAcademicstatus(ApplicantAcademicStatus model)
        {
            var result = gulfBridgeDal.SaveAcademicstatus(Mapper.Map<ApplicantAcademicStatus, GulfBridge.DAL.dbContext.ApplicantAcademicStatu>(model));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getProfLicstatus")]
        public HttpResponseMessage GetProfLicStatus(int ApplicantId, int Id)
        {
            var result = gulfBridgeDal.GetProfLicStatus(ApplicantId, Id);
            return Request.CreateResponse(result);
        }


        [HttpPost]
        [Route("saveProfLicstatus")]
        public HttpResponseMessage SaveProLicStatus(ApplicantProfLicStatus model)
        {
            var result = gulfBridgeDal.SaveProLicStatus(Mapper.Map<ApplicantProfLicStatus, GulfBridge.DAL.dbContext.ApplicantProfLicStatu>(model));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getWorkExpstatus")]
        public HttpResponseMessage GetWorkExpStatus(int ApplicantId, int Id)
        {
            var result = gulfBridgeDal.GetWorkExpStatus(ApplicantId, Id);
            return Request.CreateResponse(result);
        }


        [HttpPost]
        [Route("saveWorkExpstatus")]
        public HttpResponseMessage SaveWorkExpStatus(ApplicantWorkExpStatus model)
        {
            var result = gulfBridgeDal.SaveWorkExpStatus(Mapper.Map<ApplicantWorkExpStatus, GulfBridge.DAL.dbContext.ApplicantWorkExpStatu>(model));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getCertificarDoc1status")]
        public HttpResponseMessage GetCertifiDoc1Status(int ApplicantId, int Id)
        {
            var result = gulfBridgeDal.GetCertifiDoc1Status(ApplicantId, Id);
            return Request.CreateResponse(result);
        }


        [HttpPost]
        [Route("saveCertifiDoc1status")]
        public HttpResponseMessage SaveCertifiDoc1Status(Certificate_Doc1_Status model)
        {
            var result = gulfBridgeDal.SaveCertifiDoc1Status(Mapper.Map<Certificate_Doc1_Status, GulfBridge.DAL.dbContext.Certificate_Doc1_Status>(model));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getLogbookstatus")]
        public HttpResponseMessage GetLogbookStatus(int ApplicantId, int Id)
        {
            var result = gulfBridgeDal.GetLogbookStatus(ApplicantId, Id);
            return Request.CreateResponse(result);
        }


        [HttpPost]
        [Route("saveLogbookstatus")]
        public HttpResponseMessage SaveLogbookStatus(LogBookStatus model)
        {
            var result = gulfBridgeDal.SaveLogbookStatus(Mapper.Map<LogBookStatus, GulfBridge.DAL.dbContext.LogBookStatu>(model));
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("savePDFReport")]
        public HttpResponseMessage SavePDFReport(int ApplicantId, string PDFReportPath, bool IsAnnexureReport)
        {
            var result = gulfBridgeDal.SavePDFReport(ApplicantId, PDFReportPath, IsAnnexureReport);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("updateStatus")]
        public HttpResponseMessage UpdateStatus(int status, int ApplicantId)
        {
            bool IsSuccess = false;
            var result = gulfBridgeDal.UpdateStatus(status, ApplicantId);
            if (result != null)
            {
                if (result.Status == 6)
                {
                    EmailTemplate email = new EmailTemplate();
                    email.Email = result.EmailId;
                    email.Subject = "Applicant Process Completed";
                    //email.Body = "Applicant Process Completed Status Updated Successfully";
                    email.Body = ExternalPlugin.ReadCompleteStats();
                    ExternalPlugin.SendEmail(email);
                }
                IsSuccess = true;
            }
            return Request.CreateResponse(IsSuccess);
        }


        [HttpGet]
        [Route("getpaypersonapplicants")]
        public HttpResponseMessage GetPayPersonApplicants()
        {
            var result = gulfBridgeDal.GetPayPersonApplicants();
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("updatePayRef")]
        [GulfActionLogFilter]
        public HttpResponseMessage UpdatePayRef(int ApplicantId, string PayRefNo, string UserID)
        {
            gulfBridgeDal.UserID = UserID;
            if (gulfBridgeDal.IsValidGBUser == false)
                return Request.CreateResponse(false);

            var result = gulfBridgeDal.UpdatePayRef(ApplicantId, PayRefNo, UserID);
            ApplicantController aplicntrl = new ApplicantController();
            var res = aplicntrl.UpdateStatusPaymentDetails(Mapper.Map<DAL.dbContext.PaymentDetail, PaymentDetails>(result), 2);
            return Request.CreateResponse(res);
        }

        [HttpGet]
        [Route("DeleteApplicant")]
        public HttpResponseMessage DeleteApplicant(int applicantID)
        {
            var result = gulfBridgeDal.DeleteApplicant(applicantID);
            return Request.CreateResponse(result);
        }


    }
}
