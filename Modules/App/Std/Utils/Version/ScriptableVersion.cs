using UnityEngine;

namespace ElementaryFramework.Util
{
    [CreateAssetMenu(
        fileName = "ScriptableVersion",
        menuName = "Elementary/Util/New ScriptableVersion"
    )]
    public sealed class ScriptableVersion : ScriptableObject
    {
        [SerializeField] 
        public int version;
    }
}