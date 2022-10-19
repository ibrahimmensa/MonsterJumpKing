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
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString(CharacterNumber,"false") == "false")
        {
            gameObject.GetComponent<Image>().color = new Color(0.33f, 0.33f, 0.33f);
            Bought = false;
            Child.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            Bought = true;
            Child.SetActive(false);
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
                Bought = true;
                gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) - RequiredAssetAmount);
            }
            else
            {
                Debug.Log("Not Enough Gems");
            }
        }
        else if(RequiredAssetType == "C")
        {
            if (PlayerPrefs.GetInt("Coins", 0) > RequiredAssetAmount)
            {
                PlayerPrefs.SetString(CharacterNumber, "true");
                Bought = true;
                gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - RequiredAssetAmount);
            }
            else
            {
                Debug.Log("Not Enough Coins");
            }
        }
    }
}
