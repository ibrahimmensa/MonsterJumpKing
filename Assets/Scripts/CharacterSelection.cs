using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> CharactersList;
    public int currentCharacter;
    public GameObject unlockButton;
    public GameObject AdsButton;
    public GameObject SelectButton;
    public GameObject SelectedButton;
    public TMPro.TMP_Text adsText;

    // Start is called before the first frame update
    void Start()
    {
        EnableAll();
        Invoke("setUpCharacterScreen", 0.01f);
    }

    void setUpCharacterScreen()
    {
        DisbaleAll();
        for(int i = 0; i < CharactersList.Count; i++)
        {
            CharactersList[i].GetComponent<Image>().enabled = true;
        }
        currentCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        CharactersList[currentCharacter].SetActive(true);
        FindActiveCharacter();
    }

    private void OnEnable()
    {
        EnableAll();
        Invoke("setUpCharacterScreen", 0.01f);
    }

    public void NextCharacter()
    {
        DisbaleAll();
        AssignCurrentCharacter(currentCharacter, true);
        CharactersList[currentCharacter].SetActive(true);
    }
    public void PreviousCharacter()
    {
        DisbaleAll();
        AssignCurrentCharacter(currentCharacter, false);
        CharactersList[currentCharacter].SetActive(true);
    }
    public void DisbaleAll()
    {
        for (int i = 0; i < CharactersList.Count; i++)
        {
            CharactersList[i].SetActive(false);
        }
    }

    public void EnableAll()
    {
        for (int i = 0; i < CharactersList.Count; i++)
        {
            CharactersList[i].SetActive(true);
            CharactersList[i].GetComponent<Image>().enabled = false;
        }
    }

    public void AssignCurrentCharacter(int i, bool forward)
    {
        if(forward)
        {
            currentCharacter = (i + 1) % CharactersList.Count;
            FirstCHaracterButtons();
        }
        else
        {
            currentCharacter = Mathf.Abs((i + 8) % CharactersList.Count);
            FirstCHaracterButtons();
        }
    }
    public void FindActiveCharacter()
    {
        for (int i = 0; i < CharactersList.Count; i++)
        {
            if(CharactersList[i].activeSelf)
            {
                currentCharacter = i;
            }
        }
        FirstCHaracterButtons();
        
    }
    public void SelectCharacter()
    {
        if (currentCharacter == 0 || CharactersList[currentCharacter].GetComponent<CharacterBuying>().Bought)
        {
            SceneHandler.Instance.selectedPlayerNumber = currentCharacter;
            onClickBack();
            PlayerPrefs.SetInt("SelectedCharacter", currentCharacter);
        }
    }

    public void onClickBack()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        MenuHandler.Instance.switchMenu(MenuStates.MAINMENU);
    }
    public void BuyPlayer()
    {
        CharactersList[currentCharacter].GetComponent<CharacterBuying>().BuyPlayer();
        FirstCHaracterButtons();
    }

    public void BuyWithAds()
    {
        AdsInitializer.Instance.ShowAd(RewardedAdType.FREECHARACTER);
    }

    public void BuyPlayerAdWatched()
    {
        SceneHandler.Instance.playersInfo.playersInfo[currentCharacter].noOfAdsWatched++;
        PlayerPrefs.SetInt("AdsWatched" + currentCharacter, PlayerPrefs.GetInt("AdsWatched" + currentCharacter, 0) + 1);
        SceneHandler.Instance.playersInfo.playersInfo[currentCharacter].noOfAdsWatched = PlayerPrefs.GetInt("AdsWatched" + currentCharacter, 0);
        if (SceneHandler.Instance.playersInfo.playersInfo[currentCharacter].noOfAdsWatched== SceneHandler.Instance.playersInfo.playersInfo[currentCharacter].noOfAdsToWatchInTotal)
        {
            PlayerPrefs.SetString(currentCharacter.ToString(), "true");
            CharactersList[currentCharacter].GetComponent<CharacterBuying>().Bought = true;
            CharactersList[currentCharacter].GetComponent<CharacterBuying>().Child.SetActive(false);
            CharactersList[currentCharacter].GetComponent<CharacterBuying>().Child2.SetActive(false);
            SceneHandler.Instance.playersInfo.playersInfo[currentCharacter].isBought = true;
        }
        FirstCHaracterButtons();
    }

    public void FirstCHaracterButtons()
    {
        if(currentCharacter == 0)
        {
            unlockButton.SetActive(false);
            AdsButton.SetActive(false);
            if (currentCharacter == PlayerPrefs.GetInt("SelectedCharacter", 0))
            {
                SelectedButton.SetActive(true);
                SelectButton.SetActive(false);
            }
            else
            {
                SelectedButton.SetActive(false);
                SelectButton.SetActive(true);
            }
        }
        else if(CharactersList[currentCharacter].GetComponent<CharacterBuying>().Bought)
        {
            unlockButton.SetActive(false);
            AdsButton.SetActive(false);
            if (currentCharacter == PlayerPrefs.GetInt("SelectedCharacter", 0))
            {
                SelectedButton.SetActive(true);
                SelectButton.SetActive(false);
            }
            else
            {
                SelectedButton.SetActive(false);
                SelectButton.SetActive(true);
            }
        }
        else
        {
            unlockButton.SetActive(true);
            AdsButton.SetActive(true);
            adsText.text = PlayerPrefs.GetInt("AdsWatched" + currentCharacter, 0) + "/" + SceneHandler.Instance.playersInfo.playersInfo[currentCharacter].noOfAdsToWatchInTotal;
            SelectedButton.SetActive(false);
            SelectButton.SetActive(false);
        }
    }
}
