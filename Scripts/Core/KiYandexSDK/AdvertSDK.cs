using System;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Agava.YandexGames;
#endif
using KiUtility;
using UnityEngine;

namespace KiYandexSDK
{
    public static class AdvertSDK
    {
        private static bool _advertOff;
        private static bool _advertAvailable = true;

        private const int DelayAd = 30;
        public static string AdvertOffKey = "ADVERT_OFF";

        public static void AdvertInitialize()
        {
            _advertOff = (bool)YandexData.Load(AdvertOffKey, false);
        }

        /// <summary> Отключает рекламу в игр и сохраняет через `YandexData` используя поле `AdvertOffKey`.</summary>
        public static void AdvertOff()
        {
            _advertOff = true;
            YandexData.Save(AdvertOffKey, _advertOff);
        }

        /// <summary> Показывет рекламу, если не выключена. </summary>
        /// <param name="onOpen"></param>
        /// <param name="onRewarded">Действие, выполняемое после просмотра.</param>
        /// <param name="onClose">Действие, выполняемое после закрытия рекламы.</param>
        /// <param name="onError">Действие, выполняемое при Ошибке.</param>
        public static void RewardAd(Action onOpen = null, Action onRewarded = null, Action onClose = null,
            Action<string> onError = null)
        {
            if (_advertOff)
            {
                onRewarded?.Invoke();
                WebProperty.AdvertOpened = false;
                return;
            }

#if UNITY_WEBGL && !UNITY_EDITOR
            VideoAd.Show(()=>
            {
                onOpen?.Invoke();
                WebProperty.AdvertOpened = true;
            }, ()=>
            {
                onRewarded?.Invoke();
                WebProperty.AdvertOpened = false;
            }, ()=>
            {
                onClose?.Invoke();
                WebProperty.AdvertOpened = false;
            },error =>
            {
                onError?.Invoke(error);
                WebProperty.AdvertOpened = false;
            });
#else
            onRewarded?.Invoke();
            WebProperty.AdvertOpened = false;
#endif
        }

        /// <summary> Включение или выключение Sticky баннера </summary>
        /// <param name="value">Включить / Выключить</param>
        public static void StickyAdActive(bool value)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (value) StickyAd.Show();
            else StickyAd.Hide();
#else
            Debug.Log($"StickyAd is {value}");
#endif
        }

        /// <summary> Показ Interstitial рекламы. </summary>
        /// <param name="onOpen"></param>
        /// <param name="onClose">Действие, выполняемое после закрытия рекламы.</param>
        /// <param name="onError">Действие, выполняемое при Ошибке.</param>
        /// <param name="onOffline"></param>
        public static void InterstitialAd(Action onOpen = null, Action<bool> onClose = null,
            Action<string> onError = null, Action onOffline = null)
        {
            if (_advertAvailable == false) return;
            if (_advertOff)
            {
                onClose?.Invoke(true);
            }
            else
            {
#if UNITY_WEBGL && !UNITY_EDITOR
                Agava.YandexGames.InterstitialAd.Show(() =>
                {
                    onOpen?.Invoke();
                    WebProperty.AdvertOpened = true;
                }, closeCallback =>
                {
                    onClose?.Invoke(closeCallback);
                    WebProperty.AdvertOpened = false;
                }, (error) =>
                {
                    onError?.Invoke(error);
                    WebProperty.AdvertOpened = false;
                }, () =>
                {
                    onOffline?.Invoke();
                    WebProperty.AdvertOpened = false;
                });
#else
                onClose?.Invoke(true);
                Debug.Log($"InterstitialAd Show");
#endif
            }

            _advertAvailable = false;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            KiUniTask.Delay(DelayAd, () => _advertAvailable = true);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }
    }
}