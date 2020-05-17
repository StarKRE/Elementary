using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The standard config deployes Orego framework system using
    ///     the standard Orego module set.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "OregoMainConfig",
        menuName = "Orego/Config/New OregoStandardMainConfig"
    )]
    public class OregoStandardConfig : OregoModularConfig
    {
        #region Const

        protected static readonly Dictionary<Type, IOregoModule> standardModuleSet;

        #endregion

        [SerializeField]
        private bool enableStopWatch;

        private readonly Stopwatch stopwatch;

        #region Initialize

        /// <summary>
        ///     <para>Initializes the standard Orego module set.</para>>
        /// </summary>
        static OregoStandardConfig()
        {
            standardModuleSet = new Dictionary<Type, IOregoModule>
            {
                {typeof(IOregoComponentTypePool), new OregoStandardComponentTypePool()},
                {typeof(IOregoComponentCreator), new OregoComponentCreator()},
                {typeof(IOregoComponentSingletonManager), new OregoComponentSingletonManager()}
            };
        }

        public OregoStandardConfig()
        {
            this.stopwatch = new Stopwatch();
        }

        /// <summary>
        ///     <para>Loads the standard Orego module set. You can create and add
        ///     your custom modules by implementing the interface <see cref="IOregoModule"/>.</para>
        /// </summary>
        protected override Dictionary<Type, IOregoModule> LoadModuleMap()
        {
            return new Dictionary<Type, IOregoModule>(standardModuleSet);
        }

        #endregion

        #region OnInstall
        
        
        /// <summary>
        ///     <para>Invokes after creating of the modules.</para>
        /// </summary>
        protected override void OnInstall()
        {
            if (this.enableStopWatch)
            {
                this.stopwatch.Start();
            }

            this.DeployFramework();
            if (this.enableStopWatch)
            {
                this.stopwatch.Stop();
                Debug.Log("<color=green>" +
                          "Orego: Hello world! " +
                          $"Initialized: millis {this.stopwatch.ElapsedMilliseconds}" +
                          "</color>");
            }
        }

        /// <summary>
        ///     <para>Deploys the Orego framework system.</para>
        /// </summary>
        protected virtual void DeployFramework()
        {
            this.GetModule<IOregoComponentTypePool>().LoadTypes();
            this.GetModule<IOregoComponentSingletonManager>().CreateSingletons();
        }

        #endregion
    }
}