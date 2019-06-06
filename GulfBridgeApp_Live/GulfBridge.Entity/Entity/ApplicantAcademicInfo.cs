using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class ApplicantAcademicInfo
    {
        public int Id { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public string FullName { get; set; }
        public string UniversityName { get; set; }
        public string CollegeName { get; set; }
        public string CollegeCity { get; set; }
        public Nullable<int> CollegeCountry { get; set; }
        public string QualificationAttained { get; set; }
        public string MajorSubject { get; set; }
        public string CertificateNo { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<System.DateTime> EndingDate { get; set; }
        public Nullable<System.DateTime> GraduationDate { get; set; }
        public string EducationCertificatePath { get; set; }
        public string FinalMarksSheetPath { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CollegeCityName { get; set; }
        public string CollegeCountryName { get; set; }
    }
}
