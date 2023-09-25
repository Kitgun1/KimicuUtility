using System.Globalization;
using KiUtility;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KiUtility.CustomComponent
{
    public class KiSlider : MonoBehaviour
    {
        [BoxGroup("Dependencies")] public TMP_Text ValueText;
        [BoxGroup("Dependencies")] public Image ValueImage;

        [BoxGroup("Properties"), SerializeField] private ValueStringFormat _maxValueFormat;
        [BoxGroup("Properties"), SerializeField] private float _minValue = 0f;
        [BoxGroup("Properties"), SerializeField] private float _maxValue = 10f;
        [BoxGroup("Properties"), SerializeField] private float _value = 5f;

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
                ValueText.text = Value.Round(_maxValueFormat).ToString(CultureInfo.InvariantCulture);
            }

            if (ValueImage != null)
            {
                ValueImage.fillAmount = KiMath.CalculatePercentage(Value, _maxValue - _minValue) / 100;
            }
        }
    }
}