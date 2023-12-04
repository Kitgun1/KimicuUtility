using UnityEngine;

namespace KimicuUtility
{
    public static class KiComponentExtension
    {
        public static void Destroy<T>(this T component, float delayDestroy = 0) where T : Object =>
            Object.Destroy(component, delayDestroy);

        public static void DestroyGameObject<T>(this T gameObject, float delayDestroy = 0) where T : Component =>
            Object.Destroy(gameObject.gameObject, delayDestroy);

        public static void DestroyImmediate<T>(this T component) where T : Object =>
            Object.DestroyImmediate(component);

        public static void DestroyImmediate<T>(this T component, bool allowDestroyingAssets) where T : Object =>
            Object.DestroyImmediate(component, allowDestroyingAssets);
    }
}