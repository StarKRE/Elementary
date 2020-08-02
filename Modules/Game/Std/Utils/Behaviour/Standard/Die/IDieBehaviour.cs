namespace ElementaryFramework.Util
{
    public interface IDieBehaviour : IBehaviour
    {
        AutoEvent<object, IDieBehaviour> OnDieEvent { get; }

        void OnDie(object sender);
    }
}