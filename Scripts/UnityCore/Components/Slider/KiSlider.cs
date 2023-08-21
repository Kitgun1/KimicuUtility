using System.Globalization;
using KiUtilities.Enums;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KiUtilities.CustomComponent
{
    public class KiSlider : MonoBehaviour
    {
        [BoxGroup("Dependencies")] public TMP_Text ValueText;
        [BoxGroup("Dependencies")] public Image ValueImage;

        [BoxGroup("Properties"), SerializeField] private ValueStringFormat _maxValueFormat;
        [BoxGroup("Properties"), SerializeField] private float _minValue;
        [BoxGroup("Properties"), SerializeField] private float _maxValue;
        [BoxGroup("Properties"), SerializeField] private float _value;

        public float Value
        {
            get => _value;
            set
            {
                _value = Mathf.Clamp(value, _minValue, _maxValue);
                UpdateVisual();
            }
        }

        private void OnValidate()
        {
            if (_minValue > _maxValue)
            {
                _minValue = _maxValue;
                _maxValue += 0.01f;
            }

            _value = Mathf.Clamp(_value, _minValue, _maxValue);
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (ValueText != null)
            {
                ValueText.text = Value.Crop(_maxValueFormat).ToString(CultureInfo.InvariantCulture);
            }

            if (ValueImage != null)
            {
                ValueImage.fillAmount = KiMath.CalculatePercentage(Value, _maxValue - _minValue) / 100;
            }
        }
    }
}