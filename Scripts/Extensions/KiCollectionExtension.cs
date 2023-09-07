using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
// ReSharper disable InvalidXmlDocComment
// ReSharper disable MethodOverloadWithOptionalParameter

namespace KiUtility
{
    public static class KiCollectionExtension
    {
        #region List

        /// <summary> Ограничивает максимальное кол-во элементов в списке. </summary>
        public static void Clamp<T>(this List<T> list, int maximum = 1)
        {
            if (maximum < 1) maximum = 0;

            if (list.Count > maximum)
            {
                list.RemoveRange(maximum, list.Count - maximum);
            }
        }

        /// <summary> Ограничивает список максимальным и минимальным значением. </summary>
        /// <param name="defaultElement"> Элемент который будет добавлен при нехватке элементов в списке. </param>
        public static void Clamp<T>(this List<T> list, int minimum = 1, int maximum = 1, T defaultElement = default)
        {
            minimum = Mathf.Clamp(minimum, 1, int.MaxValue);
            maximum = Mathf.Clamp(maximum, minimum, int.MaxValue);

            if (list.Count > maximum)
            {
                list.RemoveRange(maximum, list.Count - maximum);
            }
            else if (list.Count < minimum)
            {
                int count = minimum - list.Count;
                for (int i = 0; i < count; i++) list.Insert(0, defaultElement);
            }
        }

        /// <summary> Ограничивает список максимальным и минимальным значением. </summary>
        /// <param name="defaultElement"> Элемент который будет добавлен при нехватке элементов в списке. </param>
        public static void Clamp<T>(this List<T> list, int minimum = 0, T defaultElement = default)
        {
            minimum = Mathf.Clamp(minimum, 0, int.MaxValue);

            if (list.Count < minimum)
            {
                int count = minimum - list.Count;
                for (int i = 0; i < count; i++) list.Insert(0, defaultElement);
            }
        }

        /// <summary> Делит список на списки. </summary>
        /// <param name="percentRatio"> Делит список на списки по процентное соотношение. </param>
        public static List<List<T>> SplitList<T>(this List<T> list, int percentRatio)
        {
            int count = list.Count;
            int middleIndex = (int)Mathf.Floor((float)(count * percentRatio / 100d));
            var firstList = list.GetRange(0, middleIndex);
            var secondList = list.GetRange(middleIndex, count - middleIndex);
            var result = new List<List<T>> { firstList, secondList };
            return result;
        }


        /// <summary> Делит список на списки. </summary>
        /// <param name="percentages">  Сумма элементов не должна превышать 100 и не должна быть меньше 0 и каждый элемент должен быть положительным </param>
        public static List<List<T>> SplitList<T>(this List<T> list, double[] percentages)
        {
            double sumPercentages = percentages.Sum();

            for (int i = 0; i < percentages.Length; i++)
            {
                if (percentages[i] < 0) throw new ArgumentOutOfRangeException($"{i} элемент списка не может быть < 0f");
            }

            if (sumPercentages is > 100 or < 0)
                throw new ArgumentException("Sum of percentages should be in range (0, 100)");

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

        /// <summary> Делит список на части. </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
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
            string jsonString = "{";
            foreach (var item in dictionary)
                switch (item.Value.Type)
                {
                    case JTokenType.Boolean:
                        jsonString += "\"" + item.Key + "\":" + item.Value.ToString().ToLower() + ",";
                        break;
                    case JTokenType.Float:
                    case JTokenType.Integer:
                        jsonString += "\"" + item.Key + "\":" + item.Value + ",";
                        break;
                    case JTokenType.String:
                    default:
                        jsonString += "\"" + item.Key + "\":\"" + item.Value + "\",";
                        break;
                }

            jsonString = jsonString.TrimEnd(',') + "}";
            return jsonString;
        }

        #endregion
    }
}