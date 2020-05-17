using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base singleton implementation of interface
    ///     <see cref="IOregoComponentSingletonManager"/></para>
    /// </summary>
    public class OregoComponentSingletonManager : OregoModule,
        IOregoComponentSingletonManager,
        ISingleton
    {
        public HashSet<IOregoSingletonComponent> singletons { get; }

        protected IOregoComponentCreator componentCreator { get; private set; }

        #region Initialize

        public OregoComponentSingletonManager()
        {
            this.singletons = new HashSet<IOregoSingletonComponent>();
        }

        public override void OnBindConfig(IOregoModularConfig config)
        {
            base.OnBindConfig(config);
            this.componentCreator = config.GetModule<IOregoComponentCreator>();
            ((ISingleton) this).OnBecameSingleton();
        }
        
        void ISingleton.OnBecameSingleton()
        {
            Orego.AddObject(nameof(IOregoComponentSingletonManager), this);
        }

        #endregion

        #region CreateSingletons

        public virtual void CreateSingletons()
        {
            this.InstantiateComponentSingletons();
            this.CreateComponentSingletons();
            this.PrepareComponentSingletons();
            this.ReadyComponentSingletons();
            this.StartComponentSingletons();
        }

        protected void InstantiateComponentSingletons()
        {
            var singletons = this.componentCreator.CreateComponents<IOregoSingletonComponent>();
            foreach (var singleton in singletons)
            {
                singleton.OnBecameSingleton();
                this.singletons.Add(singleton);
            }
        }

        protected void CreateComponentSingletons()
        {
            foreach (var singleton in this.singletons)
            {
                singleton.OnCreate();
            }
        }

        protected void PrepareComponentSingletons()
        {
            foreach (var singleton in this.singletons)
            {
                singleton.OnPrepare();
            }
        }

        protected void ReadyComponentSingletons()
        {
            foreach (var singleton in this.singletons)
            {
                singleton.OnReady();
            }
        }

        protected void StartComponentSingletons()
        {
            foreach (var singleton in this.singletons)
            {
                singleton.OnStart();
            }
        }

        #endregion

        public override void Dispose()
        {
            foreach (var singleton in this.singletons)
            {
                singleton.OnStop();
            }

            foreach (var singleton in this.singletons)
            {
                singleton.OnDestroy();
            }

            this.singletons.Clear();
        }
    }
}