using System;
using System.Collections.Generic;
using System.Linq;
using ElementaryFramework.Util;

namespace ElementaryFramework.Core
{
    public sealed class ElementContext : IElementContext
    {
        #region Const

        private static readonly Type rootType = typeof(IElement);

        private const string TYPE_NOT_FOUND_MESSAGE =
            "{0} is absent in element type in context! Didn't you forget to" +
            " add attribute [Using] over required class?";

        #endregion

        private Dictionary<Type, HashSet<Type>> elementTypeTable;

        private Dictionary<Type, IRootElement> rootElementMap;

        #region Initialize

        public void Initialize()
        {
            this.elementTypeTable = ElementTypeLoader.LoadTypeTable();
            this.CreateRootElements();
        }

        private void CreateRootElements()
        {
            var rootElements = this.CreateElements<IRootElement>();
            this.rootElementMap = new Dictionary<Type, IRootElement>();
            foreach (var rootElement in rootElements)
            {
                var type = rootElement.GetType();
                this.rootElementMap.Add(type, rootElement);
            }

            foreach (var rootElement in rootElements)
            {
                rootElement.OnPrepare();
            }

            foreach (var rootElement in rootElements)
            {
                rootElement.OnReady();
            }

            foreach (var rootElement in rootElements)
            {
                rootElement.OnStart();
            }
        }

        #endregion

        #region Terminate

        public void Terminate()
        {
            var rootElements = this.rootElementMap.Values;
            foreach (var rootElement in rootElements)
            {
                rootElement.OnFinish();
            }

            foreach (var rootElement in rootElements)
            {
                rootElement.OnDispose();
            }

            this.rootElementMap.Clear();
        }

        #endregion

        #region Types

        public HashSet<Type> GetImplementationTypes(Type interfaceType)
        {
            return new HashSet<Type>(this.elementTypeTable[interfaceType]);
        }

        #endregion

        #region CreateElement

        public T CreateElement<T>(Type requiredType) where T : IElement
        {
            //Check type in implementation type set:
            var interfaceType = typeof(T);
            if (this.elementTypeTable.TryGetValue(interfaceType, out var implementationTypes) &&
                implementationTypes.Contains(requiredType))
            {
                return CreateInstance<T>(requiredType);
            }

            //Check type in element type set:
            if (this.elementTypeTable.TryGetValue(rootType, out var elementTypes) &&
                elementTypes.Contains(requiredType))
            {
                return CreateInstance<T>(requiredType);
            }

            //Find first assignable type:
            foreach (var type in elementTypes)
            {
                if (requiredType.IsAssignableFrom(type))
                {
                    return CreateInstance<T>(requiredType);
                }
            }

            throw new Exception(string.Format(TYPE_NOT_FOUND_MESSAGE, requiredType.Name));
        }

        public IEnumerable<T> CreateElements<T>() where T : IElement
        {
            var newElements = new HashSet<T>();
            var interfaceType = typeof(T);
            if (!this.elementTypeTable.TryGetValue(interfaceType, out var implementationTypes))
            {
                return newElements;
            }

            foreach (var type in implementationTypes)
            {
                var newElement = CreateInstance<T>(type);
                newElements.Add(newElement);
            }

            return newElements;
        }

        private T CreateInstance<T>(Type requiredType) where T : IElement
        {
            var element = (T) Activator.CreateInstance(requiredType);
            element.OnCreate(this);
            return element;
        }

        #endregion

        #region RootElements

        public T GetRoot<T>() where T : IRootElement
        {
            return this.rootElementMap.Find<T, IRootElement>();
        }

        public IEnumerable<T> GetRoots<T>() where T : IRootElement
        {
            return this.rootElementMap.Values.OfType<T>();
        }

        #endregion
    }
}