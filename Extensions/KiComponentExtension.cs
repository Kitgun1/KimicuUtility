using UnityEngine;

namespace KiUtilities
{
    public static class KiComponentExtension
    {
        public static bool IsActive(this CanvasGroup canvasGroup) => canvasGroup.alpha > 0.6f;

        public static void Active(this CanvasGroup canvasGroup, bool value)
        {
            canvasGroup.alpha = value ? 1 : 0;
            canvasGroup.blocksRaycasts = value;
            canvasGroup.interactable = value;
        }

        public static void Switch(this CanvasGroup canvasGroup)
        {
            bool newValue = canvasGroup.IsActive();
            canvasGroup.alpha = !newValue ? 1 : 0;
            canvasGroup.blocksRaycasts = !newValue;
            canvasGroup.interactable = !newValue;
        }
    }
}