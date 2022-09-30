using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;
    [SerializeField] private GameObject highscoreObj;

    private void Start()
    {
        scoreText.text = "SCORE:  " + PlayerPrefs.GetInt("score");

        if (PlayerPrefs.GetInt("score") == 0)
        {
            highscoreObj.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("score") >= PlayerPrefs.GetInt("highscore"))
        {
            Debug.Log("highscore");
            highscoreObj.SetActive(true);
        }
        else
        {
            highscoreObj.SetActive(false);
        }
    }

    private void Update()
    {
        highscoreText.text = "HIGHSCORE:   " + PlayerPrefs.GetInt("highscore");
    }
}
