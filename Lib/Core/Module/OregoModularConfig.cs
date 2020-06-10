using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base implementation of modular config interface.</para>
    /// </summary>
    public abstract class OregoModularConfig : OregoMainConfig, IOregoModularConfig
    {
        protected readonly Dictionary<Type, IOregoModule> moduleMap;

        protected OregoModularConfig()
        {
            this.moduleMap = new Dictionary<Type, IOregoModule>();
        }

        public IEnumerable<T> GetModules<T>() where T : IOregoModule
        {
            return this.moduleMap.FindAll<T, IOregoModule>();
        }

        public T GetModule<T>() where T : IOregoModule
        {
            return this.moduleMap.Find<T, IOregoModule>();
        }

        #region Install

        public sealed override void Install()
        {
            this.SetupModules();
            this.OnInstall();
        }

        private void SetupModules()
        {
            var moduleMap = this.LoadModuleMap();
            foreach (var modulePair in moduleMap)
            {
                var moduleId = modulePair.Key;
                var module = modulePair.Value;
                this.moduleMap.Add(moduleId, module);
            }

            var modules = this.moduleMap.Values;
            foreach (var module in modules)
            {
                module.OnBindConfig(this);
            }
        }

        /// <summary>
        ///     <para>Gets module instances to this config for further work with them.</para> 
        /// </summary>
        /// <returns>A module map</returns>
        protected abstract Dictionary<Type, IOregoModule> LoadModuleMap();

        /// <summary>
        ///     <para>Here you can deploy framework system using modules.</para>
        /// </summary>
        protected virtual void OnInstall()
        {
        }

        #endregion

        #region Uninstall

        public sealed override void Uninstall()
        {
            this.OnUninstall();
            this.DisposeModules();
        }

        private void DisposeModules()
        {
            var modules = this.moduleMap.Values;
            foreach (var module in modules)
            {
                module.Dispose();
            }

            this.moduleMap.Clear();
        }

        /// <summary>
        ///     <para>Here you can collapse framework system using modules.</para>
        /// </summary>
        protected virtual void OnUninstall()
        {
        }

        #endregion
    }
}