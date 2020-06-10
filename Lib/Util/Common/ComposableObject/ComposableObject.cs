namespace OregoFramework.Util
{
    public class ComposableObject<TInfo, TState> : IComposableObject
    {
        private readonly TInfo info;

        private readonly TState state;

        public ComposableObject(TInfo info, TState state)
        {
            this.info = info;
            this.state = state;
        }

        public I GetInfo<I>()
        {
            return (I) (object) this.info;
        }

        public S GetState<S>()
        {
            return (S) (object) this.state;
        }
    }
}