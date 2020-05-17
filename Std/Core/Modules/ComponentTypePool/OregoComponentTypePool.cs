using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base abstract singleton implementation of <see cref="IOregoComponentTypePool"/>
    ///     </para>
    /// </summary>
    public abstract class OregoComponentTypePool : OregoModule,
        IOregoComponentTypePool,
        ISingleton
    {
        public HashSet<Type> componentTypes { get; private set; }

        #region Initialize

        public override void OnBindConfig(IOregoModularConfig config)
        {
            base.OnBindConfig(config);
            ((ISingleton) this).OnBecameSingleton();
        }

        void ISingleton.OnBecameSingleton()
        {
            Orego.AddObject(nameof(IOregoComponentTypePool), this);
        }

        #endregion

        #region LoadTypes

        public void LoadTypes()
        {
            this.componentTypes = this.LoadComponentTypes();
        }

        public abstract HashSet<Type> LoadComponentTypes();

        #endregion

        #region Dispose

        public override void Dispose()
        {
            this.componentTypes.Clear();
        }

        #endregion
    }
}