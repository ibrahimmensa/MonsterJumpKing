using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneHandler.Instance.isGamePlay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MenuHandler.Instance.gamePlayUIHandler.moveSlider = false;
                jump();
            }
        }
    }

    public void jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0.75f, 2f) * MenuHandler.Instance.gamePlayUIHandler.jumpPower / 17f, ForceMode2D.Impulse);
            //rb.velocity = new Vector2(0.75f, 2f) * MenuHandler.Instance.gamePlayUIHandler.jumpPower / 17f;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            isGrounded = true;
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            isGrounded = false;
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = false;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            isGrounded = true;
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
        }
    }
}
