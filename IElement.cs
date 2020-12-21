namespace Elementary
{
    /// <summary>
    ///     <para>A base contract of element.</para>.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        ///     <para>Called after constructor.</para>
        ///     <para>Use this method to instantiate child elements.</para>
        /// </summary>
        /// <param name="context">A parent context that contains this element.</param>
        void OnCreate(IElementContext context);

        /// <summary>
        ///     <para>Called when all elements have created.</para>
        ///     <para>Use this method to get other element references.</para>
        /// </summary>
        void OnPrepare();

        /// <summary>
        ///     <para>Called when all elements have prepared.</para>
        ///     <para>Use this method to subscribe on other elements.</para>
        /// </summary>
        void OnReady();

        /// <summary>
        ///     <para>Called when all elements have ready.</para>
        ///     <para>Use this method to setup initial state.</para>
        /// </summary>
        void OnStart();

        /// <summary>
        ///     <para>Called before parent context is terminating.</para>
        ///     <para>Use this method to unsubscribe from other elements.</para>
        /// </summary>
        void OnFinish();

        /// <summary>
        ///     <para>Called when parent context is terminating.</para>
        ///     <para>Use this method to dispose resources.</para>
        /// </summary>
        void OnDispose();
    }
}