using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using Agava.YandexGames;
using KiUtilities;
using Newtonsoft.Json.Linq;
using PlayerPrefs = UnityEngine.PlayerPrefs;

namespace KiYandexSDK
{
    public static class YandexData
    {
        private static string _json = "{}";
        private static bool _initialized = false;

        private const string Postfix = "";
        private const string Separator = "_";

        /// <summary>
        /// Инициализация YandexData класса
        /// </summary>
        /// <returns>Возвращает, когда инициализация прошла успешно</returns>
        /// <exception cref="Exception">Метод нельзя вызывать > 1 раза</exception>
        public static IEnumerator Initialize()
        {
            if (_initialized)
            {
                throw new Exception("YandexData initialization has already been performed.");
            }
#if UNITY_WEBGL && !UNITY_EDITOR
            PlayerAccount.GetCloudSaveData((data) =>
            {
                _json = data;
                _initialized = true;
            }, Debug.LogWarning);
#else
            _json = PlayerPrefs.GetString("json", "{}");
            _initialized = true;
#endif
            while (true)
            {
                yield return null;
                if (_initialized) yield break;
            }
        }

        /// <summary>
        /// Сохраняет данные в облако яндекс.
        /// </summary>
        /// <param name="key">Ключ для значения</param>
        /// <param name="value">Значение</param>
        /// <param name="onSuccess">Успех сохранения</param>
        /// <param name="onError">Ошибка при сохранении</param>
        public static void Save(string key, JToken value, Action onSuccess = null, Action<string> onError = null)
        {
            if (!_initialized) throw new Exception($"{nameof(YandexData)} not initialized");
            var dictionary = _json.ToDictionary();
            string searchKey = $"{key}{Separator}{value.Type.ToString()[..2]}{Separator}{Postfix}";
            if (dictionary.TryGetValue(searchKey, out JToken _))
            {
                dictionary[searchKey] = value;
            }
            else
            {
                dictionary.Add(searchKey, value);
            }

            _json = dictionary.ToJson();
#if UNITY_WEBGL && !UNITY_EDITOR
            PlayerAccount.SetCloudSaveData(_json, onSuccess, onError);
#else
            PlayerPrefs.SetString("json", _json);
            onSuccess?.Invoke();
#endif
        }

        /// <summary>
        /// Возвращает значение по ключу [key] и по типу [defaultValue]
        /// </summary>
        /// <param name="onSuccess">Успех выгрузки</param>
        /// <param name="key">Значение по которому будет происходить поиск</param>
        /// <param name="defaultValue">Стандартное значение, если не найдет</param>
        public static JToken Load(string key, JToken defaultValue)
        {
            var data = _json.ToDictionary();
            string searchKey = $"{key}{Separator}{defaultValue.Type.ToString()[..2]}{Separator}{Postfix}";
            return data.TryGetValue(searchKey, out JToken value) ? value : defaultValue;
        }
    }
}