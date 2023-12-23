﻿using System;
using UnityEngine;

namespace KimicuUtility
{
    public static partial class KiMath
    {
        /// <summary> Calculates the vector between two points in 3D space, optionally ignoring one of the axes. </summary>
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
                    return (position1 + position2) / 2f;
                case IgnoreAxis.IgnoreX:
                    position1.x = 0;
                    position2.x = 0;
                    return (position1 + position2) / 2f;
                case IgnoreAxis.IgnoreY:
                    position1.y = 0;
                    position2.y = 0;
                    return (position1 + position2) / 2f;
                case IgnoreAxis.IgnoreZ:
                    position1.z = 0;
                    position2.z = 0;
                    return (position1 + position2) / 2f;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ignoreAxis), ignoreAxis, null);
            }
        }

        /// <summary> Calculates the vector between two points in 3D space, optionally ignoring one of the axes. </summary>
        /// <typeparam name="T">Any object inherited from Component.</typeparam>
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
            return position1.GetVectorBetweenPoints(position2);
        }

        #region VectorSum

        /// <summary>
        /// Calculate sum vector3 [|x| + |y| + |z|]
        /// </summary>
        public static float Sum(this Vector3 vector3)
        {
            return MathF.Abs(vector3.x) + MathF.Abs(vector3.y) + MathF.Abs(vector3.z);
        }

        /// <summary>
        /// Calculate sum vector2 [|x| + |y|]
        /// </summary>
        public static float Sum(this Vector2 vector2)
        {
            return MathF.Abs(vector2.x) + MathF.Abs(vector2.y);
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

        public static Vector3 Snap(Vector3 vector, float snappingValue)
        {
            float x = Snap(vector.x, snappingValue);
            float y = Snap(vector.y, snappingValue);
            float z = Snap(vector.z, snappingValue);
            return new Vector3(x, y, z);
        }

        public static Vector2 Snap(Vector2 vector, float snappingValue)
        {
            float x = Snap(vector.x, snappingValue);
            float y = Snap(vector.y, snappingValue);
            return new Vector2(x, y);
        }

        public static float Snap(float value, float snappingValue)
        {
            if (snappingValue == 0) return value;
            return Mathf.Round(value / snappingValue) * snappingValue;
        }
    }
}