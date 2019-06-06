using GulfBridge.DAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GulfBridge.Entity.Entity;
using AutoMapper;
using GulfBridge.DAL.DAL;
using System.IO;
using HtmlAgilityPack;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using GulfBridge.Api.App_Start;
using System.Web;
using iTextSharp.tool.xml.html.table;
using System.Text;

namespace GulfBridge.Api.Controllers
{
    [RoutePrefix("api/applicant")]
    [Authorize]
    public class ApplicantController : ApiController
    {
        //public IApplicantDAL apliDAL;
        //public ApplicantController(IApplicantDAL _apliDAL)
        //{
        //    this.apliDAL = _apliDAL;
        //}

        public static string RefNumberKey = ConfigurationManager.AppSettings["RefNumberKey"];
        public static string GBSRefNo = ConfigurationManager.AppSettings["GBSRefNo"];

        public ApplicantDAL apliDAL = new ApplicantDAL();

        [HttpGet]
        [Route("IsOldPassword")]
        public HttpResponseMessage IsOldPassword(string OldPsw, string UserId)
        {
            var result = apliDAL.IsOldPassword(OldPsw, UserId);
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("GetGbsRefNo")]
        public HttpResponseMessage GetGbsRefNo(string QCHPNumber)
        {
            var result = apliDAL.GetGbsRefNo(QCHPNumber);
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("changePassword")]
        public HttpResponseMessage ChangePassword(ChangePasswordEntity chngpwd)
        {
            string userid = chngpwd.UserId;
            string pwd = chngpwd.NewPassword;
            var result = apliDAL.ChangePassword(userid, pwd);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getFilledData")]
        public HttpResponseMessage GetFilledData(int ApplicantId)
        {
            var result = apliDAL.GetFilledData(ApplicantId);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getapplicant")]
        public HttpResponseMessage GetApplicant(string UserId)
        {
            var result = apliDAL.GetApplicant(UserId);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getapplicantId")]
        public HttpResponseMessage GetApplicant(int ApplicantId)
        {
            var result = apliDAL.GetApplicantId(ApplicantId);
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("getapplicantById")]
        public HttpResponseMessage GetApplicantById(int ApplicantId)
        {
            var result = apliDAL.GetApplicantById(ApplicantId);
            return Request.CreateResponse(result);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("saveapplicant")]
        public HttpResponseMessage SaveApplicant(ApplicantDetail model)
        {
            model.Status = 1; 
            model.IsActive = true;
            if (string.IsNullOrEmpty(model.RefNumber))
                //model.RefNumber = RefNumberKey + ExternalPlugin.GenerateRandomNo().ToString();
            model.RefNumber = RefNumberKey + ExternalPlugin.GenerateRandomNo().ToString() + ExternalPlugin.GenerateRandomText().ToString();
            if (string.IsNullOrEmpty(model.GBSRefNo))
            {
                DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
                string datewithtime = date.Year.ToString() + date.Month.ToString("00") + date.Day.ToString("00") + date.TimeOfDay.Hours.ToString("00") + date.TimeOfDay.Minutes.ToString("00");
                model.GBSRefNo = GBSRefNo + "" + datewithtime;
            }
            var result = apliDAL.SaveApplicant(Mapper.Map<ApplicantDetail, GulfBridge.DAL.dbContext.ApplicantDetail>(model));
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("saveempapplicant")]
        public HttpResponseMessage SaveEmpApplicant(ApplicantDetail appdetail)
        {
            appdetail.IsActive = true;
            var result = apliDAL.SaveEmpApplicant(Mapper.Map<ApplicantDetail, GulfBridge.DAL.dbContext.ApplicantDetail>(appdetail));
            return Request.CreateResponse(Mapper.Map<GulfBridge.DAL.dbContext.ApplicantDetail, ApplicantDetail>(result));
        }

        [HttpPost]
        [Route("savepersonal")]
        public HttpResponseMessage SavePersonalInfo(AplicantPersonalInfo apppersonal)
        {
            apppersonal.IsActive = true;
            var result = apliDAL.SavePersonalInfo(Mapper.Map<AplicantPersonalInfo, GulfBridge.DAL.dbContext.AplicantPersonalInfo>(apppersonal));
            return Request.CreateResponse(result);
        }

        [Route("getpersonal")]
        public HttpResponseMessage GetPersonalInfo(int ApplicantId)
        {
            //var result = Mapper.Map<GulfBridge.DAL.dbContext.AplicantPersonalInfo, AplicantPersonalInfo>(apliDAL.GetPersonalInfo(ApplicantId));
            var result = apliDAL.GetPersonalInfo(ApplicantId);
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("saveacademic")]
        public HttpResponseMessage SaveAcademicInfo(ApplicantAcademicInfo appacademinc)
        {
            appacademinc.IsActive = true;
            var result = apliDAL.SaveAcademicInfo(Mapper.Map<ApplicantAcademicInfo, GulfBridge.DAL.dbContext.ApplicantAcademicInfo>(appacademinc));
            //return Request.CreateResponse(Mapper.Map<GulfBridge.DAL.dbContext.ApplicantAcademicInfo, ApplicantAcademicInfo>(result));
            return Request.CreateResponse(result);
        }


        [Route("getacademic")]
        public HttpResponseMessage GetAcademic(int ApplicantId)
        {
            //var result = Mapper.Map<GulfBridge.DAL.dbContext.ApplicantAcademicInfo, ApplicantAcademicInfo>(apliDAL.GetAcademic(ApplicantId));
            var result = apliDAL.GetAcademic(ApplicantId);
            return Request.CreateResponse(result);
        }

        [Route("getAcademicInfo")]
        public HttpResponseMessage GetAcademicInfo(int AcademincId)
        {
            //var result = Mapper.Map<GulfBridge.DAL.dbContext.ApplicantAcademicInfo, ApplicantAcademicInfo>(apliDAL.GetAcademic(ApplicantId));
            var result = apliDAL.GetAcademicInfo(AcademincId);
            return Request.CreateResponse(result);
        }
        [HttpPost]
        [Route("saveproflicenceinfo")]
        public HttpResponseMessage SaveProfLicenceInfo(ApplicantProfesLicenceInfo appprolice)
        {
            appprolice.IsActive = true;
            var result = apliDAL.SaveProfLicenceInfo(Mapper.Map<ApplicantProfesLicenceInfo, GulfBridge.DAL.dbContext.ApplicantProfesLicenceInfo>(appprolice));
            //return Request.CreateResponse(Mapper.Map<GulfBridge.DAL.dbContext.ApplicantProfesLicenceInfo, ApplicantProfesLicenceInfo>(result));
            return Request.CreateResponse(result);
        }


        [Route("getproflicenceinfo")]
        public HttpResponseMessage GetProfLicenceInfo(int ApplicantId)
        {
            //var result = Mapper.Map<GulfBridge.DAL.dbContext.ApplicantProfesLicenceInfo, ApplicantProfesLicenceInfo>(apliDAL.GetProfLicenceInfo(ApplicantId));
            var result = apliDAL.GetProfLicenceInfo(ApplicantId);
            return Request.CreateResponse(result);
        }


        [Route("getproflicence")]
        public HttpResponseMessage GetProfLicence(int ProfLicId)
        {
            //var result = Mapper.Map<GulfBridge.DAL.dbContext.ApplicantProfesLicenceInfo, ApplicantProfesLicenceInfo>(apliDAL.GetProfLicenceInfo(ApplicantId));
            var result = apliDAL.GetProfLicence(ProfLicId);
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("saveworkexpinfo")]
        public HttpResponseMessage SaveWorkExpInfo(ApplicantWorkExpInfo appwork)
        {
            appwork.IsActive = true;
            var result = apliDAL.SaveWorkExpInfo(Mapper.Map<ApplicantWorkExpInfo, GulfBridge.DAL.dbContext.ApplicantWorkExpInfo>(appwork));
            //return Request.CreateResponse(Mapper.Map<GulfBridge.DAL.dbContext.ApplicantWorkExpInfo, ApplicantWorkExpInfo>(result));
            return Request.CreateResponse(result);
        }


        [Route("getworkexpinfo")]
        public HttpResponseMessage GetWorkExpInfo(int ApplicantId)
        {
            //var result = Mapper.Map<GulfBridge.DAL.dbContext.ApplicantWorkExpInfo, ApplicantWorkExpInfo>(apliDAL.GetWorkExpInfo(ApplicantId));
            var result = apliDAL.GetWorkExpInfo(ApplicantId);
            return Request.CreateResponse(result);
        }


        [Route("getworkexp")]
        public HttpResponseMessage GetWorkExp(int WorkId)
        {
            //var result = Mapper.Map<GulfBridge.DAL.dbContext.ApplicantWorkExpInfo, ApplicantWorkExpInfo>(apliDAL.GetWorkExpInfo(ApplicantId));
            var result = apliDAL.GetWorkExp(WorkId);
            return Request.CreateResponse(result);
        }


        [HttpPost]
        [Route("savedocumenttype1")]
        public HttpResponseMessage SaveDocumentType1(Certificate_DocumentType1 certdoc1)
        {
            certdoc1.IsActive = true;
            var result = apliDAL.SaveDocumentType1(Mapper.Map<Certificate_DocumentType1, GulfBridge.DAL.dbContext.Certificate_DocumentType1>(certdoc1));
            //return Request.CreateResponse(Mapper.Map<GulfBridge.DAL.dbContext.Certificate_DocumentType1, Certificate_DocumentType1>(result));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getdocumenttype1")]
        public HttpResponseMessage GetDocumentType1(int ApplicantId)
        {
            var result = apliDAL.GetDocumentType1(ApplicantId);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getdocument")]
        public HttpResponseMessage GetDocument(int DocId)
        {
            var result = apliDAL.GetDocument(DocId);
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("savedocumenttype2")]
        public HttpResponseMessage SaveDocumentType2(Certificate_DocumentType2 certdoc2)
        {
            var result = apliDAL.SaveDocumentType2(Mapper.Map<Certificate_DocumentType2, GulfBridge.DAL.dbContext.Certificate_DocumentType2>(certdoc2));
            //return Request.CreateResponse(Mapper.Map<GulfBridge.DAL.dbContext.Certificate_DocumentType2, Certificate_DocumentType2>(result));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getlogbook")]
        public HttpResponseMessage GetLogBook(int ApplicantId)
        {
            var result = apliDAL.GetLogBook(ApplicantId);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getlogbookInfo")]
        public HttpResponseMessage GetLogBookInfo(int LogId)
        {
            var result = apliDAL.GetLogBookInfo(LogId);
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("saveletterauthority")]
        public HttpResponseMessage SaveLetterAuthority(LetterOfAuthorization loa)
        {
            loa.IsActive = true;
            var result = apliDAL.SaveLetterAuthority(Mapper.Map<LetterOfAuthorization, GulfBridge.DAL.dbContext.LetterOfAuthorization>(loa));
            //return Request.CreateResponse(Mapper.Map<GulfBridge.DAL.dbContext.LetterOfAuthorization, LetterOfAuthorization>(result));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("getletterauthority")]
        public HttpResponseMessage GetLetterAuthority(int ApplicantId)
        {
            var result = apliDAL.GetLetterAuthority(ApplicantId);
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("updateFinalSubmit")]
        public HttpResponseMessage UpdateFinalSubmit(int ApplicantId, bool IsConformSubmit)
        {
            var result = apliDAL.UpdateFinalSubmit(ApplicantId, IsConformSubmit);
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("updatePayPerson")]
        public HttpResponseMessage UpdatePayPerson(int ApplicantId, bool PaymentOption)
        {
            var result = apliDAL.UpdatePayPerson(ApplicantId, PaymentOption);
            return Request.CreateResponse(result);
        }


        [HttpGet]
        [Route("updatetermsAgree")]
        public HttpResponseMessage UpdateTermsAgree(int ApplicantId, bool IstermsAggree, bool IsEmployer=false)
        {
            if (IsEmployer)
            {
                var result = (new EmployerDAL()).UpdateDisclaimerStatus(ApplicantId, IstermsAggree);
                return Request.CreateResponse(result);
            }
            else
            {
                var result = apliDAL.UpdateTermsAgree(ApplicantId, IstermsAggree);
                return Request.CreateResponse(result);
            }
        }

        [HttpPost]
        [Route("savePaymentDetails")]
        public HttpResponseMessage SavePaymentDetails(PaymentDetails model)
        {
            try
            {
                model = Mapper.Map<GulfBridge.DAL.dbContext.PaymentDetail, PaymentDetails>(apliDAL.SavePaymentDetails(Mapper.Map<PaymentDetails, GulfBridge.DAL.dbContext.PaymentDetail>(model)));
            }
            catch (Exception e) { }
            return Request.CreateResponse(model);
        }


        public PDFEntity GetPDFDetails(int ApplicantId)
        {
            PDFEntity pdfdetails = null;
            try
            {
                pdfdetails = apliDAL.GetPDFDetails(ApplicantId);
            }
            catch (Exception e) { }
            return pdfdetails;
        }


        [HttpGet]
        [Route("ReadPaymentPDF")]
        public string ReadPaymentPDF(int ApplicantId)
        {
            PDFEntity pdfDetails = GetPDFDetails(ApplicantId);
            string RefNo = string.Empty;
            string html = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("/ui/" + ConfigurationManager.AppSettings["PaymentReceipt"]));
            //html = html.Replace("%backimg%", System.Web.Hosting.HostingEnvironment.MapPath("/img/" + ConfigurationManager.AppSettings["BackgroundImg"]));
            html = html.Replace("%logo%", System.Web.Hosting.HostingEnvironment.MapPath("/img/" + ConfigurationManager.AppSettings["LogoImg"]));
            if (pdfDetails != null)
            {
                RefNo = pdfDetails.CandidateRefNo;
                html = html.Replace("%paymentdate%", pdfDetails.PaymentDate.ToString());
                html = html.Replace("%candidatename%", pdfDetails.CandidateName.ToString());
                html = html.Replace("%passportno%", pdfDetails.PassportNo.ToString());
                html = html.Replace("%gbsrrefno%", pdfDetails.GBSRefNo.ToString());
                html = html.Replace("%candidaterefno%", pdfDetails.CandidateRefNo.ToString());
                html = html.Replace("%selectedpackage%", pdfDetails.SelectedPSV.ToString());
                int i = 0;
                StringBuilder sb = new StringBuilder();
                foreach (DocumentFields acadamic in pdfDetails.Documents)
                {
                    sb.Append("<tr>");
                    sb.Append("<td style='border: 1px solid #000; padding: 8px;line-height: 1.42857143;vertical-align: top; font-family: 'Raleway', sans-serif;font-size: 14px;'>");
                    sb.Append(acadamic.Category.ToString());
                    sb.Append("</td>");
                    sb.Append("<td style='border: 1px solid #000; padding: 8px;line-height: 1.42857143;vertical-align: top; font-family: 'Raleway', sans-serif;font-size: 14px;'>");
                    sb.Append(acadamic.NoOfDocuments.ToString());
                    sb.Append("</td");
                    sb.Append("<td style='border: 1px solid #000; padding: 8px;line-height: 1.42857143;vertical-align: top; font-family: 'Raleway', sans-serif;font-size: 14px;'>");
                    sb.Append(acadamic.IssueingAuthority);
                    sb.Append("</td>");
                    sb.Append("<td style='border: 1px solid #000; padding: 8px;line-height: 1.42857143;vertical-align: top; font-family: 'Raleway', sans-serif;font-size: 14px;'>");
                    sb.Append(acadamic.Details);
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                html = html.Replace("%tabledata%", sb.ToString());
                html = html.Replace("%totalfeepaid%", pdfDetails.TotalFeePaid.ToString());
                html = html.Replace("%modeofpayment%", pdfDetails.ModeOfPayment.ToString());
            }
            return GeneratePaymentPDF(html, RefNo);
        }

        public string GeneratePaymentPDF(string GridHtml,string Refno)
        {
            string PDFPath = string.Empty;
            string paymentpdfpath = System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["PaymentPDFPath"]);
            try
            {
                HtmlNode.ElementsFlags["meta"] = HtmlElementFlag.Closed;
                HtmlNode.ElementsFlags["img"] = HtmlElementFlag.Closed;
                HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Closed;
                HtmlDocument doc = new HtmlDocument();
                doc.OptionFixNestedTags = true;
                doc.LoadHtml(GridHtml);
                GridHtml = doc.DocumentNode.OuterHtml;
                using (MemoryStream stream = new System.IO.MemoryStream())
                {
                    StringReader sr = new StringReader(GridHtml);
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                    //PDFPath = paymentpdfpath + ConfigurationManager.AppSettings["PDFFileName"] + Guid.NewGuid().ToString() + ".pdf";
                    string filename = Refno+"_"+ConfigurationManager.AppSettings["PDFFileName"] +"_"+ Guid.NewGuid().ToString() + ".pdf";
                    PDFPath = System.Web.Hosting.HostingEnvironment.MapPath("/pdffile/" + filename);
                    FileStream file = new FileStream(PDFPath, System.IO.FileMode.CreateNew);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, file);
                    pdfDoc.Open();
                    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    if (PDFPath != null)
                    {
                        PDFPath = "~/pdffile/" + filename;
                    }
                }
            }
            catch (Exception e) { }
            return PDFPath;
        }


        [HttpPost]
        [Route("SavePaymentTransDetails")]
        public HttpResponseMessage SavePaymentTransactionDetails(PaymentTransactionDetail model)
        {
            if (model.vpc_3DSstatus == "Y" && model.vpc_TxnResponseCode != "0")
                model.vpc_3DSstatus = "N";

            if (model.vpc_3DSstatus == "M" && model.vpc_TxnResponseCode == "0")
                model.vpc_3DSstatus = "Y";
            var result = apliDAL.SavePaymentTransactionDetails(Mapper.Map<PaymentTransactionDetail, GulfBridge.DAL.dbContext.PaymentTransactionDetail>(model));

       
            if (model.vpc_3DSstatus == "Y" && model.vpc_TxnResponseCode == "0" )
            {
                PaymentDetails details = new PaymentDetails();
                string[] apparr = model.ApplicantId.Split(',');
                foreach (string aplint in apparr)
                {
                    details.ApplicantId = Convert.ToInt16(aplint);
                    details.Status = model.vpc_3DSstatus;
                    UpdateStatusPaymentDetails(details, 1);
                }
            }
            return Request.CreateResponse(result);
        }

        public bool UpdateStatusPaymentDetails(PaymentDetails model,int? PaymentOption)
        {
            var result = apliDAL.UpdatePaymentDetails(Mapper.Map<PaymentDetails, GulfBridge.DAL.dbContext.PaymentDetail>(model), PaymentOption);
            bool issuccess = UpdateStatusApplicantDetail(Mapper.Map<GulfBridge.DAL.dbContext.PaymentDetail, PaymentDetails>(result), PaymentOption);
            return issuccess;
        }

        public bool UpdateStatusApplicantDetail(PaymentDetails model, int? PaymentOption)
        {
            bool IsSuccess = false;
            string receiptPath = string.Empty;
            int status = 0;
            bool Ispaymentdone = false;
            if (model.Status == "Y")
            {
                receiptPath = ReadPaymentPDF(model.ApplicantId);
                var result = apliDAL.GetApplicantById(model.ApplicantId);
                EmailTemplate email = new EmailTemplate();
                email.AttachmentPath = System.Web.Hosting.HostingEnvironment.MapPath("/pdffile/" + receiptPath.Split('/')[2]);
                email.Subject = "Payment Success";
                //email.Subject = "Payment Conformation From GulfBridge";
                email.Body = ExternalPlugin.ReadPaymentConform(result.FullName,result.RefNumber);
                email.Email = result.EmailId.ToString();
                ExternalPlugin.SendEmailFromGmail(email);
                status = 3;
                Ispaymentdone = true;
            }
            else
                status = 4;

            IsSuccess = apliDAL.UpdateStatusApplicantDetail(model.ApplicantId, Ispaymentdone, receiptPath, status, PaymentOption);
            return IsSuccess;
        }

        [HttpGet]
        [Route("DeleteDocument")]
        public HttpResponseMessage DeleteDocument(int DeletedId, int FormType)
        {
            var result = apliDAL.DeleteDocument(DeletedId, FormType);
            return Request.CreateResponse(result);
        }
    }
}
