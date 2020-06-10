using UnityEngine;

namespace OregoFramework.Util
{
    [CreateAssetMenu(
        fileName = "ScriptableVersion",
        menuName = "Orego/Util/New ScriptableVersion"
    )]
    public sealed class ScriptableVersion : AutoScriptableObject
    {
        [SerializeField] 
        public int version;
    }
}