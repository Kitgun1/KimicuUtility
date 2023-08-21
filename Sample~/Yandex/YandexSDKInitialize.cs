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
#if UNITY_EDITOR
        private const float InitializeDelay = 0.2f;
#endif

        private IEnumerator Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            yield return YandexGamesSdk.Initialize();
            yield return YandexData.Initialize();
            YandexSDK.Initialize();
            InitializeSuccess();
#endif
#if UNITY_EDITOR
            yield return new WaitForSecondsRealtime(InitializeDelay);
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