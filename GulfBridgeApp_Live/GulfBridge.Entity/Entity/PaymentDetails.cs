using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class PaymentDetails
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal PayAmount { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string BankDescription { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public int ApplicantId { get; set; }
    }
}
