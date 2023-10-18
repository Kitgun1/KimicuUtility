#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KimicuUtility.Editor
{
    [CustomPropertyDrawer(typeof(Range<>))]
    public class RangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            float textWidth = 30;
            float spacing = 5;
            float width = position.width / 2 - textWidth - spacing;

            Rect minRect = new Rect(position.x + textWidth, position.y, width, position.height);
            Rect maxRect = new Rect(position.x + width + textWidth * 2 + spacing, position.y, width, position.height);

            EditorGUI.PropertyField(minRect, property.FindPropertyRelative("m_Min"), GUIContent.none);
            minRect.position += new Vector2(-textWidth, 0);
            EditorGUI.LabelField(minRect, "Min");

            EditorGUI.PropertyField(maxRect, property.FindPropertyRelative("m_Max"), GUIContent.none);
            maxRect.position += new Vector2(-textWidth, 0);
            EditorGUI.LabelField(maxRect, "Max");

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
#endif