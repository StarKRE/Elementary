using System;
using UnityEngine;

namespace ElementaryFramework.Unit
{
    [Serializable]
    public class TimeScale
    {
        [SerializeField]
        public float value;

        public TimeScale(float value)
        {
            this.value = value;
        }
    }
}