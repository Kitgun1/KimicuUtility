using System.Collections;
using UnityEngine;

namespace KimicuUtility
{
    public partial class KiCoroutine
    {
        private Coroutine _routine;

        /// <summary> Start new coroutine. </summary>
        /// <param name="forced"> Forcibly stopping the previous routine if it is already running. </param>
        public void StartRoutine(IEnumerator enumerator, bool forced = false)
        {
            if (_routine != null)
            {
                if (forced) StopRoutine();
                else return;
            }

            _routine = KiCoroutines.StartRoutine(enumerator);
        }

        /// <summary> Stop current coroutine. </summary>
        public void StopRoutine()
        {
            if (_routine == null) return;
            KiCoroutines.StopRoutine(_routine);
        }
    }
}