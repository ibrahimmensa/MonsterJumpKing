using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
        GetComponent<Rigidbody2D>().AddForce(transform.right * Random.Range(-0.8f, -2.8f), ForceMode2D.Impulse);
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
