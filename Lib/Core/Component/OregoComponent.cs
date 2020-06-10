using System;
using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base implementation of <see cref="IOregoComponent"/></para>.
    ///     <para>Each component has own lifecycle that is maintained by the system.</para>
    ///     <para>Each component contains child components.</para>
    ///     <para>All derived classes must have default constructor.</para>.
    /// </summary>
    public abstract class OregoComponent : IOregoComponent
    {
        /// <summary>
        ///     <para>Creates the Orego component instances.</para>
        /// </summary>
        private IOregoComponentCreator _componentCreator;

        private IOregoComponentCreator componentCreator
        {
            get
            {
                if (this._componentCreator == null)
                {
                    this._componentCreator = Orego.GetObject<IOregoComponentCreator>(
                        nameof(IOregoComponentCreator)
                    );
                }

                return this._componentCreator;
            }
        }

        private readonly HashSet<IOregoComponent> childComponents;

        protected OregoComponent()
        {
            this.childComponents = new HashSet<IOregoComponent>();
        }

        #region OnCreate

        public virtual void OnCreate()
        {
        }

        #endregion

        #region OnPrepare

        public virtual void OnPrepare()
        {
            foreach (var childComponent in this.childComponents)
            {
                childComponent.OnPrepare();
            }
        }

        #endregion

        #region OnReady

        public virtual void OnReady()
        {
            foreach (var childComponent in this.childComponents)
            {
                childComponent.OnReady();
            }
        }

        #endregion

        #region OnStart

        public virtual void OnStart()
        {
            foreach (var childComponent in this.childComponents)
            {
                childComponent.OnStart();
            }
        }

        #endregion

        #region OnStop

        public virtual void OnStop()
        {
            foreach (var childComponent in this.childComponents)
            {
                childComponent.OnStop();
            }
        }

        #endregion

        #region OnDestroy

        public virtual void OnDestroy()
        {
            foreach (var childComponent in this.childComponents)
            {
                childComponent.OnDestroy();
            }

            this.childComponents.Clear();
        }

        #endregion

        #region CreateComponents

        /// <summary>
        ///    <para>Creates a child component.</para>
        ///    <para>Use this method to instantiate your child component field or property
        ///    in <see cref="OnCreate"/> method.</para>
        /// </summary>
        /// <param name="type">Required implementation type. This type must:
        ///    1.) Derives from interface <see cref="IOregoComponent"/>
        ///    2.) Annotates with attribute <see cref="OregoContext"/>
        ///    3.) Implementation must have the default constructor.
        /// </param>
        /// <typeparam name="T">Required interface type.</typeparam>
        /// <returns>Instance of child component.</returns>
        /// 
        /// <example>
        /// Need to create an instance of a class Cat and assign to field "animal" with type IAnimal:
        /// <code>
        /// 
        /// public override void OnCreate()
        /// {
        ///    base.OnCreate();
        ///    this.animal = this.CreateComponent﹤IAnimal﹥(typeof(Cat));
        /// }
        ///
        /// </code>
        /// 
        /// The class Cat can be abstract or interface! In this case the framework will
        /// find first class derived from Cat and will create its instance.
        /// If we register a class SphynxCat under the class Cat then the system will create
        /// an instance of the class SphynxCat.
        /// </example>
        protected T CreateComponent<T>(Type type) where T : IOregoComponent
        {
            var childComponent = this.componentCreator.CreateComponent<T>(type);
            this.InitComponent(childComponent);
            return childComponent;
        }

        /// <summary>
        ///    <para>Creates child components of requred type.</para>
        ///    <para>Use this method to instantiate your child components array field or property
        ///    in <see cref="OnCreate"/> method.</para>
        /// </summary>
        /// <typeparam name="T">Required implementation types. Implementation types must:
        ///    1.) Derives from interface <see cref="IOregoComponent"/>
        ///    2.) Annotates with attribute <see cref="OregoContext"/>
        ///    3.) Implementations must have the default constructor.
        /// .</typeparam>
        /// <returns>Instance of child component.</returns>
        /// 
        /// <example>
        /// Need to create all animals derived from IAnimal and assign to array field "animal" with
        /// type IEnumerable﹤IAnimal﹥:
        /// <code>
        /// 
        /// public override void OnCreate()
        /// {
        ///    base.OnCreate();
        ///    this.animals = this.CreateComponents﹤IAnimal﹥();
        /// }
        ///
        /// </code>
        /// 
        /// Suppose we have 3 classes derives from IAnimal: Cat, Dog, Duck.
        /// If classes Cat & Dog are registered in framework system then
        /// only Cat & Dog will be created. Duck - not!
        /// </example>
        protected IEnumerable<T> CreateComponents<T>() where T : IOregoComponent
        {
            var childComponents = this.componentCreator.CreateComponents<T>();
            foreach (var childComponent in childComponents)
            {
                this.InitComponent(childComponent);
            }

            return childComponents;
        }

        private void InitComponent(IOregoComponent childComponent)
        {
            childComponent.OnCreate();
            this.childComponents.Add(childComponent);
        }

        #endregion
    }
}