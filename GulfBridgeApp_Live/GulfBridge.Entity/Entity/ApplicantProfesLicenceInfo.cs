using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class ApplicantProfesLicenceInfo
    {
        public int Id { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public string FullName { get; set; }
        public string IssueAuthority { get; set; }
        public Nullable<int> Country { get; set; }
        public string LTitle { get; set; }
        public Nullable<int> LType { get; set; }
        public Nullable<int> LStatus { get; set; }
        public string LNumber { get; set; }
        public Nullable<System.DateTime> LIssueDate { get; set; }
        public Nullable<System.DateTime> LExpiryDate { get; set; }
        public string NursingLicencePath { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CountryName { get; set; }
        public string LTypeName { get; set; }

        public string City { get; set; }
    }
}
