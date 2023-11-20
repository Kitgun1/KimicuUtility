using UnityEngine;

namespace KimicuUtility
{
    public static class VectorExtension
    {
        public static Vector3 Snap(this Vector3 vector, float snappingValue) => KiMath.Snap(vector, snappingValue);
        public static Vector2 Snap(this Vector2 vector, float snappingValue) => KiMath.Snap(vector, snappingValue);
        public static float Snap(this float vector, float snappingValue) => KiMath.Snap(vector, snappingValue);
    }
}