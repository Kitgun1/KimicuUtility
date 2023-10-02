using System;
using UnityEngine;

namespace KimicuUtility
{
    /// <summary>
    /// Структура с объектом и его шансом в пределах [0, 100]
    /// </summary>
    [Serializable]
    public struct ObjectChance<T>
    {
        public T Object;

        [Range(0, 100), SerializeField] private float _chance;

        /// <summary>
        /// Шанс объекта в пределах [0, 100]
        /// </summary>
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