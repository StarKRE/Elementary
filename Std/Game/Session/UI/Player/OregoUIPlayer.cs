namespace OregoFramework.Game
{
    public abstract class OregoUIPlayer<T> : OregoUIGameNode where T : IOregoPlayer
    {
        protected T player { get; private set; }

        #region OnGamePrepared

        public override void OnGamePrepared(object sender)
        {
            base.OnGamePrepared(sender);
            var gameSession = this.GetGameSession<OregoNodeGameSession>();
            this.player = gameSession.GetNode<T>();
        }

        #endregion
    }
}