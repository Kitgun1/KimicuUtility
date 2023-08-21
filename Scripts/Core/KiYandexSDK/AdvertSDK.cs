using System;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Agava.YandexGames;
#endif
using KiUtilities;
using UnityEngine;

namespace KiYandexSDK
{
    public static class AdvertSDK
    {
        private static bool _advertOff;
        private static bool _advertAvailable = true;

        private const int DelayAd = 30;

        public static void AdvertOff()
        {
            _advertOff = true;
        }

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

        public static void StickyAdActive(bool value)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (value) StickyAd.Show();
            else StickyAd.Hide();
#else
            Debug.Log($"StickyAd is {value}");
#endif
        }

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