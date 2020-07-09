using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class AutoGameNodeLayer : GameNodeLayer
    {
        public override void OnAttachGame(IGameContext gameContext)
        {
            base.OnAttachGame(gameContext);
            var childNodes = this.GetComponentsInChildrenNoParent<IGameNode>();
            foreach (var childNode in childNodes)
            {
                this.AddNode(childNode);
            }
        }
    }
}