namespace OregoFramework.Util
{
    public interface IComposableObject
    {
        I GetInfo<I>();

        S GetState<S>();
    }
}