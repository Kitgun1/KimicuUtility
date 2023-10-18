#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KimicuUtility.Editor
{
    [CustomPropertyDrawer(typeof(ObjectChance<>))]
    public class ObjectChanceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            float textWidthObject = 45;
            float textWidthChance = 50;
            float spacing = 5;
            float widthObject = position.width / 1.5f - textWidthObject;
            float widthChance = position.width - widthObject - textWidthObject - textWidthChance - spacing;

            Rect objectRect = new(position.x + textWidthObject, position.y, widthObject, position.height);
            Rect chanceRect = new(position.x + widthObject + textWidthObject + textWidthChance + spacing, position.y,
                widthChance, position.height);

            EditorGUI.PropertyField(objectRect, property.FindPropertyRelative("Object"), GUIContent.none);
            objectRect.position += new Vector2(-textWidthObject, 0);
            EditorGUI.LabelField(objectRect, "Object");

            EditorGUI.PropertyField(chanceRect, property.FindPropertyRelative("m_Chance"), GUIContent.none);
            chanceRect.position += new Vector2(-textWidthChance, 0);
            EditorGUI.LabelField(chanceRect, "Chance");

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
#endif