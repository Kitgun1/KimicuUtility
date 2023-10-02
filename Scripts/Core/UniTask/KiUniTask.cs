using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace KimicuUtility
{
    public static class KiUniTask
    {
        #region Delay

        /// <summary>
        /// Запускает задержку
        /// </summary>
        /// <param name="seconds">длительность задержки</param>
        /// <param name="onEnd">вызывается при завршении всех итераций</param>
        public static async UniTask Delay(float seconds, Action onEnd)
        {
            await UniTask.Delay((int)(seconds * 1000));
            onEnd?.Invoke();
        }

        /// <summary>
        /// Запускает цикл с определенным количеством итерации
        /// </summary>
        /// <param name="seconds">длительность итерации</param>
        /// <param name="repetitionsAmount">количество итераций</param>
        /// <param name="onNext">вызывается при окончании итерации</param>
        /// <param name="onEnd">вызывается при завршении всех итераций</param>
        public static async UniTask RecurringDelay(float seconds, uint repetitionsAmount = 1,
            Action<uint> onNext = null, Action onEnd = null)
        {
            while (repetitionsAmount > 0)
            {
                await UniTask.Delay((int)(seconds * 1000));
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
        public static async UniTask CyclicDelay(float seconds, Action<float> onUpdate, Action onEnd = null)
        {
            float time = 0;
            while (time <= seconds)
            {
                await UniTask.Delay((int)(Time.deltaTime * 1000));
                time += Time.deltaTime;
                onUpdate?.Invoke(time / seconds);
            }

            onEnd?.Invoke();
        }

        #endregion
    }
}