using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class PaymentStructure
    {
        public int Id { get; set; }
        public Nullable<int> AppCategoryId { get; set; }
        public Nullable<int> AppSubCatgoryId { get; set; }
        public Nullable<decimal> PackageAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
