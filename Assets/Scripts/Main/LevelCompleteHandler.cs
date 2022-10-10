using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteHandler : MonoBehaviour
{
    public Text levelNumber;
    public Text coinText;
    public Text gemText;
    public int totalCoins;
    public int totalGems;
    public Button rewardBtn;
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
        totalCoins = (SceneHandler.Instance.spawnedPlayer.GetComponent<PlayerController>().coinsCollected + 100);
        coinText.text = totalCoins.ToString();
        gemText.text = "1";
        totalGems = 1;
        if (SceneHandler.Instance.gotDoubleReward)
        {
            rewardBtn.interactable = false;
        }
        else
        {
            rewardBtn.interactable = true;
        }
        
    }

    public void onClickHome()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.backToMenu();
        gameObject.SetActive(false);
        AdsInitializer.Instance.ShowAdInterstitial();
        saveReward();
    }


    public void onClickNext()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.levelHandler.increaseLevelNumber();
        SceneHandler.Instance.restartLevel();
        gameObject.SetActive(false);
        AdsInitializer.Instance.ShowAdInterstitial();
        saveReward();
    }

    public void OnClickDoubleReward()
    {
        AdsInitializer.Instance.ShowAd(RewardedAdType.DOUBLEREWARD);
    }

    public void saveReward()
    {
        //AdsInitializer.Instance.ShowAdInterstitial();
        //GoogleAdMobController.Instance.ShowInterstitialAd();
        PlayerPrefs.SetInt("Coins", totalCoins);
        PlayerPrefs.SetInt("Gems", totalGems);
        SceneHandler.Instance.Lives = 3;
    }

    public void doubleRewardResponse()
    {
        rewardBtn.interactable = false;
        totalCoins *= 2;
        totalGems *= 2;
        levelNumber.text = "Level " + SceneHandler.Instance.levelHandler.levelNumber.ToString();
        coinText.text = totalCoins.ToString();
        gemText.text = totalGems.ToString();
    }
}
