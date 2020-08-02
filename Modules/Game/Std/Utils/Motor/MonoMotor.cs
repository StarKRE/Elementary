using System;
using UnityEngine;

namespace ElementaryFramework.Util
{
    public sealed class MonoMotor : AutoMonoBehaviour, IMotor
    {
        public float absMaxSpeed { get; set; }

        public float absMinSpeed { get; set; }

        public float absMaxAcceleration { get; set; }

        public float absLinearDrag { get; set; }

        public float currentSpeed { get; set; }

        public float currentAcceleration { get; set; }

        [SerializeField]
        private Params m_params = new Params();

        private void Awake()
        {
            this.absMaxSpeed = this.m_params.m_maxSpeed;
            this.absMinSpeed = this.m_params.m_minSpeed;
            this.absMaxAcceleration = this.m_params.m_maxAcceleration;
            this.absLinearDrag = this.m_params.m_linearDrag;
        }
        
        public void AddForce(float coefficient)
        {
            this.currentAcceleration += this.absMaxAcceleration * coefficient;
            if (this.currentAcceleration.Abs() >= this.absMaxAcceleration)
            {
                var accelerationSign = this.currentAcceleration.Sign();
                this.currentAcceleration = accelerationSign * this.absMaxAcceleration;
            }
        }

        public float NextSpeed()
        {
            this.currentSpeed += this.currentAcceleration;
            if (this.currentSpeed.Abs() >= this.absMaxSpeed)
            {
                this.currentSpeed = this.currentSpeed.Sign() * this.absMaxSpeed;
            }

            if (this.currentAcceleration.Abs() <= Float.MIN_TOLERANCE)
            {
                var speedSign = this.currentSpeed.Sign();
                if (this.currentSpeed.Abs() - this.absLinearDrag > this.absMinSpeed)
                {
                    this.currentSpeed -= speedSign * this.absLinearDrag;
                }
                else
                {
                    this.currentSpeed = speedSign * this.absMinSpeed;
                }
            }

            this.currentAcceleration = Float.ZERO;
            return this.currentSpeed;
        }

        public void Reset()
        {
            this.currentAcceleration = Float.ZERO;
            this.currentSpeed = Float.ZERO;
        }

        [Serializable]
        public sealed class Params
        {
            [Header("Speed")]
            [SerializeField]
            public float m_maxSpeed;

            [SerializeField]
            public float m_minSpeed;

            [Header("Acceleration")]
            [SerializeField]
            public float m_maxAcceleration;

            [Header("Drag")]
            [SerializeField]
            public float m_linearDrag;
        }
    }
}