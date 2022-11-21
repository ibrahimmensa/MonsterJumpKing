using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10,-40), Random.Range(-30, -70)) * 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerController>().die();
        }
    }
}
