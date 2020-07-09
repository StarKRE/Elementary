namespace OregoFramework.Game
{
    public abstract class AutoGameNode : GameNode
    {
        protected virtual void Awake()
        {
            this.enabled = false;
        }

        public override void OnStartGame(object sender)
        {
            base.OnStartGame(sender);
            this.enabled = true;
        }

        public override void OnPauseGame(object sender)
        {
            base.OnPauseGame(sender);
            this.enabled = false;
        }

        public override void OnResumeGame(object sender)
        {
            base.OnResumeGame(sender);
            this.enabled = true;
        }

        public override void OnFinishGame(object sender)
        {
            base.OnFinishGame(sender);
            this.enabled = false;
        }
    }
}