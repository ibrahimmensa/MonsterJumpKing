using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public SettingController SettingControllerRef;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Game Music", "true") == "true")
        {
            SettingControllerRef.EnableGameMusic();
        }
        else
        {
            SettingControllerRef.DisableGameMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
