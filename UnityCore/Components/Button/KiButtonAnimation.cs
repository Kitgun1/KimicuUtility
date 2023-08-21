using System;
using NaughtyAttributes;
using UnityEngine;

namespace KiUtilities
{
    [RequireComponent(typeof(KiButton))]
    [DisallowMultipleComponent]
    public sealed class KiButtonAnimation : MonoBehaviour
    {
        public bool ScaleEnabled;
        [EnableIf(nameof(ScaleEnabled))] public ScaleProperty ScaleProperties = new();

        [Space(10)] public bool TurnEnabled;
        [EnableIf(nameof(TurnEnabled))] public TurnProperty TurnProperties = new();

        [Space(10)] public bool AlphaEnabled;
        [EnableIf(nameof(AlphaEnabled))] public AlphaProperty AlphaProperties = new();

        #region Scale

        private readonly KiCoroutine _routineScale = new();
        private Vector3 _currentScale;

        public void ScaleAnimation(bool invert = false)
        {
            if (!ScaleEnabled) return;
            _currentScale = ScaleProperties.TargetGraphic.localScale;
            _routineScale.StartRoutine(invert
                ? KiCoroutine.CyclicDelay(ScaleProperties.DurationLerpScale, UpdateAnimationScale)
                : KiCoroutine.CyclicDelay(ScaleProperties.DurationLerpScale, UpdateAnimationScaleInvert), true);
        }

        private void UpdateAnimationScaleInvert(float t)
        {
            ScaleProperties.TargetGraphic.localScale = Vector3.Lerp(_currentScale, Vector3.one * ScaleProperties.NormalScale, t);
        }

        private void UpdateAnimationScale(float t)
        {
            ScaleProperties.TargetGraphic.localScale = Vector3.Lerp(_currentScale, Vector3.one * ScaleProperties.ModiferScale, t);
        }

        #endregion

        #region Turn

        private readonly KiCoroutine _routineTurn = new();
        private Vector3 _angle;

        public void TurnAnimation(bool invert = false)
        {
            if (!TurnEnabled) return;
            _angle = TurnProperties.TargetGraphic.rotation.eulerAngles;
            _routineTurn.StartRoutine(invert
                ? KiCoroutine.CyclicDelay(TurnProperties.DurationLerpTurn, UpdateAnimationTurn)
                : KiCoroutine.CyclicDelay(TurnProperties.DurationLerpTurn, UpdateAnimationTurnInvert), true);
        }

        private void UpdateAnimationTurn(float t)
        {
            TurnProperties.TargetGraphic.rotation =
                Quaternion.Euler(Vector3.Lerp(_angle, Vector3.forward * TurnProperties.ModiferTurn, t));
        }

        private void UpdateAnimationTurnInvert(float t)
        {
            TurnProperties.TargetGraphic.rotation =
                Quaternion.Euler(Vector3.Lerp(_angle, Vector3.forward * TurnProperties.NormalTurn, t));
        }

        #endregion

        #region Alpha

        private readonly KiCoroutine _routineAlpha = new();
        private float _currentAlpha;

        public void AlphaAnimation(bool invert = false)
        {
            if (!AlphaEnabled) return;
            _currentAlpha = AlphaProperties.TargetGraphic.alpha;
            _routineAlpha.StartRoutine(invert
                ? KiCoroutine.CyclicDelay(AlphaProperties.DurationLerpAlpha, UpdateAnimationAlpha)
                : KiCoroutine.CyclicDelay(AlphaProperties.DurationLerpAlpha, UpdateAnimationAlphaInvert), true);
        }

        private void UpdateAnimationAlpha(float t)
        {
            AlphaProperties.TargetGraphic.alpha = Mathf.Lerp(_currentAlpha, AlphaProperties.ModiferAlpha, t);
        }

        private void UpdateAnimationAlphaInvert(float t)
        {
            AlphaProperties.TargetGraphic.alpha = Mathf.Lerp(_currentAlpha, AlphaProperties.NormalAlpha, t);
        }

        #endregion

        private void Start()
        {
            if (ScaleEnabled) ScaleProperties.TargetGraphic.localScale = Vector3.one * ScaleProperties.NormalScale;
            if (TurnEnabled) TurnProperties.TargetGraphic.rotation = Quaternion.Euler(Vector3.forward * TurnProperties.NormalTurn);
            if (AlphaEnabled) AlphaProperties.TargetGraphic.alpha = AlphaProperties.NormalAlpha;
        }

        private void OnDestroy()
        {
            _routineScale.StopRoutine();
            _routineTurn.StopRoutine();
            _routineAlpha.StopRoutine();
        }
    }
}