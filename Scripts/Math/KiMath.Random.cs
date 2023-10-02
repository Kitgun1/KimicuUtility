using System.Collections.Generic;
using UnityEngine;

namespace KimicuUtility
{
    public static partial class KiMath
    {
        /// <summary> Takes n elements from the structure of objects with chances. </summary>
        /// <param name="list">Structure with objects and its chance.</param>
        /// <param name="count">The number of returned T in the list.</param>
        /// <typeparam name="T">Any object.</typeparam>
        /// <returns>Returns a random list T.</returns>
        public static T[] RandomWithChance<T>(this List<ObjectChance<T>> list, int count = 1)
        {
            List<T> result = new List<T>();

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

                float randomValue = Random.Range(0f, totalChance);
                float cumulativeChance = default;

                foreach (var objChance in list)
                {
                    cumulativeChance += objChance.Chance;
                    if (randomValue >= cumulativeChance) continue;
                    result.Add(objChance.Object);
                    break;
                }
            }

            return result.ToArray();
        }
    }
}