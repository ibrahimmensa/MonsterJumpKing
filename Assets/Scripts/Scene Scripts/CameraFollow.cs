using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float followSpeed = 5f;
    private float xOffset = 1.7f;
    public Transform player;
    public GameObject birdSpawnPosition;
    public GameObject SnowBallSpawnPosition;
    public GameObject FireBallSpawnPosition;
    public GameObject BirdPrefab;
    public GameObject SnowBallPrefab;
    public GameObject FireBallPrefab;
    GameObject bird;
    GameObject SnowBall;
    GameObject FireBall;
    Coroutine birdSpawning;
    Coroutine SnowBallSpawning;
    Coroutine FireBallSpawning;

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
        if (birdSpawning != null)
            StopCoroutine(birdSpawning);
        birdSpawning = StartCoroutine(spawnBirdWithDelay());
    }

    IEnumerator spawnBirdWithDelay()
    {
        yield return new WaitForSeconds(1);
        while (SceneHandler.Instance.isGamePlay)
        {
            if (bird != null)
                Destroy(bird);
            bird = Instantiate(BirdPrefab, birdSpawnPosition.transform.position, birdSpawnPosition.transform.rotation);
            int totalWait = Random.Range(12, 17);
            int wait = 0;
            while (wait < totalWait)
            {
                yield return new WaitForSeconds(1);
                if(!SceneHandler.Instance.isPause)
                {
                    wait++;
                }
            }
        }
    }
    public void spawnSnowBallHurdle()
    {
        if (!SceneHandler.Instance.isGamePlay)
        {
            return;
        }
        if (SnowBallSpawning != null)
            StopCoroutine(SnowBallSpawning);
        SnowBallSpawning = StartCoroutine(spawnSnowBallWithDelay());
    }

    IEnumerator spawnSnowBallWithDelay()
    {
        yield return new WaitForSeconds(5);
        while (SceneHandler.Instance.isGamePlay)
        {
            if (SnowBall != null)
                Destroy(SnowBall);
            SnowBall = Instantiate(SnowBallPrefab, SnowBallSpawnPosition.transform.position, SnowBallSpawnPosition.transform.localRotation);
            int totalWait = 15;
            int wait = 0;
            while (wait < totalWait)
            {
                yield return new WaitForSeconds(1);
                if (!SceneHandler.Instance.isPause)
                {
                    wait++;
                }
            }
        }
    }

    public void spawnFireBallHurdle()
    {
        if (!SceneHandler.Instance.isGamePlay)
        {
            return;
        }
        if (FireBallSpawning != null)
            StopCoroutine(FireBallSpawning);
        FireBallSpawning = StartCoroutine(spawnFireBallWithDelay());
    }

    IEnumerator spawnFireBallWithDelay()
    {
        yield return new WaitForSeconds(5);
        while (SceneHandler.Instance.isGamePlay)
        {
            if (FireBall != null)
                Destroy(FireBall);
            FireBall = Instantiate(FireBallPrefab, FireBallSpawnPosition.transform.position, FireBallSpawnPosition.transform.localRotation);
            int totalWait = 12;
            int wait = 0;
            while (wait < totalWait)
            {
                yield return new WaitForSeconds(1);
                if (!SceneHandler.Instance.isPause)
                {
                    wait++;
                }
            }
        }
    }

    public void StopHurdleCoroutines()
    {
        if (birdSpawning != null)
            StopCoroutine(birdSpawning); 
        if (SnowBallSpawning != null)
            StopCoroutine(SnowBallSpawning);
        if (FireBallSpawning != null)
            StopCoroutine(FireBallSpawning);
        if (bird != null)
            Destroy(bird);
        if (SnowBall != null)
            Destroy(SnowBall);
        if (FireBall != null)
            Destroy(FireBall);
    }
}
