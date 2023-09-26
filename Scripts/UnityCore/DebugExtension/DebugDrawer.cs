using UnityEngine;

namespace Plugins.KiUtilities.UnityCore.DebugExtension
{
    public static class DebugDrawer
    {
        /// <summary> Draws a sphere cast between two points. </summary>
        /// <param name="start">The starting point of the sphere cast.</param>
        /// <param name="end">The ending point of the sphere cast.</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// <param name="spacing">The spacing between each ray in degrees.</param>
        /// <param name="color">The color of the sphere cast.</param>
        /// <param name="duration">The duration of the sphere cast.</param>
        public static void DrawSphereCast(Vector3 start, Vector3 end, float radius = 0.5f, int spacing = 15,
            Color color = default, float duration = 0f)
        {
            int numRays = 360 / spacing;
            float angleIncrement = 360f / numRays;

            for (int i = 0; i < numRays; i++)
            {
                float angle = i * angleIncrement;
                Vector3 offset = Quaternion.Euler(0f, angle, 0f) * Vector3.forward * radius;
                Debug.DrawLine(start + offset, end + offset, color, duration);
            }
        }
    }
}