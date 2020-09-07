namespace Elementary
{
    /// <summary>
    ///     <para>A base interface of element context.</para>.
    ///     <para>Any implementation of this interface must contains only default constructor</para>
    /// </summary>
    public interface IElement
    {
        /// <summary>
        ///     <para>Called after constructor.</para>
        ///     <para>Use this method to instantiate child elements of this element.</para>
        /// </summary>
        /// <param name="context">A parent context that contains this element.</param>
        void OnCreate(IElementContext context);

        /// <summary>
        ///     <para>Called after all elements have been created in the context.</para>
        ///     <para>Use this method to provide other elements from the context to this element.</para>
        /// </summary>
        void OnPrepare();

        /// <summary>
        ///     <para>Called after all elements have been prepared in the context.</para>
        ///     <para>Use this method to subscribe on other elements for this element.</para>
        /// </summary>
        void OnReady();

        /// <summary>
        ///     <para>Called after all elements have been ready in the context.</para>
        ///     <para>Use this method to setup initial state of this element.</para>
        /// </summary>
        void OnStart();

        /// <summary>
        ///     <para>Called before parent context is terminating.</para>
        ///     <para>Use this method to unsubscribe from other elements for this element.</para>
        /// </summary>
        void OnFinish();

        /// <summary>
        ///     <para>Called when parent context is terminating.</para>
        ///     <para>Use this method to dispose resources from this element.</para>
        /// </summary>
        void OnDispose();
    }
}