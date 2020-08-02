using UnityEngine.Networking;

namespace ElementaryFramework.App
{
    public sealed class RequestTask
    {
        public RequestState state { get; set; }

        public UnityWebRequest unityWebRequest { get; }

        public RequestTask(UnityWebRequest webRequest)
        {
            this.state = RequestState.PENDING;
            this.unityWebRequest = webRequest;
        }
    }
    
    public enum RequestState
    {
        PENDING,
        PROCESSING,
        CANCELED,
        FINISHED
    }
}