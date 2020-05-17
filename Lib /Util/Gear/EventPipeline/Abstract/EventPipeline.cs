using System;
using System.Collections.Generic;

namespace OregoFramework.Util.Gear
{
    public abstract class EventPipeline : AutoScriptableObject, IEventPipeline
    {
        #region Event

        public event Action<IEvent> OnEventPushedEvent;

        #endregion

        private readonly Dictionary<Type, IEventPipe> pipeMap;

        protected EventPipeline()
        {
            this.pipeMap = new Dictionary<Type, IEventPipe>();
        }

        protected IEnumerable<IEventPipe> pipes
        {
            get { return this.pipeMap.Values; }
        }

        public virtual void AddPipe(IEventPipe pipe)
        {
            this.pipeMap.AddByType(pipe);
        }

        public virtual void RemovePipe(IEventPipe pipe)
        {
            this.pipeMap.RemoveByType(pipe);
        }

        public T GetPipe<T>() where T : IEventPipe
        {
            return this.pipeMap.Find<T, IEventPipe>();
        }

        public IEnumerable<T> GetPipes<T>() where T : IEventPipe
        {
            return this.pipeMap.FindAll<T, IEventPipe>();
        }

        public virtual void PushEvent(IEvent inputEvent)
        {
            foreach (var pipe in this.pipes)
            {
                pipe.PushEvent(inputEvent);
            }
        }

        public void NotifyAboutEventPushed(IEvent @event)
        {
            this.OnEventPushedEvent?.Invoke(@event);
        }
    }
}