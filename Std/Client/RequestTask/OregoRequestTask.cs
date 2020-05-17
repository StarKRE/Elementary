using UnityEngine.Networking;

namespace OregoFramework.Client
{
    public sealed class OregoRequestTask
    {
        public OregoRequestState state { get; set; }

        public UnityWebRequest unityWebRequest { get; }

        public OregoRequestTask(UnityWebRequest webRequest)
        {
            this.state = OregoRequestState.PENDING;
            this.unityWebRequest = webRequest;
        }
    }
    
    public enum OregoRequestState
    {
        PENDING,
        PROCESSING,
        CANCELED,
        FINISHED
    }
}