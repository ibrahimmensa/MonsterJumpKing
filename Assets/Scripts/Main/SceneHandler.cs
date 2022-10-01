using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MenuStates
{
    MAINMENU,
    SETTINGS,
    SHOP,
    GAMEPLAY
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startLevel()
    {
        isGamePlay = true;
        int tutorialShown = PlayerPrefs.GetInt("isTutorialShown", 0);
        if (tutorialShown == 0)
        {
            //showTutorial
        }
        else
        {
            
        }

        MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
        platformSpawner.spawnPlatformForLevel();
        spawnPlayer();
    }

    public void spawnPlayer()
    {
        spawnedPlayer = Instantiate(playerPrefabs[selectedPlayerNumber], playerPosition, Quaternion.identity);
        cam.gameObject.GetComponent<CameraFollow>().player = spawnedPlayer.transform;
    }
}
