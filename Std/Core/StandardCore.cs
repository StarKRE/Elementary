using System;
using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The standard core deployes Orego framework system using
    ///     the standard Orego module set.</para>
    /// </summary>
    public class StandardCore : ModularCore
    {
        /// <summary>
        ///     <para>Loads the standard Orego module set. You can create and add
        ///     your custom modules by implementing the interface <see cref="IModule"/>.</para>
        /// </summary>
        protected override Dictionary<Type, IModule> LoadModuleMap()
        {
            return new Dictionary<Type, IModule>
            {
                {typeof(IElementTypePool), new StandardElementTypePool()},
                {typeof(IElementCreator), new ElementCreator()},
                {typeof(IElementSingletonPool), new ElementSingletonPool()}
            };
        }

        /// <summary>
        ///     <para>Invokes after creating of the modules.</para>
        /// </summary>
        protected override void SetupFramework()
        {
            this.GetModule<IElementTypePool>().LoadTypes();
            this.GetModule<IElementSingletonPool>().LoadSingletons();
        }
    }
}