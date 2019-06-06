using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class LetterOfAuthorization
    {
        public int Id { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public string PassportNumber { get; set; }
        public string FullName { get; set; }
        public string PermanentAddress { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> City { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string SignedLOAPath { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public byte[] UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}
