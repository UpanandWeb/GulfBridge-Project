using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class ApplicantProfLicStatus
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Nullable<int> IssuingAuthority { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> Title { get; set; }
        public Nullable<int> LicenseNo { get; set; }
        public Nullable<int> Validity { get; set; }
        public Nullable<int> IssueExpiry { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public int LicenseId { get; set; }
    }
}
