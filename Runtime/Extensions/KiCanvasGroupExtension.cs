using UnityEngine;

namespace KimicuUtility
{
    public static class KiCanvasGroupExtension
    {
        /// <summary> State canvasGroup. </summary>
        /// <returns> Returns true if canvasGroup.alpha > 0.6f and false otherwise. </returns>
        public static bool IsActive(this CanvasGroup canvasGroup) => canvasGroup.alpha > 0.6f;

        /// <summary> Turns canvasGroup `on` or `off` </summary>
        public static void Active(this CanvasGroup canvasGroup, bool value)
        {
            canvasGroup.alpha = value ? 1 : 0;
            canvasGroup.blocksRaycasts = value;
            canvasGroup.interactable = value;
        }
        
        /// <summary> Turns canvasGroup `on` or `off` with alpha </summary>
        public static void Active(this CanvasGroup canvasGroup, float alpha)
        {
            canvasGroup.alpha = alpha;
            canvasGroup.blocksRaycasts = alpha > 0.6f;
            canvasGroup.interactable = alpha > 0.6f;
        }

        /// <summary> Switches canvasGroup to the opposite. </summary>
        public static void Switch(this CanvasGroup canvasGroup)
        {
            bool newValue = canvasGroup.IsActive();
            canvasGroup.alpha = !newValue ? 1 : 0;
            canvasGroup.blocksRaycasts = !newValue;
            canvasGroup.interactable = !newValue;
        }
    }
}