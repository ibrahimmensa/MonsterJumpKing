using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlatformType
{
    BASIC,
    MOVING
}

[Serializable]
public class platformCategory
{
    public GameObject[] allPlatforms;
}

public class PlatformSpawner : MonoBehaviour
{
    public int[] numberOfPlatformsAccToLevelNum;
    public platformCategory[] allPlatforms;
    public GameObject[] lastPlatform;
    public GameObject[] initialPlatform;
    public Sprite[] environmentBG;
    public SpriteRenderer BG;
    public float minDistance, maxDistance;
    public Vector3 initialPlatformPosition;
    public GameObject previousPlatform;
    public Transform platformParent;
    public List<GameObject> allSpawnedPlatforms;
    public int environmentNumber = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnPlatformForLevel()
    {
        BG.sprite = environmentBG[environmentNumber];
        previousPlatform = Instantiate(initialPlatform[environmentNumber], initialPlatformPosition, Quaternion.identity, platformParent);
        allSpawnedPlatforms.Add(previousPlatform);
        int levelNumber = SceneHandler.Instance.levelHandler.levelNumber;
        int platformCount=0;
        if (levelNumber < numberOfPlatformsAccToLevelNum.Length)
        {
            platformCount = numberOfPlatformsAccToLevelNum[levelNumber];
        }
        else
        {
            if (levelNumber % 3 == 0)
            {
                platformCount = UnityEngine.Random.Range(12, 15);
            }
            else
            {
                platformCount = UnityEngine.Random.Range(16, 21);
            }
        }
        //int platformCount = (levelNumber * 2) + 2;
        for (int i = 0; i < platformCount; i++)
        {
            float nextPlatformDistance = UnityEngine.Random.Range(minDistance, maxDistance);
            if (SceneHandler.Instance.levelHandler.DifficultyNumber > 3)
            {
                Debug.Log("Spawning platform");
                //Debug.Log("In level 3");
                //float nextPlatformHeight = UnityEngine.Random.Range(-2, 2);
                int platformIndex= allPlatforms[environmentNumber].allPlatforms.Length;
                while (platformIndex >= allPlatforms[environmentNumber].allPlatforms.Length)
                    platformIndex = UnityEngine.Random.Range(0, SceneHandler.Instance.levelHandler.DifficultyNumber);
                Debug.Log(platformIndex);
                GameObject temp = Instantiate(allPlatforms[environmentNumber].allPlatforms[platformIndex], new Vector3(previousPlatform.transform.position.x + nextPlatformDistance, previousPlatform.transform.position.y, 0), Quaternion.identity, platformParent);
                previousPlatform = temp;
                allSpawnedPlatforms.Add(temp);
            }
            else
            {
                Debug.Log("Spawning platform2");
                //Debug.Log("In level 1");
                //float nextPlatformHeight = Random.Range(-3, 3);
                int platformIndex = allPlatforms[environmentNumber].allPlatforms.Length;
                while (platformIndex >= allPlatforms[environmentNumber].allPlatforms.Length)
                    platformIndex = UnityEngine.Random.Range(0, SceneHandler.Instance.levelHandler.DifficultyNumber);
                Debug.Log(platformIndex);
                GameObject temp = Instantiate(allPlatforms[environmentNumber].allPlatforms[platformIndex], new Vector3(previousPlatform.transform.position.x + nextPlatformDistance, previousPlatform.transform.position.y, 0), Quaternion.identity, platformParent);
                previousPlatform = temp;
                allSpawnedPlatforms.Add(temp);
            }
        }
        float finalPlatformDistance = UnityEngine.Random.Range(minDistance + 2, maxDistance + 1);
        if (SceneHandler.Instance.levelHandler.levelNumber > 6)
        {
            Debug.Log("In level 3");
            if (SceneHandler.Instance.levelHandler.levelNumber % 3 == 0)
            {
                if(environmentNumber==0)
                    SceneHandler.Instance.cam.GetComponent<CameraFollow>().spawnBirdHurdle();
                else if(environmentNumber==1)
                    SceneHandler.Instance.cam.GetComponent<CameraFollow>().spawnSnowBallHurdle();
                else if (environmentNumber == 2)
                    SceneHandler.Instance.cam.GetComponent<CameraFollow>().spawnFireBallHurdle();
            }
            float nextPlatformHeight = UnityEngine.Random.Range(-2, 2);
            //int platformIndex = Random.Range(0, SceneHandler.Instance.levelHandler.DifficultyNumber);
            GameObject temp = Instantiate(lastPlatform[environmentNumber], new Vector3(previousPlatform.transform.position.x + finalPlatformDistance, previousPlatform.transform.position.y + nextPlatformHeight, 0), Quaternion.identity, platformParent);
            previousPlatform = temp;
            allSpawnedPlatforms.Add(temp);
        }
        else
        {
            Debug.Log("In level 1");
            //float nextPlatformHeight = Random.Range(-3, 3);
            //int platformIndex = Random.Range(0, SceneHandler.Instance.levelHandler.DifficultyNumber);
            GameObject temp = Instantiate(lastPlatform[environmentNumber], new Vector3(previousPlatform.transform.position.x + finalPlatformDistance, previousPlatform.transform.position.y, 0), Quaternion.identity, platformParent);
            previousPlatform = temp;
            allSpawnedPlatforms.Add(temp);
        }
    }

    public void clearAllPlatforms()
    {
        foreach (GameObject platform in allSpawnedPlatforms)
        {
            Destroy(platform);
        }
        allSpawnedPlatforms.Clear();
    }
}
