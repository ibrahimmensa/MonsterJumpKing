using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded = false;
    Animator anim;
    public int coinsCollected = 0;
    public GameObject lastPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        MenuHandler.Instance.gamePlayUIHandler.LivesText.GetComponent<TMPro.TMP_Text>().text = SceneHandler.Instance.Lives.ToString();
    }

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        coinsCollected = 0;
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneHandler.Instance.isGamePlay)
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MenuHandler.Instance.gamePlayUIHandler.moveSlider = false;
                jump();
            }
#endif
#if UNITY_ANDROID
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                MenuHandler.Instance.gamePlayUIHandler.moveSlider = false;
                jump();
            }
#endif
        }
    }

    public void jump()
    {
        if (isGrounded)
        {
            SoundManager.Instance.playOnce(SoundEffects.JUMP);
            rb.AddForce(new Vector2(0.75f, 2.5f) * MenuHandler.Instance.gamePlayUIHandler.jumpPower / 25f, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
            //rb.velocity = new Vector2(0.75f, 2f) * MenuHandler.Instance.gamePlayUIHandler.jumpPower / 17f;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            isGrounded = true;
            if (collision.transform.parent.name.Contains("FinalPlatform"))
            {
                MenuHandler.Instance.levelCompleteHandler.gameObject.SetActive(true);
                Debug.Log("Level Completed");
            }
            else
            {
                MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
            }
        }
        else if (collision.transform.tag == "hurdle")
        {
            SceneHandler.Instance.Lives--;
            MenuHandler.Instance.gamePlayUIHandler.LivesText.GetComponent<TMPro.TMP_Text>().text = SceneHandler.Instance.Lives.ToString();
            if (SceneHandler.Instance.Lives <= 0)
            {
                die();
            }
            else
            {
                WentDown();
                SceneHandler.Instance.revivePlayer();
            }
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
            SceneHandler.Instance.revivePlatform = collision.transform.parent.gameObject;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "fall")
        {
            Debug.Log("Level Fail");
            SceneHandler.Instance.Lives--;
            MenuHandler.Instance.gamePlayUIHandler.LivesText.GetComponent<TMPro.TMP_Text>().text = SceneHandler.Instance.Lives.ToString();
            if (SceneHandler.Instance.Lives <= 0)
            {
                die();
            }
            else
            {
                WentDown();
                SceneHandler.Instance.revivePlayer();
            }
            //MenuHandler.Instance.levelFailHandler.gameObject.SetActive(true);
            //this.gameObject.SetActive(false);
        }
        else if (collision.transform.tag == "finalPoint")
        {
            SoundManager.Instance.playOnce(SoundEffects.LEVELCOMPLETE);
            MenuHandler.Instance.levelCompleteHandler.gameObject.SetActive(true);
        }
        else if (collision.transform.tag == "platform")
        {
            isGrounded = true;
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
            SceneHandler.Instance.revivePlatform = collision.transform.parent.gameObject;
        }
        else if (collision.tag == "coin")
        {
            coinCollected();
            Destroy(collision.gameObject);
        }
    }

    public void die()
    {
        SceneHandler.Instance.coinsBeforeFall = coinsCollected;
        rb.AddForce(Vector3.up, ForceMode2D.Impulse);
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(dieWithDelay());
    }

    IEnumerator dieWithDelay()
    {
        yield return new WaitForSeconds(2);
        MenuHandler.Instance.levelFailHandler.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        Destroy(this);
    }
    public void WentDown()
    {
        SceneHandler.Instance.coinsBeforeFall = coinsCollected;
        rb.AddForce(Vector3.up, ForceMode2D.Impulse);
        GetComponent<CapsuleCollider2D>().enabled = false;
        this.gameObject.SetActive(false);
        Destroy(this);
    }

    public void coinCollected()
    {
        coinsCollected++;
        updateUI();
    }


    public void updateUI()
    {
        MenuHandler.Instance.gamePlayUIHandler.updateUI(coinsCollected);
    }

}
