using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> CharactersList;
    int currentCharacter;
    public List<GameObject> buttons;
    // Start is called before the first frame update
    void Start()
    {
        FindActiveCharacter();
    }

    private void OnEnable()
    {
        currentCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (CharactersList[currentCharacter].GetComponent<CharacterBuying>().Bought)
        {
            SceneHandler.Instance.selectedPlayerNumber = currentCharacter;
            onClickBack();
            PlayerPrefs.SetInt("SelectedCharacter", currentCharacter);
        }
    }

    public void onClickBack()
    {
        MenuHandler.Instance.switchMenu(MenuStates.MAINMENU);
    }
    public void BuyPlayer()
    {
        CharactersList[currentCharacter].GetComponent<CharacterBuying>().BuyPlayer();
    }
    public void FirstCHaracterButtons()
    {
        if(currentCharacter == 0)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetActive(false);
            }
        }
        else if(CharactersList[currentCharacter].GetComponent<CharacterBuying>().Bought)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetActive(false);
            }  
        }
        else
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetActive(true);
            }
        }
    }
}
