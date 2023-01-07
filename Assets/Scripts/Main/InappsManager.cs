using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class InappsManager : Singleton<InappsManager>
{
    public string[] nonConsumableProductIds;
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
        for (int i = 0; i < nonConsumableProductIds.Length; i++)
        {
            CheckProductPurchased(nonConsumableProductIds[i]);
        }
        //PlayerPrefs.DeleteKey("5"); //for testing purpose
        //PlayerPrefs.DeleteKey("PlayerRewarded"); //for testing purpose
        //PlayerPrefs.DeleteKey("LastTimeClicked"); //for testing purpose
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckProductPurchased(string productId)
    {
        if (CodelessIAPStoreListener.Instance.StoreController != null)
        {
            Debug.Log("checking for reciepts.........");
            Product product = CodelessIAPStoreListener.Instance.StoreController.products.WithID(productId);
            if (product != null && product.hasReceipt)
            {
                Debug.Log("unlocking product");
                //unlock products
                if (productId == nonConsumableProductIds[0])
                {
                    RemoveAdsPurchased();
                }
                else if (productId == nonConsumableProductIds[1])
                {
                    BuyAllPlayersOfferPurchased();
                }
                else if (productId == nonConsumableProductIds[2])
                {
                    SuperOfferPurchased();
                }
            }
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

    public void OnPurchaseComplete(Product p)
    {
        if (p.definition.id == nonConsumableProductIds[0])
        {
            RemoveAdsPurchased();
        }
        else if (p.definition.id == nonConsumableProductIds[1])
        {
            BuyAllPlayersOfferPurchased();
        }
        else if (p.definition.id == nonConsumableProductIds[2])
        {
            SuperOfferPurchased();
        }
    }
}
