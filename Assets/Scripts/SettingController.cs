using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    public AudioSource MusicSource, AudioSource;
    public GameObject MusicOnBtn, MusicOffBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableGameMusic()
    {
        MusicSource.enabled = false;
        PlayerPrefs.SetString("Game Music", "false");
        MusicOffBtn.SetActive(true);
        MusicOnBtn.SetActive(false);
    }
    public void EnableGameMusic()
    {
        MusicSource.enabled = true;
        PlayerPrefs.SetString("Game Music", "true");
        MusicOffBtn.SetActive(false);
        MusicOnBtn.SetActive(true);
    }
}
