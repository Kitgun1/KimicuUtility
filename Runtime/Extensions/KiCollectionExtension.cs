using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

// ReSharper disable InvalidXmlDocComment
// ReSharper disable MethodOverloadWithOptionalParameter

namespace KimicuUtility
{
    public static class KiCollectionExtension
    {
        #region List

        /// <summary> Limits the maximum number of elements in the list. </summary>
        public static void Clamp<T>(this List<T> list, int maximum = 1)
        {
            if (maximum < 1) maximum = 0;
            if (list.Count > maximum) list.RemoveRange(maximum, list.Count - maximum);
        }

        /// <summary> Limits the list to a maximum and minimum value. </summary>
        /// <param name="defaultElement"> An element that will be added if there are not enough elements in the list. </param>
        public static void Clamp<T>(this List<T> list, int minimum = 1, int maximum = 1, T defaultElement = default)
        {
            minimum = Mathf.Clamp(minimum, 1, int.MaxValue);
            maximum = Mathf.Clamp(maximum, minimum, int.MaxValue);
            if (list.Count > maximum) list.RemoveRange(maximum, list.Count - maximum);
            else if (list.Count < minimum)
            {
                int count = minimum - list.Count;
                for (int i = 0; i < count; i++) list.Insert(0, defaultElement);
            }
        }

        /// <summary> Limits the list to a maximum and minimum value. </summary>
        /// <param name="defaultElement"> An element that will be added if there are not enough elements in the list. </param>
        public static void Clamp<T>(this List<T> list, int minimum = 0, T defaultElement = default)
        {
            minimum = Mathf.Clamp(minimum, 0, int.MaxValue);
            if (list.Count >= minimum) return;
            int count = minimum - list.Count;
            for (int i = 0; i < count; i++) list.Insert(0, defaultElement);
        }

        /// <summary> Divides a list into lists. </summary>
        /// <param name="percentRatio"> Divides the list into lists by percentage. </param>
        public static List<List<T>> SplitList<T>(this List<T> list, int percentRatio)
        {
            int count = list.Count;
            int middleIndex = (int)Mathf.Floor((float)(count * percentRatio / 100d));
            var firstList = list.GetRange(0, middleIndex);
            var secondList = list.GetRange(middleIndex, count - middleIndex);
            var result = new List<List<T>> { firstList, secondList };
            return result;
        }

        /// <summary> Divides a list into lists. </summary>
        /// <param name="percentages"> The sum of the elements must not exceed 100 and must not be less than 0 and each element must be positive. </param>
        public static List<List<T>> SplitList<T>(this List<T> list, double[] percentages)
        {
            double sumPercentages = percentages.Sum();
            for (int i = 0; i < percentages.Length; i++) if (percentages[i] < 0) throw new ArgumentOutOfRangeException($"{i} list element cannot be < 0f");
            if (sumPercentages is > 100 or < 0) throw new ArgumentException("Sum of percentages should be in range (0, 100)");
            var result = new List<List<T>>();
            int startIndex = 0;
            int n = percentages.Length;
            for (int i = 0; i < n; i++)
            {
                int count = (int)(list.Count * percentages[i] / 100);
                if (i == n - 1) count = list.Count - startIndex;

                var sublist = list.GetRange(startIndex, count);
                startIndex += count;

                result.Add(sublist);
            }
            return result;
        }

        /// <summary> Divides a list into parts. </summary>
        public static List<List<T>> DivideList<T>(this List<T> list, int count)
        {
            int size = list.Count / count;
            int remainder = list.Count % count;
            var result = new List<List<T>>();

            for (int i = 0; i < count; i++)
            {
                int start = i * size + Mathf.Min(i, remainder);
                int end;
                if (i < remainder) end = start + size + 1;
                else end = start + size + 0;

                var sublist = list.GetRange(start, end - start);
                result.Add(sublist);
            }

            return result;
        }

        #endregion

        #region Dictionary
        
        public static void TrySetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.TryAdd(key, value)) dictionary[key] = value;
        }

        public static Dictionary<string, JToken> ToDictionary(this string jsonString)
        {
            var dictionary = new Dictionary<string, JToken>();
            JObject jsonObject = JObject.Parse(jsonString);
            foreach (JProperty property in jsonObject.Properties()) dictionary.Add(property.Name, property.Value);

            return dictionary;
        }

        public static string ToJson(this Dictionary<string, JToken> dictionary)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            int counter = 0;
            foreach (var item in dictionary)
            {
                bool isLast = counter + 1 == dictionary.Count;
                switch (item.Value.Type)
                {
                    case JTokenType.Boolean:
                        json.Append("\"" + item.Key + "\":" + item.Value.ToString().ToLower());
                        break;
                    case JTokenType.Float:
                    case JTokenType.Integer:
                    case JTokenType.Object:
                    case JTokenType.Array:
                        json.Append("\"" + item.Key + "\":" + item.Value);
                        break;
                    case JTokenType.String:
                        json.Append("\"" + item.Key + "\":\"" + item.Value + "\"");
                        break;
                    default:
                        json.Append("\"" + item.Key + "\":\"" + item.Value);
                        break;
                }

                if (!isLast)
                {
                    json.Append(',');
                }

                counter++;
            }

            json.Append('}');
            return json.ToString();
        }

        #endregion
    }
}