using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace KimicuUtility
{
    public static class StringExtension
    {
        public static IEnumerator GetPicture(this string url, Action<Texture2D> onSuccessCallback,
            Action<string> onError = null)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();
            if (www.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                onError?.Invoke(www.error);
            }
            else
            {
                Texture2D texture2D = DownloadHandlerTexture.GetContent(www);
                onSuccessCallback?.Invoke(texture2D);
            }
        }
    }
}