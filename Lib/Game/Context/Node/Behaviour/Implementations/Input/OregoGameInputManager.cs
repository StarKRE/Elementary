using System;

namespace OregoFramework.Game
{
    [Obsolete]
    public abstract class OregoGameInputManager<T> : OregoAutoGameBehaviour,
        IOregoGameInputManager
        where T : class, IOregoGameInput
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

        public IOregoGameInput GetInput()
        {
            return this.input;
        }
    }
}