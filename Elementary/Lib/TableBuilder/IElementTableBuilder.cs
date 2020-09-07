namespace Elementary
{
    /// <summary>
    ///     <para>Builds two tables that will be used to create instances of elements.</para>
    /// </summary>
    public interface IElementTableBuilder
    {
        /// <summary>
        ///     <para>Build two tables: child and parent tables.</para>
        /// </summary>
        /// <returns>A wrap with required tables.</returns>
        ElementTables BuildElementTables();
    }
}