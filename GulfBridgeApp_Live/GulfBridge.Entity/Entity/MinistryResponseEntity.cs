using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class MinistryResponseEntity
    {
        public string VerificationRefNo { get; set; }
        public string BarCodeNo { get; set; }
        public string ApplicantName { get; set; }
        public DateTime DOB { get; set; }
        public string PassportNumber { get; set; }
        public DateTime CaseReceivedDate { get; set; }
        public string CaseStatus { get; set; }
        public string TypeOfApplication { get; set; }
             
    }
}
