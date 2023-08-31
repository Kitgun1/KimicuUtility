using UnityEngine;

namespace KiUtility.CustomComponent
{
    [CreateAssetMenu(fileName = "new Slider Settings", menuName = "Kimicu/SliderSettings", order = 0)]
    public class SliderSettings : ScriptableObject
    {
        [SerializeField] private KiSlider _prefabPrefab;

        public KiSlider Prefab => _prefabPrefab;
    }
}