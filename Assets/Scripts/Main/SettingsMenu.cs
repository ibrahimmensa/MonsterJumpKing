using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle vibrationToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMusic()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
    }

    public void toggleVibrations()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
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
