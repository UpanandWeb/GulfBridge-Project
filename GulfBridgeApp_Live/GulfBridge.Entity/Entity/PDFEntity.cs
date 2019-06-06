using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class PDFEntity
    {
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public string PassportNo { get; set; }
        public string GBSRefNo { get; set; }
        public string CandidateRefNo { get; set; }
        public string SelectedPSV { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<DocumentFields> Documents { get; set; }
        public decimal TotalFeePaid { get; set; }
        public string ModeOfPayment { get; set; }
    }

    public class DocumentFields
    {
        public string Category { get; set; }
        public int NoOfDocuments { get; set; }
        public string IssueingAuthority { get; set; }
        public string Details { get; set; }
    }
}
