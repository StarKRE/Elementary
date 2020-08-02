using System.Collections;
using System.Collections.Generic;
using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.App
{
    public abstract class QueueNetworkManager : BaseNetworkManager, IQueueNetworkManager
    {
        private readonly Queue<RequestTask> requestTaskQueue;

        private RequestTask currentRequestTask;

        protected QueueNetworkManager()
        {
            this.requestTaskQueue = new Queue<RequestTask>();
        }

        #region Enqueue

        public IEnumerator EnqueueRequestTask(RequestTask requestTask)
        {
            if (this.currentRequestTask != null)
            {
                this.requestTaskQueue.Enqueue(requestTask);
                yield return new WaitWhile(requestTask.IsPending);
                if (!requestTask.IsProcessing())
                {
                    yield break;
                }
            }

            this.currentRequestTask = requestTask;
            yield return this.SendRequestTask(requestTask);
            requestTask.SetFinished();
            if (this.requestTaskQueue.IsNotEmpty())
            {
                var nextRequest = this.requestTaskQueue.Dequeue();
                nextRequest.SetProcessing();
            }
            else
            {
                this.currentRequestTask = null;
            }
        }

        #endregion

        #region Reset

        public override void Reset()
        {
            base.Reset();
            this.CancelRequests();
        }

        private void CancelRequests()
        {
            if (this.currentRequestTask == null)
            {
                return;
            }

            this.currentRequestTask.SetCanceled();
            while (this.requestTaskQueue.IsNotEmpty())
            {
                var request = this.requestTaskQueue.Dequeue();
                request.SetCanceled();
            }

            this.currentRequestTask = null;
        }

        #endregion
    }
}