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

    public GameObject playButtonEnv2;
    public GameObject playButtonEnv3;
    public GameObject cantPlayPopup;
    public TMPro.TextMeshProUGUI cantPlayText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (selectedEnv == 1)
        {
            if (SceneHandler.Instance.levelHandler.levelNumber < 10)
            {
                playButtonEnv2.GetComponent<Button>().interactable = false;
                cantPlayPopup.SetActive(true);
                cantPlayText.text = "COMPLETE 10 LEVELS TO UNLOCK";
            }
            else
            {
                playButtonEnv2.GetComponent<Button>().interactable = true;
                cantPlayPopup.SetActive(false);
            }
        }
        else if (selectedEnv == 2)
        {
            if (SceneHandler.Instance.levelHandler.levelNumber < 15)
            {
                playButtonEnv3.GetComponent<Button>().interactable = false;
                cantPlayPopup.SetActive(true);
                cantPlayText.text = "COMPLETE 15 LEVELS TO UNLOCK";
            }

            else
            {
                playButtonEnv3.GetComponent<Button>().interactable = true;
                cantPlayPopup.SetActive(false);
            }
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
                    if (SceneHandler.Instance.levelHandler.levelNumber < 10)
                    {
                        playButtonEnv2.GetComponent<Button>().interactable = false;
                        cantPlayPopup.SetActive(true);
                        cantPlayText.text = "COMPLETE 10 LEVELS TO UNLOCK";
                    }
                    else
                    {
                        playButtonEnv2.GetComponent<Button>().interactable = true;
                        cantPlayPopup.SetActive(false);
                    }
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
                    if (SceneHandler.Instance.levelHandler.levelNumber < 10)
                    {
                        playButtonEnv2.GetComponent<Button>().interactable = false;
                        cantPlayPopup.SetActive(true);
                        cantPlayText.text = "COMPLETE 10 LEVELS TO UNLOCK";
                    }
                    else
                    {
                        playButtonEnv2.GetComponent<Button>().interactable = true;
                        cantPlayPopup.SetActive(false);
                    }
                }
                else if (selectedEnv == 1)
                {
                    tween.from.x = 0;
                    tween.to.x = -772;
                    selectedEnv = 2;
                    tween.ResetToBeginning();
                    tween.PlayForward();
                    if (SceneHandler.Instance.levelHandler.levelNumber < 15)
                    {
                        playButtonEnv3.GetComponent<Button>().interactable = false;
                        cantPlayPopup.SetActive(true);
                        cantPlayText.text = "COMPLETE 15 LEVELS TO UNLOCK";
                    }
                    else
                    {
                        playButtonEnv3.GetComponent<Button>().interactable = true;
                        cantPlayPopup.SetActive(false);
                    }
                }
            }
        }
    }

    public void onClickBack()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        MenuHandler.Instance.switchMenu(MenuStates.MAINMENU);
    }

    //private void OnMouseDown()
    //{
    //    Debug.Log("presss");
    //    initialPos = Input.mousePosition;
    //}

    //private void OnMouseDrag()
    //{
    //    finalPos = Input.mousePosition;
    //    Debug.Log(finalPos.x - initialPos.x);
    //}
}
