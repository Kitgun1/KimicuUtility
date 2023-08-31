using System.Collections;
using UnityEngine;

namespace KiUtility
{
    public partial class KiCoroutine
    {
        private Coroutine _routine;

        /// <summary>Запускает IEnumerator.</summary>
        /// <param name="forced">Принудительная остановка предыдущей рутины, если она уже запущена.</param>
        public void StartRoutine(IEnumerator enumerator, bool forced = false)
        {
            if (_routine != null)
            {
                if (forced) StopRoutine();
                else return;
            }

            _routine = KiCoroutines.StartRoutine(enumerator);
        }

        /// <summary> Остановка существующей рутины. </summary>
        public void StopRoutine()
        {
            if (_routine == null) return;
            KiCoroutines.StopRoutine(_routine);
        }
    }
}