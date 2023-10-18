using UnityEngine;

namespace KimicuUtility
{
    public static class KiCanvasGroupExtension
    {
        /// <summary> Состояние canvasGroup. </summary>
        /// <returns> Возвращает true если canvasGroup.alpha &gt; 0.6f и false в ином случае. </returns>
        public static bool IsActive(this CanvasGroup canvasGroup) => canvasGroup.alpha > 0.6f;

        /// <summary> Включает или выключает canvasGroup </summary>
        public static void Active(this CanvasGroup canvasGroup, bool value)
        {
            canvasGroup.alpha = value ? 1 : 0;
            canvasGroup.blocksRaycasts = value;
            canvasGroup.interactable = value;
        }

        /// <summary> Переключает canvasGroup на противоположное. </summary>
        public static void Switch(this CanvasGroup canvasGroup)
        {
            bool newValue = canvasGroup.IsActive();
            canvasGroup.alpha = !newValue ? 1 : 0;
            canvasGroup.blocksRaycasts = !newValue;
            canvasGroup.interactable = !newValue;
        }
    }
}