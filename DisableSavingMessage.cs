using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace DisableSavingMessage
{
    [BepInPlugin("lucasxk.erenshor.disablesavingmessage", "Disable Saving Message", "1.0.0")]
    public class DisableSavingMessage : BaseUnityPlugin
    {
        private void Awake()
        {            
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Menu" || scene.name == "LoadScene") return;
            StartCoroutine(disable("UI/SavingPleaseWait/Text (TMP)"));
        }

        private IEnumerator disable(string path)
        {            
            GameObject obj = null;
            while (obj == null)
            {
                yield return null;
                obj = GameObject.Find(path);
            }
            
            obj.SetActive(false);
        }
    }
}