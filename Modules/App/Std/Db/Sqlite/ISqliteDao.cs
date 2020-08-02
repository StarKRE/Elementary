using System.Collections;

namespace ElementaryFramework.App
{
    public interface ISqliteDao : IDao
    {
        IEnumerator OnConnect();
    }
}