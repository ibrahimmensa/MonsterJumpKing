using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundEffects
{
    BUTTONCLICK,
    JUMP,
    LEVELFAIL,
    LEVELCOMPLETE,
}
public class SoundManager : Singleton<SoundManager>
{
    public AudioClip buttonClick, jump, death, levelComplete, bgMusic;
    public AudioSource sfx, bg;
    bool isMusicOn = true;
    bool isSFXOn = true;
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

    public void playOnce(SoundEffects sound)
    {
        switch (sound)
        {
            case SoundEffects.BUTTONCLICK:
                sfx.PlayOneShot(buttonClick);
                break;
            case SoundEffects.JUMP:
                sfx.PlayOneShot(jump);
                break;
            case SoundEffects.LEVELCOMPLETE:
                sfx.PlayOneShot(levelComplete);
                break;
            case SoundEffects.LEVELFAIL:
                sfx.PlayOneShot(death);
                break;
        }
    }

    public void updateState(bool music, bool effects)
    {
        sfx.enabled = effects;
        bg.enabled = music;
    }

    public void setState()
    {
        if (PlayerPrefs.GetInt("isMusicOn", 1) == 1)
        {
            isMusicOn = true;
        }
        else if (PlayerPrefs.GetInt("isMusicOn", 1) == 0)
        {
            isMusicOn = false;
        }
        if (PlayerPrefs.GetInt("isSoundOn", 1) == 1)
        {
            isSFXOn = true;
        }
        else if (PlayerPrefs.GetInt("isSoundOn", 1) == 0)
        {
            isSFXOn = false;
        }
        updateState(isMusicOn, isSFXOn);
    }
}
