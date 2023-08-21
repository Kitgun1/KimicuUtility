using System;
using System.Collections.Generic;
using KiUtilities.Enums;
using KiUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KiUtilities
{
    public static class KiMath
    {
        /// <summary>
        /// Calculates the percentage ratio.
        /// </summary>
        /// <returns>Returns the percentage.</returns>
        public static double CalculatePercentage(double value, double total)
        {
            return value / total * 100;
        }

        /// <summary>
        /// Calculates the percentage ratio.
        /// </summary>
        /// <returns>Returns the percentage.</returns>
        public static float CalculatePercentage(float value, float total)
        {
            return value / total * 100;
        }

        /// <summary>
        /// [ENG] Returns the string format for a decimal value.
        /// <para>[RUS] Определяет оптимальный формат строки для заданного значения типа float.</para>
        /// </summary>
        /// <param name="value"><para></para>
        /// [ENG] The decimal value to format.
        /// <para>[RUS] Значение типа float, для которого нужно определить формат строки.</para> 
        /// </param>
        /// <returns>
        /// [ENG] The string format for the decimal value.
        /// <para>[RUS] Элемент перечисления ValueStringFormat, соответствующий оптимальному формату строки.</para>
        /// </returns>
        /// <exception cref="ArgumentException"><para></para>
        /// [ENG] Thrown when the value is invalid.
        /// <para>[RUS] Выбрасывается, если переданное значение не является допустимым числом.</para>
        /// </exception>
        public static ValueStringFormat OptimalStringFormat(this float value)
        {
            int decimalPlaces = BitConverter.GetBytes(decimal.GetBits((decimal)value)[3])[2];
            return decimalPlaces switch
            {
                0 => ValueStringFormat.F0,
                1 => ValueStringFormat.F1,
                2 => ValueStringFormat.F2,
                3 => ValueStringFormat.F3,
                4 => ValueStringFormat.F4,
                5 => ValueStringFormat.F5,
                6 => ValueStringFormat.F6,
                _ => throw new ArgumentException("Invalid value")
            };
        }

        public static float Crop(this float value, ValueStringFormat format)
        {
            int digits = int.Parse(format.ToString()[1..]);
            return (float)Math.Round(value, digits);
        }

        /// <summary>
        /// Takes n elements from the structure of objects with chances.
        /// </summary>
        /// <param name="list">Structure with objects and its chance.</param>
        /// <param name="count">The number of returned T in the list.</param>
        /// <typeparam name="T">Any object.</typeparam>
        /// <returns>Returns a random list T.</returns>
        public static T[] RandomWithChance<T>(this List<ObjectChance<T>> list, int count)
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

        /// <summary>
        /// Calculates the vector between two points in 3D space, optionally ignoring one of the axes.
        /// </summary>
        /// <param name="position1">The first point in 3D space.</param>
        /// <param name="position2">The second point in 3D space.</param>
        /// <param name="ignoreAxis">The axis to ignore when calculating the vector.</param>
        /// <returns>The vector between the two points.</returns>
        public static Vector3 GetVectorBetweenPoints(this Vector3 position1, Vector3 position2,
            IgnoreAxis ignoreAxis = IgnoreAxis.None)
        {
            switch (ignoreAxis)
            {
                case IgnoreAxis.None:
                    return position1 - position2;
                case IgnoreAxis.IgnoreX:
                    position1.x = 0;
                    position2.x = 0;
                    return position1 - position2;
                case IgnoreAxis.IgnoreY:
                    position1.y = 0;
                    position2.y = 0;
                    return position1 - position2;
                case IgnoreAxis.IgnoreZ:
                    position1.z = 0;
                    position2.z = 0;
                    return position1 - position2;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ignoreAxis), ignoreAxis, null);
            }
        }

        /// <summary>
        /// Calculates the vector between two points in 3D space, optionally ignoring one of the axes.
        /// </summary>
        /// <typeparam name="T">Any object inherited from Component.</typeparam>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        /// <param name="ignoreAxis">The axis to ignore when calculating the vector.</param>
        /// <returns>The vector between the two points.</returns>
        /// <remarks>
        /// This method is an extension method for the Component class, which means it can be called on any object that inherits from Component.
        /// </remarks>
        public static Vector3 GetVectorBetweenPoints<T>(this T point1, T point2,
            IgnoreAxis ignoreAxis = IgnoreAxis.None)
            where T : Component
        {
            Vector3 position1 = point1.transform.position;
            Vector3 position2 = point2.transform.position;
            switch (ignoreAxis)
            {
                case IgnoreAxis.None:
                    break;
                case IgnoreAxis.IgnoreX:
                    position1.x = 0;
                    position2.x = 0;
                    break;
                case IgnoreAxis.IgnoreY:
                    position1.y = 0;
                    position2.y = 0;
                    break;
                case IgnoreAxis.IgnoreZ:
                    position1.z = 0;
                    position2.z = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ignoreAxis), ignoreAxis, null);
            }

            return position1 - position2;
        }

        #region VectorSum

        /// <summary>
        /// Calculate sum vector3 [x + y + z]
        /// </summary>
        public static float Sum(this Vector3 vector3)
        {
            return MathF.Abs(vector3.x) + MathF.Abs(vector3.y) + MathF.Abs(vector3.z);
        }

        /// <summary>
        /// Calculate sum vector2 [x + y]
        /// </summary>
        public static float Sum(this Vector2 vector2)
        {
            return vector2.x + vector2.y;
        }

        /// <summary>
        /// Calculate sum vector3Int [x + y + z]
        /// </summary>
        public static int Sum(this Vector3Int vector3)
        {
            return vector3.x + vector3.y + vector3.z;
        }

        /// <summary>
        /// Calculate sum vector2Int [x + y]
        /// </summary>
        public static int Sum(this Vector2Int vector2)
        {
            return vector2.x + vector2.y;
        }

        #endregion
    }
}