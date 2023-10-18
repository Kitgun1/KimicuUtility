using System;
using UnityEngine;

namespace KimicuUtility
{
    [Serializable]
    public struct ObjectChance<T>
    {
        public T Object;

        [SerializeField] private float m_Chance;

        public float Chance
        {
            get => m_Chance;
            set => m_Chance = Mathf.Clamp(value, 0, 100);
        }

        public ObjectChance(T obj, float chance) : this()
        {
            Object = obj;
            Chance = chance;
        }
    }
}