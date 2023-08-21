#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace KiUtilities.Editor
{
    public class KiPanel : EditorWindow
    {
        [MenuItem("Utilities/KiPanel")]
        private static void ShowWindow()
        {
            KiPanel window = GetWindow<KiPanel>();
            window.titleContent = new GUIContent("Kimicu Panel");
            window.Show();
        }

        private void CreateGUI()
        {
        }

        private void OnGUI()
        {
            try
            {
                if (GUILayout.Button("Restart Scene"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            catch (Exception e)
            {
                Debug.Log($"{e.Message}");
            }
        }
    }
}
#endif