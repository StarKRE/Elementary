using OregoFramework.Core;
using UnityEngine;

namespace OregoFramework.Tools
{
    /// <summary>
    ///     <para>Abstract logger.</para>
    /// </summary>
    public abstract class OregoLogger : OregoComponent, IOregoSingletonComponent
    {
        #region Const

        public const string CONFIG_NAME = "OregoLoggerConfig";

        #endregion
        
        #region Lifecycle

        public abstract void OnBecameSingleton();

        private OregoLoggerConfig config;

        public override void OnCreate()
        {
            base.OnCreate();
            var asset = Resources.Load<OregoLoggerConfig>(CONFIG_NAME);
            this.config = ScriptableObject.Instantiate(asset);
        }

        public override void OnStop()
        {
            base.OnStop();
            ScriptableObject.Destroy(this.config);
        }

        #endregion

        protected abstract void Log(LogArgs logArgs);

        protected T GetConfig<T>() where T : OregoLoggerConfig
        {
            return (T) this.config;
        }
    }
}