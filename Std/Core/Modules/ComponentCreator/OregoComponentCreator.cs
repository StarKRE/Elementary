using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base singleton implementation of interface
    ///     <see cref="IOregoComponentCreator"/></para>
    /// </summary>
    public class OregoComponentCreator : OregoModule,
        IOregoComponentCreator,
        ISingleton
    {
        protected IOregoComponentTypePool typePool { get; private set; }

        #region Initialize

        public override void OnBindConfig(IOregoModularConfig config)
        {
            base.OnBindConfig(config);
            ((ISingleton) this).OnBecameSingleton();
            this.typePool = config.GetModule<IOregoComponentTypePool>();
        }

        void ISingleton.OnBecameSingleton()
        {
            Orego.AddObject(nameof(IOregoComponentCreator), this);
        }

        #endregion

        public virtual T CreateComponent<T>(Type requiredType, Func<Type, bool> filter = null)
            where T : IOregoComponent
        {
            if (filter == null)
            {
                filter = type => true;
            }

            var componentTypes = this.typePool.componentTypes;
            if (componentTypes.Contains(requiredType) && filter.Invoke(requiredType))
            {
                return ReflectionUtils.CreateInstanceWithReflection<T>(requiredType);
            }

            foreach (var type in componentTypes)
            {
                if (requiredType.IsAssignableFrom(type) && filter.Invoke(requiredType))
                {
                    return ReflectionUtils.CreateInstanceWithReflection<T>(requiredType);
                }
            }

            throw new Exception(
                $"{requiredType.Name} is absent in component type pool! Didn't you forget to" +
                " add attribute OregoContext over required class?"
            );
        }

        public virtual IEnumerable<T> CreateComponents<T>(Func<Type, bool> filter = null)
            where T : IOregoComponent
        {
            if (filter == null)
            {
                filter = type => true;
            }

            var requiredType = typeof(T);
            var componentSet = new HashSet<T>();
            var componentTypes = this.typePool.componentTypes;
            foreach (var type in componentTypes)
            {
                if (requiredType.IsAssignableFrom(type) && filter.Invoke(type))
                {
                    var component = ReflectionUtils.CreateInstanceWithReflection<T>(type);
                    componentSet.Add(component);
                }
            }

            return componentSet;
        }
    }
}