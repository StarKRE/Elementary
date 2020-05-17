#if UNITY_PURCHASING
using UnityEngine.Purchasing;

namespace Orego.Domain
{
    public class UnityPaymentResult : PaymentResult
    {
        public PurchaseFailureReason failureReason { get; set; }
    }
}
#endif