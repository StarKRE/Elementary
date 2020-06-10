namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base interface for all system components in the Orego framework.</para>
    ///     <para>This interface defines his lifecycle that is maintained by the system.</para>
    ///     <para>All derived classes must have default constructor.</para>
    /// </summary>
    public interface IOregoComponent
    {
        /// <summary>
        ///     <para>Invokes after default constructor. You can use this callback as
        ///     second constructor to instantiate your fields, properties and load inner resources.
        ///     </para>
        /// </summary>
        void OnCreate();

        /// <summary>
        ///     <para>Invokes after all components are created in the framework system.
        ///     You can use this callback to bind your components to each other.</para>
        /// </summary>
        void OnPrepare();

        /// <summary>
        ///     <para>Invokes after all components are prepared in the framework system.
        ///     You can use this callback to subscribe on events of your components.</para>
        /// </summary>
        void OnReady();

        /// <summary>
        ///     <para>Invokes after all components are ready in the framework system.</para>
        /// </summary>
        void OnStart();

        /// <summary>
        ///     <para>Invokes when the framework finishes its work. You can use this callback
        ///     to unsubscribe from events of your components.</para>
        /// </summary>
        void OnStop();

        /// <summary>
        ///     <para>Invokes after all components are stoped in the framework system.</para>
        ///     You can use this callback as destructor to disponse your fields, properties and
        ///     inner resources.
        /// </summary>
        void OnDestroy();
    }
}