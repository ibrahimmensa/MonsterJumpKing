using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBuying : MonoBehaviour
{
    public string CharacterNumber;
    public int RequiredAssetAmount;
    public string RequiredAssetType;
    public bool Bought;
    public GameObject Child;
    public GameObject Child2;
    public GameObject cantBuyPopup;
    public TMPro.TextMeshProUGUI cantBuyText;
    public GameObject ShopCoins;
    public GameObject shopGems;

    // Start is called before the first frame update
    void OnEnable()
    {
        if(PlayerPrefs.GetString(CharacterNumber,"false") == "false")
        {
            //gameObject.GetComponent<Image>().color = new Color(0.33f, 0.33f, 0.33f);
            Bought = false;
            Child.SetActive(true);
            Child2.SetActive(true);
        }
        else
        {
            //gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            Bought = true;
            Child.SetActive(false);
            Child2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyPlayer()
    {
        if(RequiredAssetType == "G")
        {
            if(PlayerPrefs.GetInt("Gems", 0) > RequiredAssetAmount)
            {
                PlayerPrefs.SetString(CharacterNumber, "true");
                SceneHandler.Instance.playersInfo.playersInfo[int.Parse(CharacterNumber)].isBought = true;
                Bought = true;
                //gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) - RequiredAssetAmount);
                Child.SetActive(false);
                Child2.SetActive(false);
            }
            else
            {
                Debug.Log("Not Enough Gems");
                cantBuyPopup.SetActive(true);
                cantBuyText.text = "You Don't have enough gems";
                ShopCoins.SetActive(false);
                shopGems.SetActive(true);
            }
        }
        else if(RequiredAssetType == "C")
        {
            if (PlayerPrefs.GetInt("Coins", 0) > RequiredAssetAmount)
            {
                PlayerPrefs.SetString(CharacterNumber, "true");
                SceneHandler.Instance.playersInfo.playersInfo[int.Parse(CharacterNumber)].isBought = true;
                Bought = true;
                //gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - RequiredAssetAmount);
                Child.SetActive(false);
                Child2.SetActive(false);
            }
            else
            {
                Debug.Log("Not Enough Coins");
                cantBuyPopup.SetActive(true);
                cantBuyText.text = "You Don't have enough coins";
                ShopCoins.SetActive(true);
                shopGems.SetActive(false);
            }
        }
    }
}
