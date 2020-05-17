namespace OregoFramework.Util
{
    public interface IPaymentSystem
    {
        T GetModule<T>() where T : IPaymentModule;
    }
}