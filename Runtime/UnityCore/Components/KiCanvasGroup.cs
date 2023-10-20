using NaughtyAttributes;
using UnityEngine;

namespace KimicuUtility
{
    [RequireComponent(typeof(CanvasGroup))]
    public class KiCanvasGroup : MonoBehaviour
    {
        private CanvasGroup m_CanvasGroup;

        private void Awake() => m_CanvasGroup ??= GetComponent<CanvasGroup>();
        private void OnValidate() => m_CanvasGroup ??= GetComponent<CanvasGroup>();

        [Button("OFF")]
        public void TurnOff() => m_CanvasGroup.Active(false);

        [Button("ON")]
        public void TurnOn() => m_CanvasGroup.Active(true);
    }
}