using System;
using System.Collections;
using UnityEngine;

namespace KiUtilities
{
    public partial class KiCoroutine
    {
        /// <summary>
        /// Запускает задержку
        /// </summary>
        /// <param name="seconds">длительность задержки</param>
        /// <param name="onEnd">вызывается при завршении всех итераций</param>
        public static IEnumerator Delay(float seconds, Action onEnd)
        {
            yield return new WaitForSeconds(seconds);
            onEnd?.Invoke();
        }

        /// <summary>
        /// Запускает цикл с определенным количеством итерации
        /// </summary>
        /// <param name="seconds">длительность всех итераций</param>
        /// <param name="repetitionsAmount">количество итераций</param>
        /// <param name="onNext">вызывается при окончании итерации</param>
        /// <param name="onEnd">вызывается при завршении всех итераций</param>
        public static IEnumerator RecurringDelay(float seconds, uint repetitionsAmount = 1, Action<uint> onNext = null,
            Action onEnd = null)
        {
            while (repetitionsAmount > 0)
            {
                yield return new WaitForSeconds(seconds / repetitionsAmount);
                repetitionsAmount--;
                onNext?.Invoke(repetitionsAmount);
            }

            onEnd?.Invoke();
        }

        /// <summary>
        /// Запускает цикл
        /// </summary>
        /// <param name="seconds">длительность цикла</param>
        /// <param name="onUpdate">вызывается каждый кадр</param>
        /// <param name="onEnd">вызывается по завершению цикла</param>
        public static IEnumerator CyclicDelay(float seconds, Action<float> onUpdate, Action onEnd = null)
        {
            float time = 0;
            while (time <= seconds)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                time += Time.deltaTime;
                onUpdate?.Invoke(time / seconds);
            }

            onEnd?.Invoke();
        }
    }
}