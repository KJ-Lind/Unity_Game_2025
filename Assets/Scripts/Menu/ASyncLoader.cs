using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ASyncLoader : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject loadingScreen;

    [Header("Slider")]
    [SerializeField] private Slider lodingBar;


    public void LoadLevelButton(int sceneIndex)
    {
        menu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(sceneIndex));
    }

    IEnumerator LoadLevelASync(int sceneIndex)
    {
        AsyncOperation OperationLoad = SceneManager.LoadSceneAsync(sceneIndex);

        while (!OperationLoad.isDone)
        {
            float progressValue = Mathf.Clamp01(OperationLoad.progress / 0.9f);
            lodingBar.value = progressValue;
            yield return null;
        }
    }

}
