using System.Collections.Generic;

namespace ElementaryFramework.Game
{
    public interface IGameNodeLayer : IGameNode
    {
        T GetNode<T>() where T : IGameNode;

        IEnumerable<T> GetNodes<T>() where T : IGameNode;

        void AddNode(IGameNode gameNode);

        void RemoveNode(IGameNode gameNode);
    }
}