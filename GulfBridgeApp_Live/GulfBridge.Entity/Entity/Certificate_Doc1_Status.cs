﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class Certificate_Doc1_Status
    {
        public int Id { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public Nullable<int> IssuingAuthority { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> Title { get; set; }
        public Nullable<int> LicenseNo { get; set; }
        public Nullable<int> COGSValidity { get; set; }
        public Nullable<int> COGSIssueExpiryDate { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public int CogsId { get; set; }
    }
}
