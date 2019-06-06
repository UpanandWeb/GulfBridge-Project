using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class EmployerDetails
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> ApplicantCount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string EmployerName { get; set; }
        public string EmployerCRNo { get; set; }
        public string PROsName { get; set; }
        public string PROsIDNo { get; set; }
        public string EmployeerAddress { get; set; }
        public string EmployeerContactNo { get; set; }
        public string PROContactNo { get; set; }
        public string EmployerEmailaddress { get; set; }
        public string PROEmailaddress { get; set; }
        public AspNetUser AspNetUser { get; set; }

        public bool IsTermsAgree { get; set; }
    }
}
