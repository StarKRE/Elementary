namespace ElementaryFramework.Util
{
    public interface IUpdateBehaviour
    {
        AutoEvent<object, IUpdateBehaviour> OnUpdatedEvent { get; }
        
        void OnUpdate(object sender);
    }
}