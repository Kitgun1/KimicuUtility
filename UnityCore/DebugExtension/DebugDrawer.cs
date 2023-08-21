using UnityEngine;

namespace Plugins.KiUtilities.UnityCore.DebugExtension
{
    public static class DebugDrawer
    {
        // https://www.perplexity.ai/search/ea365410-ebfc-44dd-b98e-963ee97f8a47?s=u
        public static void DrawSphereCast(Vector3 start, Vector3 end,
            float radius = 0.5f,
            int spacing = 15,
            Color color = default,
            float duration = 0f)
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