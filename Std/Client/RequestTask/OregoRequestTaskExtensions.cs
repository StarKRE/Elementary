using System;
using Newtonsoft.Json;

namespace OregoFramework.Client
{
    public static class OregoRequestTaskExtensions
    {
        public static string GetBodyString(this OregoRequestTask requestTask)
        {
            var currentWebRequest = requestTask.unityWebRequest;
            var downloadHandler = currentWebRequest.downloadHandler;
            return downloadHandler.text;
        }

        public static long GetResponseCode(this OregoRequestTask requestTask)
        {
            var currentWebRequest = requestTask.unityWebRequest;
            return currentWebRequest.responseCode;
        }

        public static bool DeserializeBody<T>(this OregoRequestTask requestTask, out T result)
        {
            try
            {
                var bodyString = requestTask.GetBodyString();
                result = JsonConvert.DeserializeObject<T>(bodyString);
                return true;
            }
            catch (Exception)
            {
                result = default(T);
                return false;
            }
        }

        public static void SetPending(this OregoRequestTask requestTask)
        {
            requestTask.state = OregoRequestState.PENDING;
        }

        public static bool IsPending(this OregoRequestTask requestTask)
        {
            return requestTask.state == OregoRequestState.PENDING;
        }
        
        public static void SetProcessing(this OregoRequestTask requestTask)
        {
            requestTask.state = OregoRequestState.PROCESSING;
        }

        public static bool IsProcessing(this OregoRequestTask request)
        {
            return request.state == OregoRequestState.PROCESSING;
        }
        
        public static void SetCanceled(this OregoRequestTask requestTask)
        {
            requestTask.state = OregoRequestState.CANCELED;
        }

        public static bool IsCanceled(this OregoRequestTask request)
        {
            return request.state == OregoRequestState.CANCELED;
        }
        
        public static void SetFinished(this OregoRequestTask requestTask)
        {
            requestTask.state = OregoRequestState.FINISHED;
        }

        public static bool IsFinished(this OregoRequestTask request)
        {
            return request.state == OregoRequestState.FINISHED;
        }
    }
}