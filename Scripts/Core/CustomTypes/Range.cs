using System;
using UnityEngine;

namespace KiUtility
{
    /// <summary>
    /// Структура с минимальным и максимальным значением TValue
    /// </summary>
    /// <typeparam name="TValue">Любое значение типа [int, float, double]</typeparam>
    [Serializable]
    public struct Range<TValue> where TValue : struct
    {
        [SerializeField] private TValue _min;
        [SerializeField] private TValue _max;

        /// <summary>
        /// Минимальное значение
        /// </summary>
        public TValue Min
        {
            get => _min;
            set
            {
                if (typeof(TValue) == typeof(int) ||
                    typeof(TValue) == typeof(float) ||
                    typeof(TValue) == typeof(double))
                {
                    _min = value;
                }
                else
                {
                    throw new ArgumentException("T must be int, float or double");
                }
            }
        }

        /// <summary>
        /// Максимальное значение
        /// </summary>
        public TValue Max
        {
            get => _max;
            set
            {
                if (typeof(TValue) == typeof(int) ||
                    typeof(TValue) == typeof(float) ||
                    typeof(TValue) == typeof(double))
                {
                    _max = value;
                }
                else
                {
                    throw new ArgumentException("T must be int, float or double");
                }
            }
        }

        public Range(TValue min = default, TValue max = default)
        {
            if (typeof(TValue) != typeof(int) ||
                typeof(TValue) != typeof(float) ||
                typeof(TValue) != typeof(double))
            {
                throw new ArgumentException("T must be int, float or double");
            }

            _min = min;
            _max = max;
        }
    }
}