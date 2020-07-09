using System;

namespace OregoFramework.Game
{
    [Obsolete]
    public abstract class GameInputManager<T> : AutoGameNode,
        IGameInputManager
        where T : class, IGameInput
    {
        public abstract T input { get; protected set; }

        public virtual void EnableInput()
        {
            this.input.isEnabled = true;
        }

        public virtual void DisableInput()
        {
            this.input.isEnabled = false;
        }

        public IGameInput GetInput()
        {
            return this.input;
        }
    }
}