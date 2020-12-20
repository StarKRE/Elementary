namespace Elementary
{
    /// <summary>
    ///     <para>Builds an element sheet that will be used to create instances of elements.</para>
    /// </summary>
    public interface IElementSheetBuilder
    {
        /// <inheritdoc cref="IElementSheetBuilder"/>
        ElementSheet Build();
    }
}