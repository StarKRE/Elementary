namespace Elementary
{
    /// <summary>
    ///     <para>A contract of root system element.</para>
    ///     <para>Keeps into the element context.</para>
    ///     <para>The root element is created automatically by the element context.</para>
    /// </summary>
    public interface IRootElement : IElement
    {
    }

    /// <summary>
    ///     <para>A contract of system element.</para>.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        ///     <para>Called after constructor.</para>
        ///     <para>Use this method to instantiate child elements.</para>
        /// </summary>
        /// <param name="context">A element context that creates this element.</param>
        void OnCreate(IElementContext context);

        /// <summary>
        ///     <para>Called when all elements have created.</para>
        ///     <para>Use this method to get other element references those out of scope.</para>
        /// </summary>
        void OnPrepare();

        /// <summary>
        ///     <para>Called when all elements have prepared.</para>
        ///     <para>Use this method to subscribe on other elements.</para>
        /// </summary>
        void OnReady();

        /// <summary>
        ///     <para>Called when the element context starts its work.</para>
        ///     <para>Use this method to setup initial state.</para>
        /// </summary>
        void OnStart();

        /// <summary>
        ///     <para>Called when the element context ends its work.</para>
        ///     <para>Use this method to unsubscribe from other elements.</para>
        /// </summary>
        void OnFinish();

        /// <summary>
        ///     <para>Called when the element context disposes resources.</para>
        ///     <para>Use this method to dispose unmanaged resources.</para>
        /// </summary>
        void OnDispose();
    }
}