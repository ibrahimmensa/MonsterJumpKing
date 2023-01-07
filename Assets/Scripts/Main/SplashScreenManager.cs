using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenManager : Singleton<SplashScreenManager>
{
    public Slider loadingBar;
    AsyncOperation sceneAO;

    public bool canLoadNextScene = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loading());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator loading()
    {
        while (loadingBar.value < 9)
        {
            loadingBar.value = loadingBar.value + 0.25f;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        while (!canLoadNextScene)
        {
            yield return new WaitForSeconds(0.1f);
        }
        float previousProgress = 0f;
        sceneAO = SceneManager.LoadSceneAsync(1);

        // disable scene activation while loading to prevent auto load
        sceneAO.allowSceneActivation = false;

        while (!sceneAO.isDone)
        {
            loadingBar.value += (sceneAO.progress-previousProgress);
            previousProgress = sceneAO.progress;
            if (sceneAO.progress >= 0.9f)
            {
                loadingBar.value = 10f;
                sceneAO.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
