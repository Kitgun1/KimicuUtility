using KiUtility;
using NaughtyAttributes;
using UnityEngine;

namespace KimicuUtility.Scripts.UnityCore.Components
{
    [RequireComponent(typeof(CanvasGroup))]
    public class KiCanvasGroup : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void OnValidate()
        {
            _canvasGroup ??= GetComponent<CanvasGroup>();
        }

        [Button("OFF")]
        private void TurnOff()
        {
            _canvasGroup.Active(false);
        }

        [Button("ON")]
        private void TurnOn()
        {
            _canvasGroup.Active(true);
        }
    }
}