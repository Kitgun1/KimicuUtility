#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KimicuUtility.Editor
{
    [CustomPropertyDrawer(typeof(Bounds))]
    public class BoundsDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 18 * 2 + 4;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            position.height = 18;

            float textWidth = 45;
            float spacing = 5;
            float widthField = position.width / 2 - textWidth;

            Rect leftRect = new Rect(position.x + textWidth, position.y, widthField - spacing, position.height);
            Rect rightRect = new Rect(position.x + widthField + textWidth * 2, position.y, widthField,
                position.height);

            EditorGUI.PropertyField(leftRect, property.FindPropertyRelative("XMin"), GUIContent.none);
            leftRect.position += new Vector2(-textWidth, 0);
            EditorGUI.LabelField(leftRect, "X Min");

            leftRect.position += new Vector2(+textWidth, position.height + 2);
            EditorGUI.PropertyField(leftRect, property.FindPropertyRelative("YMin"), GUIContent.none);
            leftRect.position += new Vector2(-textWidth, 0);
            EditorGUI.LabelField(leftRect, "Y Min");

            EditorGUI.PropertyField(rightRect, property.FindPropertyRelative("YMax"), GUIContent.none);
            rightRect.position += new Vector2(-textWidth, 0);
            EditorGUI.LabelField(rightRect, "Y Max");

            rightRect.position += new Vector2(+textWidth, position.height + 2);
            EditorGUI.PropertyField(rightRect, property.FindPropertyRelative("YMax"), GUIContent.none);
            rightRect.position += new Vector2(-textWidth, 0);
            EditorGUI.LabelField(rightRect, "Y Max");

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
#endif