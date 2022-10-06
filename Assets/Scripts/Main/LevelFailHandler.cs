using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailHandler : MonoBehaviour
{
    public Button reviveBtn;
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
        if (SceneHandler.Instance.isRevivedOnce)
        {
            reviveBtn.interactable = false;
        }
        else
        {
            reviveBtn.interactable = true;
        }
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

    public void onClickRevive()
    {
        AdsInitializer.Instance.ShowAd(RewardedAdType.REVIVE);
    }
}
