namespace OregoFramework.Util
{
    public interface ICloneable<out T> where T : ICloneable<T>
    {
        T Clone();
    }
}