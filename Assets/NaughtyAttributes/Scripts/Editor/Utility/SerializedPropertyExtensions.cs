using UnityEditor;
using UnityEngine;

namespace NaughtyAttributes.Editor
{
    public static class SerializedPropertyExtensions
    {
        public static GUIContent GetLabelContent(this SerializedProperty serializedProperty)
        {
            return new GUIContent(serializedProperty.displayName, serializedProperty.tooltip);
        }
    }
}
