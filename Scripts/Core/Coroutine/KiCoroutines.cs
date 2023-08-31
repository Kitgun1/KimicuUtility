using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace KiUtility
{
    public sealed class KiCoroutines : MonoBehaviour
    {
        private static KiCoroutines Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new("[COROUTINE MANAGER]");
                    _instance = go.AddComponent<KiCoroutines>();
                    DontDestroyOnLoad(go);
                }

                return _instance;
            }
        }

        private static KiCoroutines _instance;

        internal static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return Instance.StartCoroutine(enumerator);
        }

        internal static void StopRoutine([NotNull] Coroutine routine)
        {
            Instance.StopCoroutine(routine);
        }
    }
}