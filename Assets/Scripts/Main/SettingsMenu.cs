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
    { }

    public void toggleVibrations()
    { }

    public void onClickBack()
    {
        MenuHandler.Instance.switchMenu(MenuStates.MAINMENU);
    }

    public void onClickPrivacyPolicy()
    { }

}
