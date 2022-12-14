using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : Singleton<MenuHandler>
{
    public MainMenu mainMenu;
    public ShopMenu shopMenu;
    public SettingsMenu settingsMenu;
    public GameplayUIHandler gamePlayUIHandler;
    public LevelCompleteHandler levelCompleteHandler;
    public LevelFailHandler levelFailHandler;
    public PauseMenuHandler pauseMenuHandler;
    public CharacterSelection characterSelectioncreen;
    public GameObject environmentSelectioncreen;
    public GameObject DailyRewardsScreen;
    public MenuStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = MenuStates.MAINMENU;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchMenu(MenuStates currentState)
    {
        setAllMenusActiveFalse();
        switch (currentState)
        {
            case MenuStates.MAINMENU:
                mainMenu.gameObject.SetActive(true);
                mainMenu.GetComponent<MainMenu>().updateStats();
                currentState = MenuStates.MAINMENU;
                break;

            case MenuStates.SETTINGS:
                settingsMenu.gameObject.SetActive(true);
                currentState = MenuStates.SETTINGS;
                break;

            case MenuStates.SHOP:
                //shopMenu.gameObject.SetActive(true);
                currentState = MenuStates.SHOP;
                break;

            case MenuStates.GAMEPLAY:
                gamePlayUIHandler.gameObject.SetActive(true);
                currentState = MenuStates.GAMEPLAY;
                break;
            case MenuStates.CHARACTERSELECTION:
                characterSelectioncreen.gameObject.SetActive(true);
                break;
            case MenuStates.ENVIRONMENTSELECTION:
                environmentSelectioncreen.SetActive(true);
                break;
            case MenuStates.DAILYREWARDS:
                DailyRewardsScreen.SetActive(true);
                break;
        }
    }

    public void setAllMenusActiveFalse()
    {
        mainMenu.gameObject.SetActive(false);
        shopMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        gamePlayUIHandler.gameObject.SetActive(false);
        characterSelectioncreen.gameObject.SetActive(false);
        environmentSelectioncreen.gameObject.SetActive(false);
        DailyRewardsScreen.gameObject.SetActive(false);
    }
}
