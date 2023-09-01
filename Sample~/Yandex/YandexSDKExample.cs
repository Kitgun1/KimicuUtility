using System;
using KiUtility;
using KiYandexSDK;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KimicuUtility.Sample
{
    public class YandexSDKExample : MonoBehaviour
    {
        [Space(5), Header(" AdvertSDK ")] [SerializeField]
        private Button _interstitialButton;

        [SerializeField] private Button _rewardButton;
        [SerializeField] private Button _stickyOffButton;
        [SerializeField] private Button _stickyOnButton;
        [SerializeField] private Button _removeAdsButton;

        [Space(5), Header(" YandexData ")] [SerializeField]
        private TMP_InputField _inputKey;

        [SerializeField] private TMP_InputField _inputValue;
        [SerializeField] private Image _valueState;
        [SerializeField] private Button _saveValueButton;
        [SerializeField] private Button _loadValueButton;

        private void OnEnable()
        {
            // Advert
            _interstitialButton.AddListener(InterstitialAdShow);
            _rewardButton.AddListener(RewardShow);
            _stickyOffButton.AddListener(StickyShow);
            _stickyOnButton.AddListener(StickyHide);
            _removeAdsButton.AddListener(RemoveAds);

            // Save
            _saveValueButton.AddListener(SaveValue);
            _loadValueButton.AddListener(LoadValue);
        }

        private void OnDisable()
        {
            // Advert
            _interstitialButton.RemoveListener(InterstitialAdShow);
            _rewardButton.RemoveListener(RewardShow);
            _stickyOffButton.RemoveListener(StickyShow);
            _stickyOnButton.RemoveListener(StickyHide);
            _removeAdsButton.RemoveListener(RemoveAds);

            // Save
            _saveValueButton.RemoveListener(SaveValue);
            _loadValueButton.RemoveListener(LoadValue);
        }

        #region Advert

        private static void InterstitialAdShow()
        {
            AdvertSDK.InterstitialAd(
                () => Debug.Log("open"),
                (wasShow) => Debug.Log($"close {wasShow}"),
                Debug.Log,
                () => Debug.Log("onOffline")
            );
        }

        private static void RewardShow()
        {
            AdvertSDK.RewardAd(
                () => Debug.Log("open"),
                () => Debug.Log("rewarded"),
                () => Debug.Log("close"),
                Debug.Log
            );
        }

        private static void StickyShow()
        {
            AdvertSDK.StickyAdActive(true);
        }

        private static void StickyHide()
        {
            AdvertSDK.StickyAdActive(false);
        }

        private static void RemoveAds()
        {
            AdvertSDK.AdvertOff();
        }

        #endregion

        #region YandexData

        private void SaveValue()
        {
            _valueState.color = new Color(0.36f, 0.53f, 1f);
            YandexData.Save(_inputKey.text, _inputValue.text,
                () =>
                {
                    Debug.Log($"success save: {_inputKey.text}:{_inputValue.text}");
                    _valueState.color = new Color(0.44f, 0.96f, 0.27f);
                },
                Debug.Log);
        }

        private void LoadValue()
        {
            // YandexData.Load может обрабатывать и другие типы, например: int, float, string, list, и прочие
            _inputValue.text = (string)YandexData.Load(_inputKey.text, "default value");
            _valueState.color = new Color(0.96f, 0.27f, 0.27f);
        }

        #endregion
    }
}