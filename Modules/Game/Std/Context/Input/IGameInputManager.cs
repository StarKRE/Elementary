using System;

namespace ElementaryFramework.Game
{
    [Obsolete]
    public interface IGameInputManager
    {
        IGameInput GetInput();

        void EnableInput();

        void DisableInput();
    }
}