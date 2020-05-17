using System.Collections;
using System.Collections.Generic;
using OregoFramework.Tool;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    using UIGameControllers = IEnumerable<IOregoUIGameNode>;

    public abstract class OregoUIStandardGameSession : OregoUISuspendLoadGameSession
    {
        private Routine loadUIRoutine;
        
        protected override void Awake()
        {
            base.Awake();
            this.loadUIRoutine = RoutineFactory.CreateInstance();
        }

        protected sealed override void OnLoadUISuspend(Continuation<UIGameControllers> continuation)
        {
            this.loadUIRoutine.Start(this.LoadUIRoutine(continuation));
        }

        private IEnumerator LoadUIRoutine(Continuation<UIGameControllers> continuation)
        {
            var controllers = new List<IOregoUIGameNode>();
            yield return this.OnLoadUIAsync(controllers);
            continuation.Continue(controllers);
        }

        protected abstract IEnumerator OnLoadUIAsync(
            List<IOregoUIGameNode> outputControllersList
        );
    }
}