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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
