using System;
using System.Collections.Generic;

namespace ElementaryFramework.Core
{
    /// <summary>
    ///     <para>Base implementation of <see cref="IElement"/></para>.
    ///     <para>Each element has own lifecycle that is maintained by the system.</para>
    ///     <para>Each element contains child elements.</para>
    ///     <para>All derived classes must have default constructor.</para>.
    /// </summary>
    public abstract class Element : IElement
    {
        private IElementContext context;
        
        private readonly HashSet<IElement> childElements;

        protected Element()
        {
            this.childElements = new HashSet<IElement>();
        }

        #region Lifecycle

        public virtual void OnCreate(IElementContext context)
        {
            this.context = context;
        }

        public virtual void OnPrepare()
        {
            foreach (var childElement in this.childElements)
            {
                childElement.OnPrepare();
            }
        }

        public virtual void OnReady()
        {
            foreach (var childElement in this.childElements)
            {
                childElement.OnReady();
            }
        }

        public virtual void OnStart()
        {
            foreach (var childElement in this.childElements)
            {
                childElement.OnStart();
            }
        }

        public virtual void OnFinish()
        {
            foreach (var childElement in this.childElements)
            {
                childElement.OnFinish();
            }
        }
        
        public virtual void OnDispose()
        {
            foreach (var childElement in this.childElements)
            {
                childElement.OnDispose();
            }

            this.childElements.Clear();
        }

        #endregion

        #region CreateElement

        /// <summary>
        ///    <para>Creates a child element.</para>
        ///    <para>Use this method to instantiate your child element field or property
        ///    in <see cref="OnCreate"/> method.</para>
        /// </summary>
        /// <param name="type">Required implementation type. This type must:
        ///    1.) Derives from interface <see cref="IElement"/>
        ///    2.) Annotates with attribute <see cref="Using"/>
        ///    3.) Implementation must have the default constructor.
        /// </param>
        /// <typeparam name="T">Required interface type.</typeparam>
        /// <returns>Instance of child element.</returns>
        /// 
        /// <example>
        /// Need to create an instance of a class Cat and assign to field "animal" with type IAnimal:
        /// <code>
        /// 
        /// public override void OnCreate()
        /// {
        ///    base.OnCreate();
        ///    this.animal = this.CreateElement﹤IAnimal﹥(typeof(Cat));
        /// }
        ///
        /// </code>
        /// 
        /// The class Cat can be abstract or interface! In this case the framework will
        /// find first class derived from Cat and will create its instance.
        /// If we register a class SphynxCat under the class Cat then the system will create
        /// an instance of the class SphynxCat.
        /// </example>
        protected T CreateElement<T>(Type type) where T : IElement
        {
            var childElement = this.context.CreateElement<T>(type);
            this.childElements.Add(childElement);
            return childElement;
        }

        /// <summary>
        ///    <para>Creates child elements of requred type.</para>
        ///    <para>Use this method to instantiate your child elements array field or property
        ///    in <see cref="OnCreate"/> method.</para>
        /// </summary>
        /// <typeparam name="T">Required implementation types. Implementation types must:
        ///    1.) Derives from interface <see cref="IElement"/>
        ///    2.) Annotates with attribute <see cref="Using"/>
        ///    3.) Implementations must have the default constructor.
        /// .</typeparam>
        /// <returns>Instance of child element.</returns>
        /// 
        /// <example>
        /// Need to create all animals derived from IAnimal and assign to array field "animal" with
        /// type IEnumerable﹤IAnimal﹥:
        /// <code>
        /// 
        /// public override void OnCreate()
        /// {
        ///    base.OnCreate();
        ///    this.animals = this.CreateElements﹤IAnimal﹥();
        /// }
        ///
        /// </code>
        /// 
        /// Suppose we have 3 classes derives from IAnimal: Cat, Dog, Duck.
        /// If classes Cat & Dog are registered in framework system then
        /// only Cat & Dog will be created. Duck - not!
        /// </example>
        protected IEnumerable<T> CreateElements<T>() where T : IElement
        {
            var childElements = this.context.CreateElements<T>();
            foreach (var childElement in childElements)
            {
                this.childElements.Add(childElement);
            }

            return childElements;
        }
        
        #endregion

        #region Roots

        public T GetRoot<T>() where T : IRootElement
        {
            return this.context.GetRoot<T>();
        }

        public IEnumerable<T> GetRoots<T>() where T : IRootElement
        {
            return this.context.GetRoots<T>();
        }

        #endregion
    }
}