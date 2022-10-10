using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle SFXToggle;
    bool isSoundOn = true;
    bool isMusicOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        setState(); 
    }

    public void setState()
    {
        if (PlayerPrefs.GetInt("isMusicOn", 1) == 1)
        {
            musicToggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("isMusicOn", 1) == 0)
        {
            musicToggle.isOn = false;
        }
        if (PlayerPrefs.GetInt("isSoundOn", 1) == 1)
        {
            SFXToggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("isSoundOn", 1) == 0)
        {
            SFXToggle.isOn = false;
        }
    }

    public void toggleMusic()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        if (musicToggle.isOn)
        {
            isMusicOn = true;
            PlayerPrefs.SetInt("isMusicOn", 1);
        }
        else
        {
            isMusicOn = false;
            PlayerPrefs.SetInt("isMusicOn", 0);
        }
        SoundManager.Instance.updateState(isMusicOn, isSoundOn);
    }



    public void toggleSFX()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        if (SFXToggle.isOn)
        {
            isSoundOn = true;
            PlayerPrefs.SetInt("isSoundOn", 1);
        }
        else
        {
            isSoundOn = false;
            PlayerPrefs.SetInt("isSoundOn", 0);
        }
        SoundManager.Instance.updateState(isMusicOn, isSoundOn);
    }

    public void onClickBack()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        MenuHandler.Instance.switchMenu(MenuStates.MAINMENU);
    }

    public void onClickPrivacyPolicy()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        Application.OpenURL("https://mensaplay.com/wensa/privacy-policy.html");
    }

}
