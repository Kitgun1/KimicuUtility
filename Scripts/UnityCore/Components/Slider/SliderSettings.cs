using KiUtilities.CustomComponent;
using KiUtilities.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KiUtilities.CustomComponent
{
    [CreateAssetMenu(fileName = "new Slider Settings", menuName = "Kimicu/SliderSettings", order = 0)]
    public class SliderSettings : ScriptableObject
    {
        [SerializeField] private KiSlider _sliderPrefab;

        public KiSlider Slider
        {
            get => _sliderPrefab;
            private set => _sliderPrefab = value;
        }
    }
}