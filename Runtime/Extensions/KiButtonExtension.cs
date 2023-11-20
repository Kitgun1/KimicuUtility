using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KimicuUtility
{
    public static class KiButtonExtension
    {
        public static void AddListener(this Button button, UnityAction call) => button.onClick.AddListener(call);

        public static void AddRangeListener(this Button button, IEnumerable<UnityAction> calls)
            => button.onClick.AddRangeListener(calls);

        public static void AddRangeListener(this Button.ButtonClickedEvent onClick, IEnumerable<UnityAction> calls)
        {
            foreach (UnityAction call in calls) onClick.AddListener(call);
        }

        public static void RemoveListener(this Button button, UnityAction call) => button.onClick.RemoveListener(call);

        public static void RemoveRangeListener(this Button button, IEnumerable<UnityAction> calls)
            => button.onClick.RemoveRangeListener(calls);

        public static void RemoveRangeListener(this Button.ButtonClickedEvent onClick, IEnumerable<UnityAction> calls)
        {
            foreach (UnityAction call in calls) onClick.RemoveListener(call);
        }

        public static void RemoveAllListener(this Button button) => button.onClick.RemoveAllListeners();
    }
}