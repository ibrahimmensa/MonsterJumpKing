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
        
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1f, 0, 0) * Time.deltaTime);
    }

    public void spawnEgg()
    {
        StartCoroutine(spawnEggWithDelay());
    }

    IEnumerator spawnEggWithDelay()
    {
        yield return new WaitForSeconds(2);
        Instantiate(eggPrefab, eggSpawnPosition.transform.position, eggSpawnPosition.transform.rotation);
    }


}
