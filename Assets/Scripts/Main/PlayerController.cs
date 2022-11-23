using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded = false;
    Animator anim;
    public int coinsCollected = 0;
    public GameObject lastPlatform;
    bool HasFall = false;
    public bool hasTouchedFlyingHurdle = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneHandler.Instance.Lives > 0)
        {
            MenuHandler.Instance.gamePlayUIHandler.LivesText.text = SceneHandler.Instance.Lives.ToString();
        }
        else
        {
            MenuHandler.Instance.gamePlayUIHandler.LivesText.text = "0";
        }
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
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    return;
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
            isGrounded = false;
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
                if (!hasTouchedFlyingHurdle)
                {
                    SceneHandler.Instance.cam.GetComponent<CameraFollow>().StopHurdleCoroutines();
                    MenuHandler.Instance.levelCompleteHandler.gameObject.SetActive(true);
                    if (SceneHandler.Instance.platformSpawner.environmentNumber == 1)
                    {
                        int levelsEnv2 = PlayerPrefs.GetInt("LevelsOfEnvironment2", 0) + 1;
                        PlayerPrefs.SetInt("LevelsOfEnvironment2", levelsEnv2);
                    }
                    Debug.Log("Level Completed");
                }
            }
            else
            {
                MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
            }
        }
        else if (collision.transform.tag == "hurdle" && SceneHandler.Instance.isGamePlay && !HasFall)
        {
            HasFall = true;
            SceneHandler.Instance.Lives--;
            if (SceneHandler.Instance.Lives > 0)
            {
                MenuHandler.Instance.gamePlayUIHandler.LivesText.text = SceneHandler.Instance.Lives.ToString();
            }
            else
            {
                MenuHandler.Instance.gamePlayUIHandler.LivesText.text = "0";
            }
            if (SceneHandler.Instance.Lives <= 0)
            {
                die();
            }
            else
            {
                Debug.Log("Wentdown hurdle");
                WentDown();
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            isGrounded = false;
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = false; 
            transform.parent = null;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            isGrounded = true;
            //MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
            if (collision.transform.parent.gameObject.GetComponent<platformHandler>())
            {
                if (collision.transform.parent.gameObject.GetComponent<platformHandler>().playerSpawnPosition != null)
                {
                    SceneHandler.Instance.revivePlatform = collision.transform.parent.gameObject;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "fall" && SceneHandler.Instance.isGamePlay && !HasFall)
        {
            HasFall = true;
            Debug.Log("Level Fail");
            SceneHandler.Instance.Lives--;
            if (SceneHandler.Instance.Lives > 0)
            {
                MenuHandler.Instance.gamePlayUIHandler.LivesText.text = SceneHandler.Instance.Lives.ToString();
            }
            else
            {
                MenuHandler.Instance.gamePlayUIHandler.LivesText.text = "0";
            }
            if (SceneHandler.Instance.Lives <= 0)
            {
                die();
            }
            else
            {
                Debug.Log("Wentdown fall");
                WentDown();
            }
            //MenuHandler.Instance.levelFailHandler.gameObject.SetActive(true);
            //this.gameObject.SetActive(false);
        }
        else if (collision.transform.tag == "finalPoint" && SceneHandler.Instance.isGamePlay)
        {
            if (!hasTouchedFlyingHurdle)
            {
                SceneHandler.Instance.isGamePlay = false;
                if (SceneHandler.Instance.platformSpawner.environmentNumber == 1)
                {
                    int levelsEnv2 = PlayerPrefs.GetInt("LevelsOfEnvironment2", 0) + 1;
                    PlayerPrefs.SetInt("LevelsOfEnvironment2", levelsEnv2);
                }
                SoundManager.Instance.playOnce(SoundEffects.LEVELCOMPLETE);
                MenuHandler.Instance.levelCompleteHandler.gameObject.SetActive(true);
                SceneHandler.Instance.cam.GetComponent<CameraFollow>().StopHurdleCoroutines();
            }
        }
        else if (collision.transform.tag == "platform")
        {
            isGrounded = true;
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
            if (collision.transform.parent.gameObject.GetComponent<platformHandler>())
            {
                if (collision.transform.parent.gameObject.GetComponent<platformHandler>().playerSpawnPosition != null)
                {
                    SceneHandler.Instance.revivePlatform = collision.transform.parent.gameObject;
                }
                switch (collision.transform.parent.gameObject.GetComponent<platformHandler>().platformType)
                {
                    case PlatformType.BASIC:
                        break;
                    case PlatformType.MOVING:
                        Debug.Log("yes parent");
                        transform.parent = collision.transform;
                        break;
                }
            }
        }
        else if (collision.tag == "coin")
        {
            coinCollected();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            isGrounded = true;
            MenuHandler.Instance.gamePlayUIHandler.moveSlider = true;
            if (collision.transform.parent.gameObject.GetComponent<platformHandler>())
            {
                if (collision.transform.parent.gameObject.GetComponent<platformHandler>().playerSpawnPosition != null)
                {
                    SceneHandler.Instance.revivePlatform = collision.transform.parent.gameObject;
                }
            }
        }
    }

    public void die()
    {
        if (!SceneHandler.Instance.isGamePlay)
            return;
        MenuHandler.Instance.gamePlayUIHandler.gameObject.SetActive(false);
        SceneHandler.Instance.coinsBeforeFall = coinsCollected;
        rb.AddForce(Vector3.up, ForceMode2D.Impulse);
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(dieWithDelay());
    }

    IEnumerator dieWithDelay()
    {
        yield return new WaitForSeconds(2);
        MenuHandler.Instance.gamePlayUIHandler.moveSlider = false;
        MenuHandler.Instance.levelFailHandler.gameObject.SetActive(true);
        SceneHandler.Instance.cam.GetComponent<CameraFollow>().StopHurdleCoroutines();
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
    public void WentDown()
    {
        if (!SceneHandler.Instance.isGamePlay)
            return;
        SceneHandler.Instance.coinsBeforeFall = coinsCollected;
        rb.AddForce(Vector3.up, ForceMode2D.Impulse);
        GetComponent<CapsuleCollider2D>().enabled = false;
        //this.gameObject.SetActive(false);

        SceneHandler.Instance.revivePlayer();
        Destroy(this.gameObject);
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
