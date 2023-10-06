using System;
using System.Collections;
using UnityEngine;

namespace KimicuUtility
{
    public partial class KiCoroutine
    {
        /// <summary>
        /// Задерживает выполнение кода на заданное количество секунд и затем вызывает указанный делегат.
        /// </summary>
        /// <param name="seconds">Количество секунд задержки.</param>
        /// <param name="onEnd">Делегат, который будет вызван после задержки.</param>
        public static IEnumerator Delay(float seconds, Action onEnd)
        {
            yield return new WaitForSeconds(seconds);
            onEnd?.Invoke();
        }

        /// <summary> Задержка с количеством итераций. </summary>
        /// <param name="seconds"> Количество секунд между каждым повторением заданной операции. </param>
        /// <param name="repetitionsAmount"> количество повторений заданной операции. По умолчанию равно 1. </param>
        /// <param name="onNext">
        /// Делегат, который вызывается после каждого повторения заданной операции.
        /// Он принимает один параметр типа uint, который указывает, сколько повторений осталось.
        /// </param>
        /// <param name="onEnd">Делегат, который вызывается после завершения всех повторений заданной операции. </param>
        public static IEnumerator RecurringDelay(float seconds, uint repetitionsAmount = 1, Action<uint> onNext = null,
            Action onEnd = null)
        {
            uint currentRepetitionsAmount = repetitionsAmount;
            while (currentRepetitionsAmount > 0)
            {
                yield return new WaitForSeconds(seconds / currentRepetitionsAmount);
                currentRepetitionsAmount--;
                onNext?.Invoke(currentRepetitionsAmount);
            }

            onEnd?.Invoke();
        }

        /// <summary>
        /// Задержка с циклом.
        /// </summary>
        /// <param name="seconds">Продолжительность задержки в секундах.</param>
        /// <param name="onUpdate">Действие, выполняемое при обновлении кадра. Передавая число в диапазоне [0, 1]</param>
        /// <param name="onEnd">Действие, выполняемое по завершении задержки.</param>
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