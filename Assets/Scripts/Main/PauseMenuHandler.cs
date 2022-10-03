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
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.restartLevel();
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void onClickHome()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.backToMenu();
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void onClickResume()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
