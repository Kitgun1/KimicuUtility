using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace KiUtilities
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

        public static UnityEngine.Coroutine StartRoutine(IEnumerator enumerator)
        {
            return Instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine([NotNull] UnityEngine.Coroutine routine)
        {
            Instance.StopCoroutine(routine);
        }
    }
}