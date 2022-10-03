using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        SoundManager.Instance.bg.Stop();
    }

    public void onClickRestart()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.restartLevel();
        gameObject.SetActive(false);
    }

    public void onClickHome()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.backToMenu();
        gameObject.SetActive(false);
    }
}
