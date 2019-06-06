using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class LogBookStatus
    {
        public int Id { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public Nullable<int> IssueAuthority { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> Designation { get; set; }
        public Nullable<int> StartEndDate { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public int LogbookId { get; set; }
    }
}
