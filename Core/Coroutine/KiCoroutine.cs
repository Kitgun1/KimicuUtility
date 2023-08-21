using System.Collections;
using UnityEngine;

namespace KiUtilities
{
    public partial class KiCoroutine
    {
        private Coroutine _routine;

        public void StartRoutine(IEnumerator enumerator, bool forced = false)
        {
            if (_routine != null)
            {
                if (forced) StopRoutine();
                else return;
            }

            _routine = KiCoroutines.StartRoutine(enumerator);
        }

        public void StopRoutine()
        {
            if (_routine == null) return;
            KiCoroutines.StopRoutine(_routine);
        }
    }
}