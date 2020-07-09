using OregoFramework.Core;
using UnityEngine;

namespace OregoFramework.Tools
{
    /// <summary>
    ///     <para>Abstract logger.</para>
    /// </summary>
    public abstract class Logger : Element, ISingletonElement
    {
        #region Const

        public const string CONFIG_NAME = "LoggerConfig";

        #endregion
        
        #region Lifecycle

        public abstract void OnBecameSingleton();

        private LoggerConfig config;

        public override void OnCreate()
        {
            base.OnCreate();
            var asset = Resources.Load<LoggerConfig>(CONFIG_NAME);
            this.config = ScriptableObject.Instantiate(asset);
        }

        public override void OnFinish()
        {
            base.OnFinish();
            ScriptableObject.Destroy(this.config);
        }

        #endregion

        protected abstract void Log(LogArgs logArgs);

        protected T GetConfig<T>() where T : LoggerConfig
        {
            return (T) this.config;
        }
    }
}