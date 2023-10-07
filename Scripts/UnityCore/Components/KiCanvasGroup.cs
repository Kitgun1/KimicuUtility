using NaughtyAttributes;
using UnityEngine;

namespace KimicuUtility
{
    [RequireComponent(typeof(CanvasGroup))]
    public class KiCanvasGroup : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup ??= GetComponent<CanvasGroup>();
        }

        private void OnValidate()
        {
            _canvasGroup ??= GetComponent<CanvasGroup>();
        }

        [Button("OFF")]
        public void TurnOff()
        {
            _canvasGroup.Active(false);
        }

        [Button("ON")]
        public void TurnOn()
        {
            _canvasGroup.Active(true);
        }
    }
}