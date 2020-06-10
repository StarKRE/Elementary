using System;

namespace OregoFramework.Util
{
    public interface IState
    {
        #region Event

        AutoEvent<IState> OnEnterEvent { get; }

        AutoEvent<IState> OnUpdateEvent { get; }

        AutoEvent<IState> OnExitEvent { get; }

        #endregion

        void OnEnter();

        void OnUpdate();

        void OnExit();
    }
}