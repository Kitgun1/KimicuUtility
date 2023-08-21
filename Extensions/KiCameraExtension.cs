using UnityEngine;

namespace KiUtilities
{
    public static class KiCameraExtension
    {
        private static readonly Camera Camera = Camera.main;

        public static void SetWorldSpace<T>(this T component, Vector2 screenPosition) where T : Component
        {
            component.transform.position = Camera.ScreenToWorldPoint(screenPosition);
        }

        public static Vector3 GetWorldSpace(this Vector2 screenPosition, float z = 0)
        {
            if (z == 0)
                return Camera.ScreenToWorldPoint(screenPosition);
            else
                return Camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, z));
        }

        public static Vector3 GetWorldSpace(this Vector3 screenPosition, float z = 0)
        {
            return Camera.ScreenToWorldPoint(z == 0
                ? screenPosition
                : new Vector3(screenPosition.x, screenPosition.y, z));
        }

        public static Ray GetScreenPointToRay(this Vector2 screenPosition)
        {
            return Camera.ScreenPointToRay(screenPosition);
        }

        public static Ray GetScreenPointToRay(this Vector3 screenPosition)
        {
            return GetScreenPointToRay((Vector2)screenPosition);
        }
    }
}