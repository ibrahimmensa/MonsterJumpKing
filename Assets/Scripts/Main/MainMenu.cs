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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickPlay()
    {
        SceneHandler.Instance.startLevel();
        MenuHandler.Instance.switchMenu(MenuStates.GAMEPLAY);
    }

    public void onClickSettings()
    {
        MenuHandler.Instance.switchMenu(MenuStates.SETTINGS);
    }

    public void onClickShop()
    {
        MenuHandler.Instance.switchMenu(MenuStates.SHOP);
    }

    public void onClickNoAds()
    { }

    public void onClickRewards()
    { }

    public void onClickFreeCoins()
    { }

    public void onClickMoreCoins()
    { }

    public void onClickMoreGems()
    { }
}
