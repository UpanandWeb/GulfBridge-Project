using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class EmployeerModel
    {
        public AspNetUser usersinfo { get; set; }
        public ApplicantDetail Applicant { get; set; }
        public List<ApplicantDetail> ApplicantList { get; set; }
        public EmployerDetails EmpDetails { get; set; }
    }
}
