using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class Certificate_DocumentType1
    {
        public int Id { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public string Name { get; set; }
        public string AuthorityName { get; set; }
        public string City { get; set; }
        public Nullable<int> Country { get; set; }
        public string ContactNumber { get; set; }
        public string CertificateTitle { get; set; }
        public Nullable<int> CertificateType { get; set; }
        public Nullable<int> CertificateStatus { get; set; }
        public string CertificateNumber { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string CertificatePath { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
