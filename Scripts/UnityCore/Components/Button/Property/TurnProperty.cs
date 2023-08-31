using System;
using UnityEngine;

namespace KiUtility
{
    [Serializable]
    public class TurnProperty
    {
        public RectTransform TargetGraphic;
        public float NormalTurn = 0f;
        public float ModiferTurn = 10f;
        [Min(0)] public float DurationLerpTurn = 0.2f;
    }
}