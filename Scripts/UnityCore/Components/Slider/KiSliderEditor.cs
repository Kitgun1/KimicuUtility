using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KiUtilities.CustomComponent
{
    internal static class KiSliderEditor
    {
#if UNITY_EDITOR

        [MenuItem("GameObject/UI/Kimicu/Slider")]
        private static void CreateSlider()
        {
            SliderSettings settings = Resources.Load<SliderSettings>("SliderSettings");
            if (settings == null) throw new NullReferenceException($"{nameof(SliderSettings)} is null.");
            Debug.Log(settings.Slider == null);
            KiSlider slider = Object.Instantiate(settings.Slider, Selection.activeTransform, true);
            RectTransform transform = slider.GetComponent<RectTransform>();
            transform.localScale = Vector3.one;
            transform.anchoredPosition = Vector2.zero;
            transform.gameObject.name = "KiSlider";
        }

#endif
    }
}