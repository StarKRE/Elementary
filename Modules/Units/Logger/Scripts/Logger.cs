using ElementaryFramework.Core;
using UnityEngine;

namespace ElementaryFramework.Unit
{
    /// <summary>
    ///     <para>Abstract logger.</para>
    /// </summary>
    public abstract class Logger : Element, IRootElement
    {
        #region Const

        public const string CONFIG_NAME = "LoggerConfig";

        #endregion
        
        #region Lifecycle

        private LoggerConfig config;

        public override void OnCreate(IElementContext context)
        {
            base.OnCreate(context);
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