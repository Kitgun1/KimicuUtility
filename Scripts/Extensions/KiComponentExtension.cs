using UnityEngine;

namespace KimicuUtility
{
    public static class KiComponentExtension
    {
        public static void Destroy<T>(this T component, float delayDestroy = 0) where T : Component
        {
            Object.Destroy(component, delayDestroy);
        }

        public static void Destroy(this GameObject gameObject, float delayDestroy = 0)
        {
            Object.Destroy(gameObject, delayDestroy);
        }
    }
}