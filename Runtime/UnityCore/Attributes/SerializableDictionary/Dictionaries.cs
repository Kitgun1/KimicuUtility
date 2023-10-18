using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace KimicuUtility
{
    [Serializable] public class DictionaryString : SerializableDictionary<string, string> { }
    [Serializable] public class DictionaryStringInt : SerializableDictionary<string, int> { }
    [Serializable] public class DictionaryStringFloat : SerializableDictionary<string, float> { }
    [Serializable] public class DictionaryStringDouble : SerializableDictionary<string, double> { }
    [Serializable] public class DictionaryStringBool : SerializableDictionary<string, bool> { }
    [Serializable] public class DictionaryStringVector2 : SerializableDictionary<string, Vector2> { }
    [Serializable] public class DictionaryStringVector3 : SerializableDictionary<string, Vector3> { }
    [Serializable] public class DictionaryStringIgnoreAxis : SerializableDictionary<string, IgnoreAxis> { }
    
    [Serializable] public class DictionaryInt : SerializableDictionary<int, int> { }
    [Serializable] public class DictionaryIntString : SerializableDictionary<int, string> { }
    [Serializable] public class DictionaryIntFloat : SerializableDictionary<int, float> { }
    [Serializable] public class DictionaryIntDouble : SerializableDictionary<int, double> { }
    [Serializable] public class DictionaryIntBool : SerializableDictionary<int, bool> { }
    [Serializable] public class DictionaryIntVector2 : SerializableDictionary<int, Vector2> { }
    [Serializable] public class DictionaryIntVector3 : SerializableDictionary<int, Vector3> { }
    [Serializable] public class DictionaryIntIgnoreAxis : SerializableDictionary<int, IgnoreAxis> { }
    
    [Serializable] public class DictionaryFloat : SerializableDictionary<float, float> { }
    [Serializable] public class DictionaryFloatString : SerializableDictionary<float, string> { }
    [Serializable] public class DictionaryFloatInt : SerializableDictionary<float, int> { }
    [Serializable] public class DictionaryFloatDouble : SerializableDictionary<float, double> { }
    [Serializable] public class DictionaryFloatBool : SerializableDictionary<float, bool> { }
    [Serializable] public class DictionaryFloatVector2 : SerializableDictionary<float, Vector2> { }
    [Serializable] public class DictionaryFloatVector3 : SerializableDictionary<float, Vector3> { }
    [Serializable] public class DictionaryFloatIgnoreAxis : SerializableDictionary<float, IgnoreAxis> { }
    
    [Serializable] public class DictionaryDouble : SerializableDictionary<double, double> { }
    [Serializable] public class DictionaryDoubleString : SerializableDictionary<double, string> { }
    [Serializable] public class DictionaryDoubleInt : SerializableDictionary<double, int> { }
    [Serializable] public class DictionaryDoubleFloat : SerializableDictionary<double, float> { }
    [Serializable] public class DictionaryDoubleBool : SerializableDictionary<double, bool> { }
    [Serializable] public class DictionaryDoubleVector2 : SerializableDictionary<double, Vector2> { }
    [Serializable] public class DictionaryDoubleVector3 : SerializableDictionary<double, Vector3> { }
    [Serializable] public class DictionaryDoubleIgnoreAxis : SerializableDictionary<double, IgnoreAxis> { }
    
    [Serializable] public class DictionaryBool : SerializableDictionary<bool, bool> { }
    [Serializable] public class DictionaryBoolString : SerializableDictionary<bool, string> { }
    [Serializable] public class DictionaryBoolInt : SerializableDictionary<bool, int> { }
    [Serializable] public class DictionaryBoolFloat : SerializableDictionary<bool, float> { }
    [Serializable] public class DictionaryBoolDouble : SerializableDictionary<bool, double> { }
    [Serializable] public class DictionaryBoolVector2 : SerializableDictionary<bool, Vector2> { }
    [Serializable] public class DictionaryBoolVector3 : SerializableDictionary<bool, Vector3> { }
    [Serializable] public class DictionaryBoolIgnoreAxis : SerializableDictionary<bool, IgnoreAxis> { }
    
    [Serializable] public class DictionaryVector2Bool : SerializableDictionary<Vector2, bool> { }
    [Serializable] public class DictionaryVector2String : SerializableDictionary<Vector2, string> { }
    [Serializable] public class DictionaryVector2Int : SerializableDictionary<Vector2, int> { }
    [Serializable] public class DictionaryVector2Float : SerializableDictionary<Vector2, float> { }
    [Serializable] public class DictionaryVector2Double : SerializableDictionary<Vector2, double> { }
    [Serializable] public class DictionaryVector2 : SerializableDictionary<Vector2, Vector2> { }
    [Serializable] public class DictionaryVector2Vector3 : SerializableDictionary<Vector2, Vector3> { }
    [Serializable] public class DictionaryVector2IgnoreAxis : SerializableDictionary<Vector2, IgnoreAxis> { }
    
    [Serializable] public class DictionaryVector3Bool : SerializableDictionary<Vector3, bool> { }
    [Serializable] public class DictionaryVector3String : SerializableDictionary<Vector3, string> { }
    [Serializable] public class DictionaryVector3Int : SerializableDictionary<Vector3, int> { }
    [Serializable] public class DictionaryVector3Float : SerializableDictionary<Vector3, float> { }
    [Serializable] public class DictionaryVector3Double : SerializableDictionary<Vector3, double> { }
    [Serializable] public class DictionaryVector3Vector2 : SerializableDictionary<Vector3, Vector2> { }
    [Serializable] public class DictionaryVector3 : SerializableDictionary<Vector3, Vector3> { }
    [Serializable] public class DictionaryVector3IgnoreAxis : SerializableDictionary<Vector3, IgnoreAxis> { }
    
    [Serializable] public class DictionaryIgnoreAxisBool : SerializableDictionary<IgnoreAxis, bool> { }
    [Serializable] public class DictionaryIgnoreAxisString : SerializableDictionary<IgnoreAxis, string> { }
    [Serializable] public class DictionaryIgnoreAxisInt : SerializableDictionary<IgnoreAxis, int> { }
    [Serializable] public class DictionaryIgnoreAxisFloat : SerializableDictionary<IgnoreAxis, float> { }
    [Serializable] public class DictionaryIgnoreAxisDouble : SerializableDictionary<IgnoreAxis, double> { }
    [Serializable] public class DictionaryIgnoreAxisVector2 : SerializableDictionary<IgnoreAxis, Vector2> { }
    [Serializable] public class DictionaryIgnoreAxisVector3 : SerializableDictionary<IgnoreAxis, Vector3> { }
    [Serializable] public class DictionaryIgnoreAxis : SerializableDictionary<IgnoreAxis, IgnoreAxis> { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(DictionaryString))] internal class DictionaryStringDrawer : DictionaryDrawer<string, string> { }
    [CustomPropertyDrawer(typeof(DictionaryStringInt))] internal class DictionaryStringIntDrawer : DictionaryDrawer<string, int> { }
    [CustomPropertyDrawer(typeof(DictionaryStringFloat))] internal class DictionaryStringFloatDrawer : DictionaryDrawer<string, float> { }
    [CustomPropertyDrawer(typeof(DictionaryStringDouble))] internal class DictionaryStringDoubleDrawer : DictionaryDrawer<string, double> { }
    [CustomPropertyDrawer(typeof(DictionaryStringBool))] internal class DictionaryStringBoolDrawer : DictionaryDrawer<string, bool> { }
    [CustomPropertyDrawer(typeof(DictionaryStringVector2))] internal class DictionaryStringVector2Drawer : DictionaryDrawer<string, Vector2> { }
    [CustomPropertyDrawer(typeof(DictionaryStringVector3))] internal class DictionaryStringVector3Drawer : DictionaryDrawer<string, Vector3> { }
    [CustomPropertyDrawer(typeof(DictionaryStringIgnoreAxis))] internal class DictionaryStringIgnoreAxisDrawer : DictionaryDrawer<string, IgnoreAxis> { }
    
    [CustomPropertyDrawer(typeof(DictionaryInt))] internal class DictionaryIntDrawer : DictionaryDrawer<int, int> { }
    [CustomPropertyDrawer(typeof(DictionaryIntString))] internal class DictionaryIntStringDrawer : DictionaryDrawer<int, string> { }
    [CustomPropertyDrawer(typeof(DictionaryIntFloat))] internal class DictionaryIntFloatDrawer : DictionaryDrawer<int, float> { }
    [CustomPropertyDrawer(typeof(DictionaryIntDouble))] internal class DictionaryIntDoubleDrawer : DictionaryDrawer<int, double> { }
    [CustomPropertyDrawer(typeof(DictionaryIntBool))] internal class DictionaryIntBoolDrawer : DictionaryDrawer<int, bool> { }
    [CustomPropertyDrawer(typeof(DictionaryIntVector2))] internal class DictionaryIntVector2Drawer : DictionaryDrawer<int, Vector2> { }
    [CustomPropertyDrawer(typeof(DictionaryIntVector3))] internal class DictionaryIntVector3Drawer : DictionaryDrawer<int, Vector3> { }
    [CustomPropertyDrawer(typeof(DictionaryIntIgnoreAxis))] internal class DictionaryIntIgnoreAxisDrawer : DictionaryDrawer<int, IgnoreAxis> { }
    
    [CustomPropertyDrawer(typeof(DictionaryFloat))] internal class DictionaryFloatDrawer : DictionaryDrawer<float, float> { }
    [CustomPropertyDrawer(typeof(DictionaryFloatString))] internal class DictionaryFloatStringDrawer : DictionaryDrawer<float, string> { }
    [CustomPropertyDrawer(typeof(DictionaryFloatInt))] internal class DictionaryFloatIntDrawer : DictionaryDrawer<float, int> { }
    [CustomPropertyDrawer(typeof(DictionaryFloatDouble))] internal class DictionaryFloatDoubleDrawer : DictionaryDrawer<float, double> { }
    [CustomPropertyDrawer(typeof(DictionaryFloatBool))] internal class DictionaryFloatBoolDrawer : DictionaryDrawer<float, bool> { }
    [CustomPropertyDrawer(typeof(DictionaryFloatVector2))] internal class DictionaryFloatVector2Drawer : DictionaryDrawer<float, Vector2> { }
    [CustomPropertyDrawer(typeof(DictionaryFloatVector3))] internal class DictionaryFloatVector3Drawer : DictionaryDrawer<float, Vector3> { }
    [CustomPropertyDrawer(typeof(DictionaryFloatIgnoreAxis))] internal class DictionaryFloatIgnoreAxisDrawer : DictionaryDrawer<float, IgnoreAxis> { }
    
    [CustomPropertyDrawer(typeof(DictionaryDouble))] internal class DictionaryDoubleDrawer : DictionaryDrawer<double, double> { }
    [CustomPropertyDrawer(typeof(DictionaryDoubleString))] internal class DictionaryDoubleStringDrawer : DictionaryDrawer<double, string> { }
    [CustomPropertyDrawer(typeof(DictionaryDoubleInt))] internal class DictionaryDoubleIntDrawer : DictionaryDrawer<double, int> { }
    [CustomPropertyDrawer(typeof(DictionaryDoubleFloat))] internal class DictionaryDoubleFloatDrawer : DictionaryDrawer<double, float> { }
    [CustomPropertyDrawer(typeof(DictionaryDoubleBool))] internal class DictionaryDoubleBoolDrawer : DictionaryDrawer<double, bool> { }
    [CustomPropertyDrawer(typeof(DictionaryDoubleVector2))] internal class DictionaryDoubleVector2Drawer : DictionaryDrawer<double, Vector2> { }
    [CustomPropertyDrawer(typeof(DictionaryDoubleVector3))] internal class DictionaryDoubleVector3Drawer : DictionaryDrawer<double, Vector3> { }
    [CustomPropertyDrawer(typeof(DictionaryDoubleIgnoreAxis))] internal class DictionaryDoubleIgnoreAxisDrawer : DictionaryDrawer<double, IgnoreAxis> { }
    
    [CustomPropertyDrawer(typeof(DictionaryBool))] internal class DictionaryBoolDrawer : DictionaryDrawer<bool, bool> { }
    [CustomPropertyDrawer(typeof(DictionaryBoolString))] internal class DictionaryBoolStringDrawer : DictionaryDrawer<bool, string> { }
    [CustomPropertyDrawer(typeof(DictionaryBoolInt))] internal class DictionaryBoolIntDrawer : DictionaryDrawer<bool, int> { }
    [CustomPropertyDrawer(typeof(DictionaryBoolFloat))] internal class DictionaryBoolFloatDrawer : DictionaryDrawer<bool, float> { }
    [CustomPropertyDrawer(typeof(DictionaryBoolDouble))] internal class DictionaryBoolDoubleDrawer : DictionaryDrawer<bool, double> { }
    [CustomPropertyDrawer(typeof(DictionaryBoolVector2))] internal class DictionaryBoolVector2Drawer : DictionaryDrawer<bool, Vector2> { }
    [CustomPropertyDrawer(typeof(DictionaryBoolVector3))] internal class DictionaryBoolVector3Drawer : DictionaryDrawer<bool, Vector3> { }
    [CustomPropertyDrawer(typeof(DictionaryBoolIgnoreAxis))] internal class DictionaryBoolIgnoreAxisDrawer : DictionaryDrawer<bool, IgnoreAxis> { }
#endif
}