using System;
using Newtonsoft.Json;

namespace OregoFramework.Client
{
    public static class RequestTaskExtensions
    {
        public static string GetBodyString(this RequestTask requestTask)
        {
            var currentWebRequest = requestTask.unityWebRequest;
            var downloadHandler = currentWebRequest.downloadHandler;
            return downloadHandler.text;
        }

        public static long GetResponseCode(this RequestTask requestTask)
        {
            var currentWebRequest = requestTask.unityWebRequest;
            return currentWebRequest.responseCode;
        }

        public static bool DeserializeBody<T>(this RequestTask requestTask, out T result)
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

        public static void SetPending(this RequestTask requestTask)
        {
            requestTask.state = RequestState.PENDING;
        }

        public static bool IsPending(this RequestTask requestTask)
        {
            return requestTask.state == RequestState.PENDING;
        }
        
        public static void SetProcessing(this RequestTask requestTask)
        {
            requestTask.state = RequestState.PROCESSING;
        }

        public static bool IsProcessing(this RequestTask request)
        {
            return request.state == RequestState.PROCESSING;
        }
        
        public static void SetCanceled(this RequestTask requestTask)
        {
            requestTask.state = RequestState.CANCELED;
        }

        public static bool IsCanceled(this RequestTask request)
        {
            return request.state == RequestState.CANCELED;
        }
        
        public static void SetFinished(this RequestTask requestTask)
        {
            requestTask.state = RequestState.FINISHED;
        }

        public static bool IsFinished(this RequestTask request)
        {
            return request.state == RequestState.FINISHED;
        }
    }
}