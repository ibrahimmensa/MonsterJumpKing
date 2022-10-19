using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text coinsText;
    public Text gemsText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start called");
        coinsText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        gemsText.text = PlayerPrefs.GetInt("Gems", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Debug.Log("enable called");
        coinsText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        gemsText.text = PlayerPrefs.GetInt("Gems", 0).ToString();
        Invoke("updateStats", 2f);
        GoogleAdsManager.Instance.RequestBanner();
    }

    public void onClickPlay()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        SceneHandler.Instance.startLevel();
        MenuHandler.Instance.switchMenu(MenuStates.GAMEPLAY);
        GoogleAdsManager.Instance.destroyBanner();
    }

    public void onClickSettings()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        MenuHandler.Instance.switchMenu(MenuStates.SETTINGS);
    }

    public void onClickShop()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        MenuHandler.Instance.switchMenu(MenuStates.SHOP);
    }

    public void onClickNoAds()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
    }

    public void onClickRewards()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
    }

    public void onClickFreeCoins()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        AdsInitializer.Instance.ShowAd(RewardedAdType.FREECOINS);
    }

    public void onClickMoreCoins()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
    }

    public void onClickMoreGems()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
    }

    public void onClickCharacterSelection()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        MenuHandler.Instance.switchMenu(MenuStates.CHARACTERSELECTION);
    }

    public void updateStats()
    {
        coinsText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        gemsText.text = PlayerPrefs.GetInt("Gems", 0).ToString();
    }
}
