using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class ApplicantWorkExpInfo
    {
        public int Id { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public string JobDesignation { get; set; }
        public string EmployeerName { get; set; }
        public string EmployeerAddress { get; set; }
        public string EmployeerCity { get; set; }
        public Nullable<int> EmployeerCountry { get; set; }
        public string StaffId { get; set; }
        public string EmployeerContactNumber { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<System.DateTime> EndingDate { get; set; }
        public Nullable<int> EmployeementType { get; set; }
        public string WorkExpCertificatePath { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string EmployeerCityName { get; set; }
        public string EmployeerCountryName { get; set; }
        public string EmployeementTypeName { get; set; }
        public string JobDesignationName { get; set; }
        public string ECountryCode { get; set; }
    }
}
