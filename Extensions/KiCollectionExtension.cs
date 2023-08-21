using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace KiUtilities
{
    public static class KiCollectionExtension
    {
        #region List

        public static void Clamp<T>(this List<T> list, int maximum = 1)
        {
            if (maximum < 1) maximum = 0;

            if (list.Count > maximum)
            {
                list.RemoveRange(list.Count - maximum, list.Count - maximum);
            }
            else if (list.Count < maximum)
            {
                int count = maximum - list.Count;
                for (int i = 0; i < count; i++) list.Add(default);
            }
        }

        public static List<List<T>> SplitList<T>(this List<T> list, int percentRatio)
        {
            int count = list.Count;
            int middleIndex = (int)Mathf.Floor((float)(count * percentRatio / 100d));
            var firstList = list.GetRange(0, middleIndex);
            var secondList = list.GetRange(middleIndex, count - middleIndex);
            var result = new List<List<T>> { firstList, secondList };
            return result;
        }

        public static List<List<T>> SplitList<T>(this List<T> list, int n, double[] percentages)
        {
            if (percentages.Length != n) throw new ArgumentException("Number of percentages should be equal to n");

            double sumPercentages = percentages.Sum();

            if (sumPercentages is > 100 or < 0)
                throw new ArgumentException("Sum of percentages should be in range (0, 100)");

            var result = new List<List<T>>();

            int startIndex = 0;
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