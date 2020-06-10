using System;

namespace OregoFramework.Util
{
    public interface IPaymentModule
    {
        event Action<object, PaymentResult> OnPaymentFinishedEvent;
        
        void Pay(object sender, PaymentParams paymentParams);
    }
}