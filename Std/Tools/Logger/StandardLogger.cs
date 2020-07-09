using UnityEngine;

namespace OregoFramework.Tools
{
    public abstract class StandardLogger : Logger
    {
        #region Log

        protected sealed override void Log(LogArgs logArgs)
        {
            if (this.CanLog(logArgs))
            {
                var message = logArgs.message;
                Debug.Log(message);
            }
        }

        protected virtual bool CanLog(LogArgs logArgs)
        {
            var loggerConfig = this.GetConfig<LoggerConfig>();
            if (loggerConfig.level != logArgs.level)
            {
                return false;
            }

            if (loggerConfig.profile != logArgs.profile)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}