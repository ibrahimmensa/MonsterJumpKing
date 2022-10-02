using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> CharactersList;
    int currentCharacter;
    // Start is called before the first frame update
    void Start()
    {
        FindActiveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextCharacter()
    {
        DisbaleAll();
        AssignCurrentCharacter(currentCharacter);
        CharactersList[currentCharacter].SetActive(true);
    }
    public void PreviousCharacter()
    {
        DisbaleAll();
        AssignCurrentCharacter(currentCharacter);
        CharactersList[currentCharacter].SetActive(true);
    }
    public void DisbaleAll()
    {
        for (int i = 0; i < CharactersList.Count; i++)
        {
            CharactersList[i].SetActive(false);
        }
    }
    public void AssignCurrentCharacter(int i)
    {
        currentCharacter = (i = 1) % CharactersList.Count;
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
    }
    public void SelectCharacter()
    {

    }
}
