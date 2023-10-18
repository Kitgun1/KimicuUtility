using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityObject = UnityEngine.Object;

#if UNITY_EDITOR
namespace KimicuUtility
{
    public abstract class DictionaryDrawer<TKey, TValue> : PropertyDrawer
    {
        private SerializableDictionary<TKey, TValue> _dictionary;
        private bool _foldout;
        private const float ButtonWidth = 40f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            CheckInitialize(property, label);
            if (_foldout) return (_dictionary.Count + 1) * 23f;
            return 23f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            CheckInitialize(property, label);

            position.height = 20;

            var foldoutRect = position;
            foldoutRect.width -= 2 * ButtonWidth;
            EditorGUI.BeginChangeCheck();
            _foldout = EditorGUI.Foldout(foldoutRect, _foldout, label, true);
            if (EditorGUI.EndChangeCheck())
                EditorPrefs.SetBool(label.text, _foldout);

            Rect buttonRect = position;
            buttonRect.x = -ButtonWidth + position.width + 17;
            buttonRect.width = ButtonWidth;

            if (GUI.Button(buttonRect, new GUIContent("Add"), EditorStyles.miniButton))
            {
                AddNewItem();
            }

            buttonRect.x -= ButtonWidth + 5;

            if (GUI.Button(buttonRect, new GUIContent("Clear"), EditorStyles.miniButtonRight))
            {
                ClearDictionary();
            }

            if (!_foldout) return;

            foreach (var item in _dictionary)
            {
                TKey key = item.Key;
                TValue value = item.Value;

                position.y += 23f;

                Rect keyRect = position;
                keyRect.width /= 2f;
                keyRect.width -= 40;
                EditorGUI.BeginChangeCheck();
                TKey newKey = DoField(keyRect, typeof(TKey), key);
                if (EditorGUI.EndChangeCheck())
                {
                    try
                    {
                        _dictionary.Remove(key);
                        _dictionary.Add(newKey, value);
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning(e.Message);
                    }

                    break;
                }

                Rect valueRect = position;
                valueRect.x = position.width / 2 - 15;
                valueRect.width = keyRect.width + 65 - ButtonWidth / 2;
                EditorGUI.BeginChangeCheck();
                value = DoField(valueRect, typeof(TValue), value);
                if (EditorGUI.EndChangeCheck())
                {
                    _dictionary[key] = value;
                    break;
                }

                var removeRect = valueRect;
                removeRect.x = valueRect.xMax + 7;
                removeRect.width = ButtonWidth / 2;
                if (GUI.Button(removeRect, new GUIContent("x"), EditorStyles.miniButtonRight))
                {
                    RemoveItem(key);
                    break;
                }
            }
        }

        private void RemoveItem(TKey key)
        {
            _dictionary.Remove(key);
        }

        private void CheckInitialize(SerializedProperty property, GUIContent label)
        {
            if (_dictionary != null) return;

            UnityObject target = property.serializedObject.targetObject;
            _dictionary = fieldInfo.GetValue(target) as SerializableDictionary<TKey, TValue>;
            if (_dictionary == null)
            {
                _dictionary = new SerializableDictionary<TKey, TValue>();
                fieldInfo.SetValue(target, _dictionary);
            }

            _foldout = EditorPrefs.GetBool(label.text);
        }

        private static readonly Dictionary<Type, Func<Rect, object, object>> Fields = new() {
            { typeof(int), (rect, value) => EditorGUI.IntField(rect, (int)value) },
            { typeof(float), (rect, value) => EditorGUI.FloatField(rect, (float)value) },
            { typeof(string), (rect, value) => EditorGUI.TextField(rect, (string)value) },
            { typeof(bool), (rect, value) => EditorGUI.Toggle(rect, (bool)value) },
            { typeof(Vector2), (rect, value) => EditorGUI.Vector2Field(rect, GUIContent.none, (Vector2)value) },
            { typeof(Vector3), (rect, value) => EditorGUI.Vector3Field(rect, GUIContent.none, (Vector3)value) },
            { typeof(Bounds), (rect, value) => EditorGUI.BoundsField(rect, (UnityEngine.Bounds)value) },
            { typeof(Rect), (rect, value) => EditorGUI.RectField(rect, (Rect)value) },
        };

        private static T DoField<T>(Rect rect, Type type, T value)
        {
            if (Fields.TryGetValue(type, out var field))
                return (T)field(rect, value);

            if (type.IsEnum) return (T)(object)EditorGUI.EnumPopup(rect, (Enum)(object)value);

            if (typeof(UnityObject).IsAssignableFrom(type))
                return (T)(object)EditorGUI.ObjectField(rect, (UnityObject)(object)value, type, true);

            Debug.Log("Type is not supported: " + type);
            return value;
        }

        private void ClearDictionary()
        {
            _dictionary.Clear();
        }

        private void AddNewItem()
        {
            TKey key;
            if (typeof(TKey) == typeof(string)) key = (TKey)(object)"";
            else key = default;

            TValue value = default;
            try
            {
                _dictionary.TryAdd(key, value);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
#endif