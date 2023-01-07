using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class InappsManager : Singleton<InappsManager>
{
    public GameObject removeAdsBuyButton;
    public GameObject removeAdsPurchasedButton;    
    public GameObject buyAllPlayersBuyButton;
    public GameObject buyAllPlayersPurchasedButton;    
    public GameObject superOfferBuyButton;
    public GameObject superOfferPurchasedButton;
    public GameObject removeAdsButtonOnMainMenu;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < InappListener.instance.nonConsumableItemsUnlocked.Length; i++)
        {
            if(InappListener.instance.nonConsumableItemsUnlocked[i])
                CheckProductPurchased(i);
        }
        //PlayerPrefs.DeleteKey("5"); //for testing purpose
        //PlayerPrefs.DeleteKey("PlayerRewarded"); //for testing purpose
        //PlayerPrefs.DeleteKey("LastTimeClicked"); //for testing purpose
    }

    public void CheckProductPurchased(int id)
    {
        if (id == 0)
        {
            RemoveAdsPurchased();
            DisableRemoveAdBuyButton();
        }
        else if (id == 1)
        {
            BuyAllPlayersOfferPurchased();
            DisableBuyAllPlayersBuyButton();
        }
        else if (id == 2)
        {
            SuperOfferPurchased();
            DisableSuperOfferBuyButton();
        }
    }

    public void CoinsPurchased(int coins)
    {
        Debug.Log("Purchase Complete.........");
        int totalCoins;
        totalCoins = PlayerPrefs.GetInt("Coins", 0)+coins;
        PlayerPrefs.SetInt("Coins", totalCoins);
        MenuHandler.Instance.mainMenu.updateStats();
    }

    public void GemsPurchased(int gems)
    {
        Debug.Log("Purchase Complete.........");
        int totalGems;
        totalGems = PlayerPrefs.GetInt("Gems", 0) + gems;
        PlayerPrefs.SetInt("Gems", totalGems);
        MenuHandler.Instance.mainMenu.updateStats();
    }

    public void RemoveAdsPurchased()
    {
        Debug.Log("Purchase Complete.........");
        PlayerPrefs.SetInt("AdsRemoved", 1);
        GoogleAdsManager.Instance.destroyAllBanners();
        removeAdsButtonOnMainMenu.GetComponent<Button>().interactable = false;
        Invoke("DisableRemoveAdBuyButton", 1);
    }

    void DisableRemoveAdBuyButton()
    {
        removeAdsBuyButton.SetActive(false);
        removeAdsPurchasedButton.SetActive(true);
    }

    public void BuyAllPlayersOfferPurchased()
    {
        Debug.Log("Purchase Complete.........");
        PlayerPrefs.SetInt("BuyAllPlayers", 1);
        PlayerPrefs.SetString("1", "true");
        PlayerPrefs.SetString("2", "true");
        PlayerPrefs.SetString("3", "true");
        PlayerPrefs.SetString("4", "true");
        PlayerPrefs.SetString("5", "true");
        PlayerPrefs.SetString("6", "true");
        PlayerPrefs.SetString("7", "true");
        PlayerPrefs.SetString("8", "true");
        Invoke("DisableBuyAllPlayersBuyButton", 1);
    }
    void DisableBuyAllPlayersBuyButton()
    {
        buyAllPlayersBuyButton.SetActive(false);
        buyAllPlayersPurchasedButton.SetActive(true);
    }

    public void SuperOfferPurchased()
    {
        Debug.Log("Purchase Complete.........");
        RemoveAdsPurchased();
        BuyAllPlayersOfferPurchased();
        Invoke("DisableSuperOfferBuyButton", 1);
    }

    void DisableSuperOfferBuyButton()
    {
        superOfferBuyButton.SetActive(false);
        superOfferPurchasedButton.SetActive(true);
    }
}
