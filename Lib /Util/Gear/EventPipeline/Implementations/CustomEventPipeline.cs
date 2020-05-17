using System;
using UnityEngine;

namespace OregoFramework.Util.Gear
{
    [CreateAssetMenu(fileName = "CustomEventPipeline", menuName = "Orego/Util/Event/New CustomEventPipeline")]
    public class CustomEventPipeline : EventPipeline
    {
        [SerializeField]
        private CustomEventPipelineParams m_customEventPipelineParams =
            new CustomEventPipelineParams();

        public override void OnCreate()
        {
            base.OnCreate();
            var pipeAssets = this.m_customEventPipelineParams.m_eventPipeAssets;
            foreach (var pipeAsset in pipeAssets)
            {
                var pipe = this.New(pipeAsset);
                this.AddPipe(pipe);
            }
        }

        [Serializable]
        public sealed class CustomEventPipelineParams
        {
            [SerializeField]
            public EventPipe[] m_eventPipeAssets;
        }
    }
}