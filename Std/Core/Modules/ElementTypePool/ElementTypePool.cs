using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base abstract singleton implementation of <see cref="IElementTypePool"/>
    ///     </para>
    /// </summary>
    public abstract class ElementTypePool : Module,
        IElementTypePool,
        ISingleton
    {
        public HashSet<Type> elementTypes { get; private set; }

        #region Initialize

        public override void OnProvideCore(IModularCore core)
        {
            base.OnProvideCore(core);
            ((ISingleton) this).OnBecameSingleton();
        }

        void ISingleton.OnBecameSingleton()
        {
            Orego.AddObject(nameof(IElementTypePool), this);
        }

        #endregion

        #region LoadTypes

        public void LoadTypes()
        {
            this.elementTypes = this.LoadElementTypes();
        }

        public abstract HashSet<Type> LoadElementTypes();

        #endregion

        #region Dispose

        public override void Dispose()
        {
            this.elementTypes.Clear();
        }

        #endregion
    }
}