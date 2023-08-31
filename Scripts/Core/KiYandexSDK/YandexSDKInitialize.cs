using System.Collections;
#if UNITY_WEBGL && !UNITY_EDITOR
using Agava.YandexGames;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KiYandexSDK
{
    public sealed class YandexSDKInitialize : MonoBehaviour
    {
        [SerializeField] private float _initializeDelay = 0.2f; 

        private IEnumerator Start()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            yield return YandexGamesSdk.Initialize(); // Инициализация Agava SDK
            yield return YandexData.Initialize(); // Инициализация сохранений
            AdvertSDK.AdvertInitialize();  // Инициализация рекламы
            WebGL.Initialize(null);  // Инициализация WebGL
            InitializeSuccess();
            yield break;
#else
            yield return new WaitForSecondsRealtime(_initializeDelay);
#endif
            InitializeSuccess();
        }


        private static void InitializeSuccess()
        {
            LoadNextScene();
        }

        private static void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}