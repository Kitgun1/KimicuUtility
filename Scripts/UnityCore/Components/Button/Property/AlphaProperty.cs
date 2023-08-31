using System;
using UnityEngine;

namespace KiUtility
{
    [Serializable]
    public class AlphaProperty
    {
        public CanvasGroup TargetGraphic;
        [Range(0f, 1f)] public float NormalAlpha = 1f;
        [Range(0f, 1f)] public float ModiferAlpha = 1f;
        [Min(0)] public float DurationLerpAlpha = 0.2f;
    }
}