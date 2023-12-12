using System.Collections.Generic;
using UnityEngine;

namespace KimicuUtility
{
    public static partial class KiMath
    {
        /// <summary> Takes n elements from the structure of objects with chances. </summary>
        /// <param name="list">Structure with objects and its chance.</param>
        /// <param name="count">The number of returned T in the queue.</param>
        /// <typeparam name="T">Any object.</typeparam>
        /// <returns>Returns a random queue T.</returns>
        public static IEnumerable<T> RandomWithChance<T>(this List<ObjectChance<T>> list, int count = 1)
        {
            var result = new T[count];

            for (int i = 0; i < count; i++)
            {
                float totalChance = default;
                foreach (var objChance in list)
                {
                    totalChance += objChance.Chance;
                }

                foreach (var objChance in list)
                {
                    var objectChance = objChance;
                    objectChance.Chance = CalculatePercentage(objectChance.Chance, totalChance);
                }

                float randomValue = UnityEngine.Random.Range(0f, totalChance);
                float cumulativeChance = default;

                foreach (var objChance in list)
                {
                    cumulativeChance += objChance.Chance;
                    if (randomValue >= cumulativeChance) continue;
                    result[i] = objChance.Object;
                    break;
                }
            }

            return result;
        }

        public static IEnumerable<T> Random<T>(this List<T> list, int count)
        {
            var result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = list[UnityEngine.Random.Range(0, list.Count)];
            }

            return result;
        }

        public static T RandomElement<T>(this List<T> list) => list[UnityEngine.Random.Range(0, list.Count)];
    }
}