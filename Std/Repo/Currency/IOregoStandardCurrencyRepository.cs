namespace OregoFramework.Repo
{
    public interface IOregoStandardCurrencyRepository<T> : IOregoReadyDataRepository<T>
        where T : IOregoCurrencyData
    {
        T GetCurrencyData();

        void SetCurrencyData(T currencyData);
    }
}