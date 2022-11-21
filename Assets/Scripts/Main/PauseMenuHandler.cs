using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickRestart()
    {
        Time.timeScale = 2;
        SceneHandler.Instance.cam.GetComponent<CameraFollow>().StopHurdleCoroutines();
        SceneHandler.Instance.isPause = false;
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.restartLevel();
        this.gameObject.SetActive(false);
        //Time.timeScale = 1;
    }

    public void onClickHome()
    {
        Time.timeScale = 2;
        SceneHandler.Instance.cam.GetComponent<CameraFollow>().StopHurdleCoroutines();
        SceneHandler.Instance.isPause = false;
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.backToMenu();
        this.gameObject.SetActive(false);
        //Time.timeScale = 1;
    }

    public void onClickResume()
    {
        Time.timeScale = 2;
        SceneHandler.Instance.isPause = false;
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        this.gameObject.SetActive(false);
        MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
        //Time.timeScale = 1;
    }
}
