using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public GameObject eggPrefab;
    public GameObject eggSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, 20f);
        Invoke("spawnEgg", 1);
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!SceneHandler.Instance.isPause)
            transform.Translate(new Vector3(-0.8f, 0, 0) * Time.deltaTime);
    }

    public void spawnEgg()
    {
        StartCoroutine(spawnEggWithDelay());
    }

    IEnumerator spawnEggWithDelay()
    {
        int totalWait = Random.Range(2, 7);
        float wait = 0;
        while (wait < totalWait)
        {
            yield return new WaitForSeconds(0.25f);
            if (!SceneHandler.Instance.isPause)
            {
                wait += 0.25f;
            }
        }
        Instantiate(eggPrefab, eggSpawnPosition.transform.position, eggSpawnPosition.transform.rotation);
    }


}
