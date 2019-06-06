using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class PaymentTransactionDetail
    {
        public int Id { get; set; }
        public string ApplicantId { get; set; }
        public string vpc_TxnResponseCode { get; set; }
        public string vpc_MerchTxnRef { get; set; }
        public string vpc_OrderInfo { get; set; }
        public string vpc_Merchant { get; set; }
        public string vpc_Amount { get; set; }
        public string vpc_Message { get; set; }
        public string vpc_ReceiptNo { get; set; }
        public string vpc_AcqResponseCode { get; set; }
        public string vpc_AuthorizeId { get; set; }
        public string vpc_BatchNo { get; set; }
        public string vpc_TransactionNo { get; set; }
        public string vpc_Card { get; set; }
        public string vpc_3DSECI { get; set; }
        public string vpc_3DSXID { get; set; }
        public string vpc_3DSenrolled { get; set; }
        public string vpc_3DSstatus { get; set; }
        public string vpc_VerToken { get; set; }
        public string vpc_VerType { get; set; }
        public string vpc_VerSecurityLevel { get; set; }
        public string vpc_VerStatus { get; set; }
        public string vpc_RiskOverallResult { get; set; }
        public string vpc_TxnReversalResult { get; set; }
        public string vpc_cscResultCode { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
