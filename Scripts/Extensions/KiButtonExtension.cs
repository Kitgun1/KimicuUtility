using UnityEngine.Events;
using UnityEngine.UI;

namespace KiUtility
{
    public static class KiButtonExtension
    {
        public static void AddListener(this Button button, UnityAction call)
            => button.onClick.AddListener(call);

        public static void RemoveListener(this Button button, UnityAction call)
            => button.onClick.RemoveListener(call);

        public static void RemoveAllListener(this Button button)
            => button.onClick.RemoveAllListeners();
    }
}