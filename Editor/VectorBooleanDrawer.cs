#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KimicuUtility.Editor
{
    [CustomPropertyDrawer(typeof(VectorBoolean4))]
    public class VectorBoolean4Drawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            float width = position.width / 4;

            Rect xRect = new Rect(position.x, position.y, width, position.height);
            Rect yRect = new Rect(position.x + width, position.y, width, position.height);
            Rect zRect = new Rect(position.x + 2 * width, position.y, width, position.height);
            Rect wRect = new Rect(position.x + 3 * width, position.y, width, position.height);

            EditorGUI.PropertyField(xRect, property.FindPropertyRelative("X"), GUIContent.none);
            xRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(xRect, "X");
            EditorGUI.PropertyField(yRect, property.FindPropertyRelative("Y"), GUIContent.none);
            yRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(yRect, "Y");
            EditorGUI.PropertyField(zRect, property.FindPropertyRelative("Z"), GUIContent.none);
            zRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(zRect, "Z");
            EditorGUI.PropertyField(wRect, property.FindPropertyRelative("W"), GUIContent.none);
            wRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(wRect, "W");

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(VectorBoolean2))]
    public class VectorBoolean2Drawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            float width = position.width / 4;

            Rect xRect = new Rect(position.x, position.y, width, position.height);
            Rect yRect = new Rect(position.x + width, position.y, width, position.height);

            EditorGUI.PropertyField(xRect, property.FindPropertyRelative("X"), GUIContent.none);
            xRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(xRect, "X");
            EditorGUI.PropertyField(yRect, property.FindPropertyRelative("Y"), GUIContent.none);
            yRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(yRect, "Y");

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(VectorBoolean3))]
    public class VectorBoolean3Drawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            float width = position.width / 4;

            Rect xRect = new Rect(position.x, position.y, width, position.height);
            Rect yRect = new Rect(position.x + width, position.y, width, position.height);
            Rect zRect = new Rect(position.x + 2 * width, position.y, width, position.height);

            EditorGUI.PropertyField(xRect, property.FindPropertyRelative("X"), GUIContent.none);
            xRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(xRect, "X");
            EditorGUI.PropertyField(yRect, property.FindPropertyRelative("Y"), GUIContent.none);
            yRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(yRect, "Y");
            EditorGUI.PropertyField(zRect, property.FindPropertyRelative("Z"), GUIContent.none);
            zRect.position += new Vector2(-15, 0);
            EditorGUI.LabelField(zRect, "Z");

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
#endif