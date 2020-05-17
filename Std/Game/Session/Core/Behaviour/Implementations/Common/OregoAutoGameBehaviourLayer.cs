using System;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Game
{
    public abstract class OregoAutoGameBehaviourLayer : OregoGameBehaviourLayer
    {
        [SerializeField]
        private GameBehaviourLayerParams m_gameBehaviourLayerParams;
        
        public override void OnAttachGame(IOregoGameSession gameSession)
        {
            base.OnAttachGame(gameSession);
            var childNodes = this.FindChildrenRecursively<IOregoGameNode>();
            foreach (var childNode in childNodes)
            {
                this.AddNode(childNode);
            }

            foreach (var asset in this.m_gameBehaviourLayerParams.m_gameControllerAssets)
            {
                var cloneController = this.New(asset);
                this.AddNode(cloneController);
            }
        }

        [Serializable]
        public sealed class GameBehaviourLayerParams
        {
            [SerializeField]
            public OregoGameController[] m_gameControllerAssets;
        }
    }
}