using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class AplicantPersonalInfo
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string QIDNumber { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<int> QatarType { get; set; }
        public string PAddress { get; set; }
        public string PCity { get; set; }
        public Nullable<int> PCountry { get; set; }
        public string CAddress { get; set; }
        public string CCity { get; set; }
        public Nullable<int> CCountry { get; set; }
        public string PContactNumber { get; set; }
        public string AContactNumber { get; set; }
        public string RegisteredEmail { get; set; }
        public string PassportBioFilePath { get; set; }
        public string NCCertificatePath { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public string CountryName { get; set; }
        public string QatarTypeName { get; set; }

        public string PotentialPlaceOfWork { get; set; }
        public Nullable<int> IdentityStatus { get; set; }
        public string PCountryCode { get; set; }
        public string ACountryCode { get; set; }

    }
}
