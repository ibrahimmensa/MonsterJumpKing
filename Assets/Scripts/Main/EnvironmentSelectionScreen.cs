using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSelectionScreen : MonoBehaviour
{
    private Vector3 initialPos;
    private Vector3 finalPos;

    public int selectedEnv = 0;

    public TweenPosition tween;

    public Image env2Play;
    public Image env3Play;

    public GameObject cantPlayPopup;
    public TMPro.TextMeshProUGUI cantPlayText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (SceneHandler.Instance.levelHandler.levelNumber <= 10)
        {
            env2Play.color = new Color(0.33f, 0.33f, 0.33f);
        }
        else
        {
            env2Play.color = new Color(1, 1, 1);
        }

        if (PlayerPrefs.GetInt("LevelsOfEnvironment2", 0) <= 10)
        {
            env3Play.color = new Color(0.33f, 0.33f, 0.33f);
        }

        else
        {
            env3Play.color = new Color(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("presss");
            initialPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            finalPos = Input.mousePosition;
            if(finalPos.x - initialPos.x > 75)
            {
                if (selectedEnv == 1)
                {
                    tween.from.x = 0;
                    tween.to.x = 772;
                    selectedEnv = 0;
                    tween.ResetToBeginning();
                    tween.PlayForward();
                    cantPlayPopup.SetActive(false);
                }
                else if(selectedEnv == 2)
                {
                    tween.from.x = -772;
                    tween.to.x = 0;
                    selectedEnv = 1;
                    tween.ResetToBeginning();
                    tween.PlayForward();
                    cantPlayPopup.SetActive(false);
                }
            }
            else if(finalPos.x - initialPos.x < -75)
            {
                if (selectedEnv == 0)
                {
                    tween.from.x = 772;
                    tween.to.x = 0;
                    selectedEnv = 1;
                    tween.ResetToBeginning();
                    tween.PlayForward();
                    cantPlayPopup.SetActive(false);
                }
                else if (selectedEnv == 1)
                {
                    tween.from.x = 0;
                    tween.to.x = -772;
                    selectedEnv = 2;
                    tween.ResetToBeginning();
                    tween.PlayForward();
                    cantPlayPopup.SetActive(false);
                }
            }
        }
    }

    public void onClickBack()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        MenuHandler.Instance.switchMenu(MenuStates.MAINMENU);
    }

    public void OnClickPlayEnv2()
    {
        if (SceneHandler.Instance.levelHandler.levelNumber <= 10)
        {
            cantPlayPopup.SetActive(true);
            cantPlayText.text = "COMPLETE 10 LEVELS OF JUNGLE ENVIRONMENT TO UNLOCK";
        }
        else
        {
            cantPlayPopup.SetActive(false);
            MenuHandler.Instance.mainMenu.onClickPlay(1);
        }
    }

    public void OnClickPlayEnv3()
    {
        if (PlayerPrefs.GetInt("LevelsOfEnvironment2", 0) <= 10)
        {
            Debug.Log(PlayerPrefs.GetInt("LevelsOfEnvironment2", 0));
            cantPlayPopup.SetActive(true);
            cantPlayText.text = "COMPLETE 10 LEVELS OF SNOW ENVIRONMENT TO UNLOCK";
        }

        else
        {
            cantPlayPopup.SetActive(false);
            MenuHandler.Instance.mainMenu.onClickPlay(2);
        }
    }
}
