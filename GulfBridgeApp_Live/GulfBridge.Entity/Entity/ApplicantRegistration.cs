using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class ApplicantRegistration
    {
        public AspNetUser AspNetUser { get; set; }
        public ApplicantDetail ApplicantDetail { get; set; }
        public AplicantPersonalInfo AplicantPersonalInfo { get; set; }
    }
}
