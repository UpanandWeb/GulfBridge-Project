using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class ApplicantDetail
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> EmployeerId { get; set; }
        public string FullName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string CurrentResidency { get; set; }
        public string PassportNumber { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Profession { get; set; }
        public Nullable<int> Nationality { get; set; }
        public string NationalityName { get; set; }
        public Nullable<int> AppicationType { get; set; }
        public string AppicationTypeName { get; set; }
        public Nullable<int> Status { get; set; }
        public string StatusName { get; set; }
        public Nullable<decimal> PackageAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsTermsAgree { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

        public IEnumerable<CommonType> AppTypes; 
      
        public IEnumerable<CommonType> Countries;
        public Nullable<int> AppCategory { get; set; }
        public string AppCategoryName { get; set; }
        public Nullable<int> AppSubCategory { get; set; }
        public string LicenceNumber { get; set; }
        public string QCHPNumber { get; set; }
        public string RefNumber { get; set; }
        public string StatusReport_Path { get; set; }
        public Nullable<bool> IsPaymentDone { get; set; }
        public string PaymentReceiptPath { get; set; }
        public Nullable<bool> IsConformSubmit { get; set; }
        public Nullable<int> PaymentOption { get; set; }
        public string PaymentReference { get; set; }
        public string LicenseImageFile { get; set; }
        public string LicenseImagepath { get; set; }
        public string GBSRefNo { get; set; }
        public Nullable<int> DaysCount { get; set; }
        public string CountryCode { get; set; }
        public Nullable<System.DateTime> InProgressDate { get; set; }
        public string AnnexureReport_Path { get; set; }
    }
}
