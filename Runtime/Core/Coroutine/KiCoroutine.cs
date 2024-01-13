using System.Collections;
using UnityEngine;

namespace KimicuUtility
{
    public partial class KiCoroutine
    {
        private Coroutine _routine;

        /// <summary> Start new coroutine. </summary>
        public void StartRoutine(IEnumerator enumerator)
        {
            StopRoutine();
            _routine = KiCoroutines.StartRoutine(enumerator);
        }

        /// <summary> Try start new coroutine. </summary>
        public bool TryStartRoutine(IEnumerator enumerator)
        {
            if (_routine != null) return false;
            _routine = KiCoroutines.StartRoutine(enumerator);
            return true;
        }

        /// <summary> Stop current coroutine. </summary>
        public void StopRoutine()
        {
            if (_routine == null) return;
            KiCoroutines.StopRoutine(_routine);
            _routine = null;
        }
    }
}
