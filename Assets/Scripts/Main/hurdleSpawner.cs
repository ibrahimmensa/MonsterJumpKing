using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdleSpawner : MonoBehaviour
{
    public GameObject[] allHurdles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnHurdles()
    {
        if (SceneHandler.Instance.levelHandler.levelNumber < 3)
        {
            return;
        }

    }


}
