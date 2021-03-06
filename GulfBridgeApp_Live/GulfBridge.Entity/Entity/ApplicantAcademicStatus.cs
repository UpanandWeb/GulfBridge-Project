﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class ApplicantAcademicStatus
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Nullable<int> Qualification { get; set; }
        public Nullable<int> IssuingAuthority { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> ConferredDate { get; set; }
        public Nullable<int> DurationOfStudy { get; set; }
        public Nullable<int> ModeOfStudy { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public int AcademicId { get; set; }
    }
}
