using System;

namespace OregoFramework.Game
{
    [Obsolete]
    public interface IOregoGameInputManager
    {
        IOregoGameInput GetInput();

        void EnableInput();

        void DisableInput();
    }
}