using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class Certificate_DocumentType2
    {
        public int Id { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public string JobDesig { get; set; }
        public string EmployeerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> Country { get; set; }
        public string StaffId { get; set; }
        public string ContactNumber { get; set; }
        public Nullable<System.DateTime> Joiningdate { get; set; }
        public Nullable<System.DateTime> EndingDate { get; set; }
        public Nullable<int> EmployeeType { get; set; }
        public string LogDocumentPath { get; set; }
        public byte[] CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string JobDesigName { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string EmployeeTypeName { get; set; }
        public string CountryCode { get; set; }
    }
}
