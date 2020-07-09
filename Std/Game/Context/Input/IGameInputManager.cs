using System;

namespace OregoFramework.Game
{
    [Obsolete]
    public interface IGameInputManager
    {
        IGameInput GetInput();

        void EnableInput();

        void DisableInput();
    }
}