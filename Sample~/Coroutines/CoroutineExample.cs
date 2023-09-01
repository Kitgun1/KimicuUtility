using KiUtility;
using UnityEngine;

namespace KimicuUtility.Sample
{
    public class CoroutineExample : MonoBehaviour
    {
        [SerializeField] private bool _forced = false;
        private readonly KiCoroutine _routine = new KiCoroutine();

        public void Delay()
        {
            Debug.Log(nameof(Delay));
            _routine.StartRoutine(KiCoroutine.Delay(2, () => Debug.Log("end")), _forced);
        }

        public void CyclicDelay()
        {
            Debug.Log(nameof(CyclicDelay));
            _routine.StartRoutine(KiCoroutine.CyclicDelay(5,
                (t) => Debug.Log($"tick {t}"),
                () => Debug.Log("end")), _forced);
        }

        public void RecurringDelay()
        {
            Debug.Log(nameof(RecurringDelay));
            _routine.StartRoutine(KiCoroutine.RecurringDelay(1, 5,
                (t) => Debug.Log($"tick {t}"),
                () => Debug.Log("end")), _forced);
        }

        public void StopRoutine()
        {
            _routine.StopRoutine();
            Debug.Log("stop");
        }
    }
}