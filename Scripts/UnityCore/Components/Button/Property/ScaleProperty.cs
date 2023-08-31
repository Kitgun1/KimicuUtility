using System;
using UnityEngine;

namespace KiUtility
{
    [Serializable]
    public class ScaleProperty
    {
        public RectTransform TargetGraphic;
        [Min(0)] public float NormalScale = 1f;
        [Min(0)] public float ModiferScale = 1.1f;
        [Min(0)] public float DurationLerpScale = 0.1f;
    }
}