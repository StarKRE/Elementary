using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base singleton implementation of interface
    ///     <see cref="IElementCreator"/></para>
    /// </summary>
    public class ElementCreator : Module,
        IElementCreator,
        ISingleton
    {
        protected IElementTypePool typePool { get; private set; }

        #region Initialize

        public override void OnProvideCore(IModularCore core)
        {
            base.OnProvideCore(core);
            ((ISingleton) this).OnBecameSingleton();
            this.typePool = core.GetModule<IElementTypePool>();
        }

        void ISingleton.OnBecameSingleton()
        {
            Orego.AddObject(nameof(IElementCreator), this);
        }

        #endregion

        public virtual T CreateElement<T>(Type requiredType, Func<Type, bool> filter = null)
            where T : IElement
        {
            if (filter == null)
            {
                filter = type => true;
            }

            var elementTypes = this.typePool.elementTypes;
            if (elementTypes.Contains(requiredType) && filter.Invoke(requiredType))
            {
                return (T) Activator.CreateInstance(requiredType);
            }

            foreach (var type in elementTypes)
            {
                if (requiredType.IsAssignableFrom(type) && filter.Invoke(requiredType))
                {
                    return (T) Activator.CreateInstance(requiredType);
                }
            }

            throw new Exception(
                $"{requiredType.Name} is absent in element type pool! Didn't you forget to" +
                " add attribute OregoContext over required class?"
            );
        }

        public virtual IEnumerable<T> CreateElements<T>(Func<Type, bool> filter = null)
            where T : IElement
        {
            if (filter == null)
            {
                filter = type => true;
            }

            var requiredType = typeof(T);
            var elementSet = new HashSet<T>();
            var elementTypes = this.typePool.elementTypes;
            foreach (var type in elementTypes)
            {
                if (requiredType.IsAssignableFrom(type) && filter.Invoke(type))
                {
                    var element = (T) Activator.CreateInstance(type);
                    elementSet.Add(element);
                }
            }

            return elementSet;
        }
    }
}