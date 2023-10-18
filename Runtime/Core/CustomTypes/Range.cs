using System;
using UnityEngine;

namespace KimicuUtility
{
    [Serializable]
    public struct Range<TValue> where TValue : IComparable<TValue>, IFormattable
    {
        [SerializeField] private TValue m_Min;
        [SerializeField] private TValue m_Max;

        public TValue Min
        {
            get => m_Min;
            set => m_Min = value;
        }

        public TValue Max
        {
            get => m_Max;
            set => m_Max = value;
        }

        public Range(TValue min = default, TValue max = default)
        {
            m_Min = min;
            m_Max = max;
        }
    }
}