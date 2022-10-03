using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteHandler : MonoBehaviour
{
    public Text levelNumber;
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
        levelNumber.text = "Level " + SceneHandler.Instance.levelHandler.levelNumber.ToString();
    }

    public void onClickHome()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.backToMenu();
        gameObject.SetActive(false);
    }


    public void onClickNext()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.levelHandler.increaseLevelNumber();
        SceneHandler.Instance.restartLevel();
        gameObject.SetActive(false);
    }
}
