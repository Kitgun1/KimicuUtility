using System;
using UnityEngine;

namespace KiUtility
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
    }
}