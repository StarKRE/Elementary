using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Implements system layer of components in the framework.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OregoComponentLayer<T> : OregoComponent
        where T : IOregoComponent
    {
        private readonly Dictionary<Type, T> childComponentMap;

        protected OregoComponentLayer()
        {
            this.childComponentMap = new Dictionary<Type, T>();
        }

        protected IEnumerable<T> allComponents
        {
            get { return this.childComponentMap.Values; }
        }

        protected IEnumerable<R> GetComponents<R>() where R : T
        {
            return this.childComponentMap.FindAll<R, T>();
        }

        protected T this[Type componentType]
        {
            get { return this.childComponentMap.Find(componentType); }
        }

        public override void OnCreate()
        {
            var childComponents = this.CreateComponents<T>();
            foreach (var childComponent in childComponents)
            {
                this.childComponentMap.AddByType(childComponent);
            }
        }

        public override void OnDestroy()
        {
            this.childComponentMap.Clear();
            base.OnDestroy();
        }
    }
}