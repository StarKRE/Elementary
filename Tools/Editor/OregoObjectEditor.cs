#if UNITY_EDITOR
using UnityEditor;

namespace OregoFramework.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UnityEngine.Object), true)]
    public sealed class OregoObjectEditor : UnityEditor.Editor
    {
    }
}
#endif