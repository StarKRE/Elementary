namespace Elementary
{
    /// <summary>
    ///     <para>Builds two hierarchy type tables: child and parent. </para>
    /// </summary>
    public interface IElementTableBuilder
    {
        ElementTables BuildElementTables();
    }
}