using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformHandler : MonoBehaviour
{
    public PlatformType platformType;
    public GameObject playerSpawnPosition; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.transform.tag == "Player")
        //{
        //    switch (platformType)
        //    {
        //        case PlatformType.BASIC:
        //            break;
        //        case PlatformType.MOVING:
        //            collision.transform.parent = null;
        //            break;
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.transform.tag == "Player")
        //{
        //    Debug.Log("player enter");
        //    switch (platformType)
        //    {
        //        case PlatformType.BASIC:
        //            break;
        //        case PlatformType.MOVING:
        //            Debug.Log("yes parent");
        //            collision.transform.parent = GetComponentsInChildren<GameObject>()[0].transform;
        //            break;
        //    }
        //}
    }
}
