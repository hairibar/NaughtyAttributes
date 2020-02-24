using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

namespace NaughtyAttributes.Editor
{
	public class ReorderableListPropertyDrawer : SpecialCasePropertyDrawerBase
	{
		public static readonly ReorderableListPropertyDrawer Instance = new ReorderableListPropertyDrawer();

		private readonly Dictionary<string, ReorderableList> _reorderableListsByPropertyName = new Dictionary<string, ReorderableList>();

		private string GetPropertyKeyName(SerializedProperty property)
		{
			return property.serializedObject.targetObject.GetInstanceID() + "/" + property.name;
		}

		protected override void OnGUI_Internal(SerializedProperty property, GUIContent label)
		{
			if (property.isArray)
			{
				string key = GetPropertyKeyName(property);

				if (!_reorderableListsByPropertyName.ContainsKey(key))
				{
					_reorderableListsByPropertyName[key] = ReorderableListUtility.Create(property, true, true, true, true, label.text);
				}

				_reorderableListsByPropertyName[key].DoLayoutList();
			}
			else
			{
				string message = typeof(ReorderableListAttribute).Name + " can be used only on arrays or lists";
				NaughtyEditorGUI.HelpBox_Layout(message, MessageType.Warning, context: property.serializedObject.targetObject);
				EditorGUILayout.PropertyField(property, true);
			}
		}

		public void ClearCache()
		{
			_reorderableListsByPropertyName.Clear();
		}
	}
}
