using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public int levelNumber;
    public int DifficultyNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        levelNumber = PlayerPrefs.GetInt("LevelNumber", 1);
        DifficultyNumber = PlayerPrefs.GetInt("DifficultyNumber", 1);
        //levelNumber = 9;
        //DifficultyNumber = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseLevelNumber()
    {
        levelNumber++;
        DifficultyNumber = 1 + (levelNumber / 3);
        PlayerPrefs.SetInt("LevelNumber", levelNumber);
        PlayerPrefs.SetInt("DifficultyNumber", DifficultyNumber);
    }
}
