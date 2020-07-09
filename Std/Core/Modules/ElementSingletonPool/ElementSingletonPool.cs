using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base singleton implementation of interface
    ///     <see cref="IElementSingletonPool"/></para>
    /// </summary>
    public class ElementSingletonPool : Module,
        IElementSingletonPool,
        ISingleton
    {
        public HashSet<ISingletonElement> singletons { get; }

        protected IElementCreator elementCreator { get; private set; }

        #region Initialize

        public ElementSingletonPool()
        {
            this.singletons = new HashSet<ISingletonElement>();
        }

        public override void OnProvideCore(IModularCore core)
        {
            base.OnProvideCore(core);
            this.elementCreator = core.GetModule<IElementCreator>();
            ((ISingleton) this).OnBecameSingleton();
        }
        
        void ISingleton.OnBecameSingleton()
        {
            Orego.AddObject(nameof(IElementSingletonPool), this);
        }

        #endregion

        #region CreateSingletons

        public virtual void LoadSingletons()
        {
            this.InstantiateElementSingletons();
            this.CreateElementSingletons();
            this.PrepareElementsSingletons();
            this.ReadyElementSingletons();
            this.StartElementSingletons();
        }

        protected void InstantiateElementSingletons()
        {
            var singletons = this.elementCreator.CreateElements<ISingletonElement>();
            foreach (var singleton in singletons)
            {
                singleton.OnBecameSingleton();
                this.singletons.Add(singleton);
            }
        }

        protected void CreateElementSingletons()
        {
            foreach (var singleton in this.singletons)
            {
                singleton.OnCreate();
            }
        }

        protected void PrepareElementsSingletons()
        {
            foreach (var singleton in this.singletons)
            {
                singleton.OnPrepare();
            }
        }

        protected void ReadyElementSingletons()
        {
            foreach (var singleton in this.singletons)
            {
                singleton.OnReady();
            }
        }

        protected void StartElementSingletons()
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
                singleton.OnFinish();
            }

            foreach (var singleton in this.singletons)
            {
                singleton.OnDestroy();
            }

            this.singletons.Clear();
        }
    }
}