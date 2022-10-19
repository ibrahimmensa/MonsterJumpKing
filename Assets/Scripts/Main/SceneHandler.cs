using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MenuStates
{
    MAINMENU,
    SETTINGS,
    SHOP,
    GAMEPLAY,
    CHARACTERSELECTION
}

public class SceneHandler : Singleton<SceneHandler>
{
    public PlatformSpawner platformSpawner;
    public LevelHandler levelHandler;
    public bool isGamePlay = false;
    public GameObject[] playerPrefabs;
    public int selectedPlayerNumber = 0;
    public Vector3 playerPosition;
    public GameObject spawnedPlayer;
    public Camera cam;
    public GameObject revivePlatform;
    public int coinsBeforeFall;
    public bool clearPlayerPrefs = false;
    public bool isRevivedOnce = false;
    public bool gotDoubleReward = false;
    public int Lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (clearPlayerPrefs)
        {
            //PlayerPrefs.DeleteAll();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startLevel()
    {
        isGamePlay = true;
        Lives = 3;
        int tutorialShown = PlayerPrefs.GetInt("isTutorialShown", 0);
        MenuHandler.Instance.gamePlayUIHandler.gameObject.SetActive(true);
        if (tutorialShown == 0)
        {
            //showTutorial
            PlayerPrefs.SetInt("isTutorialShown", 1);
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = false;
            platformSpawner.spawnPlatformForLevel();
            SoundManager.Instance.bg.Play();
        }
        else
        {
            MenuHandler.Instance.gamePlayUIHandler.TurnOffTutorial();
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
            platformSpawner.spawnPlatformForLevel();
            spawnPlayer();
            SoundManager.Instance.bg.Play();
            isRevivedOnce = false;
        }

        
    }

    public void spawnPlayer()
    {
        selectedPlayerNumber = PlayerPrefs.GetInt("SelectedCharacter", 0);
        spawnedPlayer = Instantiate(playerPrefabs[selectedPlayerNumber], playerPosition, Quaternion.identity);
        cam.gameObject.GetComponent<CameraFollow>().player = spawnedPlayer.transform;
    }

    public void restartLevel()
    {
        isGamePlay = false;
        platformSpawner.clearAllPlatforms();
        Destroy(spawnedPlayer);
        startLevel();
    }

    public void backToMenu()
    {
        isGamePlay = false;
        platformSpawner.clearAllPlatforms();
        Destroy(spawnedPlayer);
        MenuHandler.Instance.switchMenu(MenuStates.MAINMENU);
        MenuHandler.Instance.mainMenu.updateStats();
        SoundManager.Instance.bg.Stop();
    }

    public void revivePlayer()
    {
        Debug.Log("revivied ");
        MenuHandler.Instance.levelFailHandler.gameObject.SetActive(false);
        MenuHandler.Instance.switchMenu(MenuStates.GAMEPLAY);
        selectedPlayerNumber = PlayerPrefs.GetInt("SelectedCharacter", 0);
        spawnedPlayer = Instantiate(playerPrefabs[selectedPlayerNumber], revivePlatform.GetComponent<platformHandler>().playerSpawnPosition.transform.position, Quaternion.identity);
        cam.gameObject.GetComponent<CameraFollow>().player = spawnedPlayer.transform;
        spawnedPlayer.GetComponent<PlayerController>().coinsCollected = coinsBeforeFall;
        spawnedPlayer.GetComponent<PlayerController>().updateUI();
        if(Lives <= 0 && !isRevivedOnce)
        {
            isRevivedOnce = true;
        }
        MenuHandler.Instance.levelFailHandler.reviveBtn.interactable = false;
        SoundManager.Instance.bg.Play();
    }


}
