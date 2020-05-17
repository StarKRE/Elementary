using System.Collections.Generic;

namespace OregoFramework.Game
{
    public interface IOregoGameNodeLayer : IOregoGameNode
    {
        T GetNode<T>() where T : IOregoGameNode;

        IEnumerable<T> GetNodes<T>() where T : IOregoGameNode;

        void AddNode(IOregoGameNode gameNode);

        void RemoveNode(IOregoGameNode gameNode);
    }
}