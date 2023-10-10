using System.Collections;
using UnityEngine;

namespace KimicuUtility
{
    public partial class KiCoroutine
    {
        private Coroutine _routine;

        /// <summary> Start new coroutine. </summary>
        /// <param name="forced"> Forcibly stopping the previous routine if it is already running. </param>
        public bool StartRoutine(IEnumerator enumerator, bool forced = false)
        {
            if (_routine != null)
            {
                if (forced) StopRoutine();
                else return false;
            }

            _routine = KiCoroutines.StartRoutine(enumerator);
            return true;
        }

        /// <summary> Stop current coroutine. </summary>
        public void StopRoutine()
        {
            if (_routine == null) return;
            KiCoroutines.StopRoutine(_routine);
            _routine = null;

            // hi by artem
        }
    }
}