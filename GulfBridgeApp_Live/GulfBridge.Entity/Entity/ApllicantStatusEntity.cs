using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class ApllicantStatusEntity
    {
        public ApplicantDetail ApplicantDetail { get; set; }
        public List<AcademicStatus> AcademicStatus { get; set; }
        public List<LicenseStatus> LicenseStatus { get; set; }
        public List<WorkExpStatus> WorkExpStatus { get; set; }
        public List<CogsStatus> CogsStatus { get; set; }
        public List<LogbookStatus> LogbookStatus { get; set; }

    }

    public class AcademicStatus
    {
        public int AcademicId { get; set; }
        public string QualificationName { get; set; }
        public string IssuingAuthorityName { get; set; }
        public string CountryName { get; set; }
        public string ConferredDateName { get; set; }
        public string Comments { get; set; }
        public string QualificationAttained { get; set; }

    }

    public class LicenseStatus
    {
        public int LicenseId { get; set; }
        public string IssuingAuthorityName { get; set; }
        public string IssueAuthorityInfo { get; set; }
        public string CountryName { get; set; }
        public string TitleName { get; set; }
        public string LicenseNoName { get; set; }
        public string Comments { get; set; }
    }

    public class WorkExpStatus
    {
        public int WorkExpId { get; set; }
        public string EmployeerName { get; set; }
        public string DesignationName { get; set; }
        public string IssuingAuthorityName { get; set; }
        public string CountryName { get; set; }
        public string StartEndDateName { get; set; }
        public string Comments { get; set; }
    }

    public class CogsStatus
    {
        public int CogsId { get; set; }
        public string AuthorityName { get; set; }
        public string DesignationName { get; set; }
        public string IssuingAuthorityName { get; set; }
        public string CountryName { get; set; }
        public string StartEndDateName { get; set; }
        public string COGSValidityName { get; set; }
        public string COGSIssueExpiryDateName { get; set; }

        public string Comments { get; set; }
    }

    public class LogbookStatus
    {
        public int LogbookId { get; set; }
        public string EmployeerName { get; set; }
        public string DesignationName { get; set; }
        public string IssuingAuthorityName { get; set; }
        public string CountryName { get; set; }
        public string StartEndDateName { get; set; }
        public string Comments { get; set; }
    }


}
