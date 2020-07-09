using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base implementation of modular core interface.</para>
    /// </summary>
    public abstract class ModularCore : IModularCore
    {
        protected readonly Dictionary<Type, IModule> moduleMap;

        protected ModularCore()
        {
            this.moduleMap = new Dictionary<Type, IModule>();
        }

        public IEnumerable<T> GetModules<T>() where T : IModule
        {
            return this.moduleMap.FindAll<T, IModule>();
        }

        public T GetModule<T>() where T : IModule
        {
            return this.moduleMap.Find<T, IModule>();
        }

        #region Install

        public void Install()
        {
            this.SetupModules();
            this.SetupFramework();
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
                module.OnProvideCore(this);
            }
        }

        /// <summary>
        ///     <para>Gets module instances to this core for further work with them.</para> 
        /// </summary>
        /// <returns>A module map</returns>
        protected abstract Dictionary<Type, IModule> LoadModuleMap();

        /// <summary>
        ///     <para>Here you can deploy framework system using modules.</para>
        /// </summary>
        protected virtual void SetupFramework()
        {
        }

        #endregion

        #region Uninstall

        public void Uninstall()
        {
            this.UnsetupFramework();
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
        protected virtual void UnsetupFramework()
        {
        }

        #endregion
    }
}