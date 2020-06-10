using System;
using UnityEngine;

namespace OregoFramework.Util
{
    [CreateAssetMenu(
        fileName = "SmoothOperator",
        menuName = "Orego/Util/New SmoothOperator"
    )]
    public sealed class SmoothOperator : AutoScriptableObject
    {
        public float smoothTime { get; set; }

        public float maxSpeed { get; set; }

        private float dampSpeed;

        [SerializeField]
        private Params m_params = new Params();

        public override void OnCreate()
        {
            base.OnCreate();
            this.smoothTime = this.m_params.m_smoothTime;
            this.maxSpeed = this.m_params.m_maxSpeed;
        }

        public float Apply(float currentValue, float targetValue, float deltaTime)
        {
            var nextValue = Mathf.SmoothDamp(
                currentValue,
                targetValue,
                ref this.dampSpeed,
                this.smoothTime,
                this.maxSpeed,
                deltaTime
            );
            if (float.IsNaN(nextValue))
            {
                return currentValue;
            }

            return nextValue;
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float m_smoothTime;

            [SerializeField]
            public float m_maxSpeed;
        }
    }
}