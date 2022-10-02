using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformHandler : MonoBehaviour
{
    public PlatformType platformType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            switch (platformType)
            {
                case PlatformType.BASIC:
                    break;
                case PlatformType.ICE:
                    break;
                case PlatformType.ICEMOVING:
                    break;
                case PlatformType.LAVA:
                    break;
                case PlatformType.MOVING:
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (platformType == PlatformType.FINALPLATFORM)
            {
                //levelComplete
            }
        }
    }
}
