using System;
using UnityEngine;

namespace KiUtilities
{
    [Serializable]
    public struct ObjectChance<T>
    {
        public T Object;

        [Range(0, 100), SerializeField] private float _chance;

        public float Chance
        {
            get => _chance;
            set => _chance = Mathf.Clamp(value, 0, 100);
        }

        public ObjectChance(T obj, float chance) : this()
        {
            Object = obj;
            Chance = chance;
        }
    }
}