namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base interface for all system elements in the Orego framework.</para>
    ///     <para>This interface defines his lifecycle that is maintained by the system.</para>
    ///     <para>All derived classes must have default constructor.</para>
    /// </summary>
    public interface IElement
    {
        /// <summary>
        ///     <para>Invokes after default constructor. You can use this callback as
        ///     second constructor to instantiate your fields, properties and load inner resources.
        ///     </para>
        /// </summary>
        void OnCreate();

        /// <summary>
        ///     <para>Invokes after all elements are created in the framework system.
        ///     You can use this callback to bind your elements to each other.</para>
        /// </summary>
        void OnPrepare();

        /// <summary>
        ///     <para>Invokes after all elements are prepared in the framework system.
        ///     You can use this callback to subscribe on events of your elements.</para>
        /// </summary>
        void OnReady();

        /// <summary>
        ///     <para>Invokes after all elements are ready in the framework system.
        ///     You can use this callback to setup default state.</para>
        /// </summary>
        void OnStart();

        /// <summary>
        ///     <para>Invokes when the framework finishes its work. You can use this callback
        ///     to unsubscribe from events of your elements.</para>
        /// </summary>
        void OnFinish();

        /// <summary>
        ///     <para>Invokes after all elements are stoped in the framework system.</para>
        ///     You can use this callback as destructor to disponse your fields, properties and
        ///     inner resources.
        /// </summary>
        void OnDestroy();
    }
}