using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] allPlatforms;
    public GameObject lastPlatform;
    public GameObject initialPlatform;
    public float minDistance, maxDistance;
    public Vector3 initialPlatformPosition;
    public GameObject previousPlatform;
    public Transform platformParent;
    public List<GameObject> allSpawnedPlatforms;
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
        previousPlatform = Instantiate(initialPlatform, initialPlatformPosition, Quaternion.identity, platformParent);
        allSpawnedPlatforms.Add(previousPlatform);
        int levelNumber = SceneHandler.Instance.levelHandler.levelNumber;
        int platformCount = levelNumber * 3;
        for (int i = 0; i < platformCount; i++)
        {
            float nextPlatformDistance = Random.Range(minDistance, maxDistance);
            if (SceneHandler.Instance.levelHandler.DifficultyNumber > 3)
            {
                Debug.Log("In level 3");
                float nextPlatformHeight = Random.Range(-2, 2);
                int platformIndex = Random.Range(0, SceneHandler.Instance.levelHandler.DifficultyNumber);
                GameObject temp = Instantiate(allPlatforms[platformIndex], new Vector3(previousPlatform.transform.position.x + nextPlatformDistance, previousPlatform.transform.position.y + nextPlatformHeight, 0), Quaternion.identity, platformParent);
                previousPlatform = temp;
                allSpawnedPlatforms.Add(temp);
            }
            else 
            {
                Debug.Log("In level 1");
                //float nextPlatformHeight = Random.Range(-3, 3);
                int platformIndex = Random.Range(0, SceneHandler.Instance.levelHandler.DifficultyNumber);
                GameObject temp = Instantiate(allPlatforms[platformIndex], new Vector3(previousPlatform.transform.position.x + nextPlatformDistance, previousPlatform.transform.position.y, 0), Quaternion.identity, platformParent);
                previousPlatform = temp;
                allSpawnedPlatforms.Add(temp);
            }
        }
        float finalPlatformDistance = Random.Range(minDistance, maxDistance);
        if (SceneHandler.Instance.levelHandler.DifficultyNumber > 3)
        {
            Debug.Log("In level 3");
            float nextPlatformHeight = Random.Range(-2, 2);
            //int platformIndex = Random.Range(0, SceneHandler.Instance.levelHandler.DifficultyNumber);
            GameObject temp = Instantiate(lastPlatform, new Vector3(previousPlatform.transform.position.x + finalPlatformDistance, previousPlatform.transform.position.y + nextPlatformHeight, 0), Quaternion.identity, platformParent);
            previousPlatform = temp;
            allSpawnedPlatforms.Add(temp);
        }
        else
        {
            Debug.Log("In level 1");
            //float nextPlatformHeight = Random.Range(-3, 3);
            //int platformIndex = Random.Range(0, SceneHandler.Instance.levelHandler.DifficultyNumber);
            GameObject temp = Instantiate(lastPlatform, new Vector3(previousPlatform.transform.position.x + finalPlatformDistance, previousPlatform.transform.position.y, 0), Quaternion.identity, platformParent);
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
