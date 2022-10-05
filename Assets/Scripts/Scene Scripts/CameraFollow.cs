using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float followSpeed = 5f;
    private float xOffset = 1.7f;
    public Transform player;
    public GameObject birdSpawnPosition;
    public GameObject BirdPrefab;

    private void Update()
    {
        if (player == null)
            return;
        Vector3 newCamPos = new Vector3(player.position.x + xOffset, transform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newCamPos, followSpeed * Time.deltaTime);
    }

    public void spawnBirdHurdle()
    {
        if (!SceneHandler.Instance.isGamePlay)
        {
            return;
        }
        StartCoroutine(spawnBirdWithDelay());
    }

    IEnumerator spawnBirdWithDelay()
    {
        while (SceneHandler.Instance.isGamePlay)
        {
            Instantiate(BirdPrefab, birdSpawnPosition.transform.position, birdSpawnPosition.transform.rotation);
            yield return new WaitForSeconds(4);
        }
    }

}
