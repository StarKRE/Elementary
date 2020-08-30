namespace Elementary
{
    /// <summary>
    ///     <para>Base interface in the element context.</para>
    /// </summary>
    public interface IElement
    {
        /// <summary>
        ///     <para>Called after constructor.
        ///     Use this method to create child elements.</para>
        /// </summary>
        /// <param name="context">Element system. Responsibles for all elements.</param>
        void OnCreate(IElementContext context);

        /// <summary>
        ///     <para>Called after all elements are created.
        ///     Use this method to bind elements each other.</para>
        /// </summary>
        void OnPrepare();

        /// <summary>
        ///     <para>Called after all elements are bound.
        ///     Use this method to subscribe on other elements.</para>
        /// </summary>
        void OnReady();

        /// <summary>
        ///     <para>Called after all elements are ready.
        ///     Use this method to setup initial state.</para>
        /// </summary>
        void OnStart();

        /// <summary>
        ///     <para>Called when context is terminating.
        ///     Use this method to unsubscribe from other elements.</para>
        /// </summary>
        void OnFinish();

        /// <summary>
        ///     <para>Called before destroying context.
        ///     Use this method to dispose resources.</para>
        /// </summary>
        void OnDispose();
    }
}