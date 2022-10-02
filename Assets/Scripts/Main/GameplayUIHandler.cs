using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIHandler : MonoBehaviour
{
    public Slider powerSlider;
    public Text gemCount;
    public Text coinCount;
    public bool moveSlider = false;
    public float sliderMinValue, sliderMaxValue, sliderSpeed, jumpPower;
    public bool increaseSlider = false, decreaseSlider = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        increaseSlider = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(powerSlider.value);
        if (moveSlider)
        {
            if (increaseSlider)
            {
                powerSlider.value += sliderSpeed;
                if (powerSlider.value >= sliderMaxValue)
                {
                    increaseSlider = false;
                    decreaseSlider = true;
                }
            }
            else if (decreaseSlider)
            {
                powerSlider.value -= sliderSpeed;
                if (powerSlider.value <= sliderMinValue)
                {
                    increaseSlider = true;
                    decreaseSlider = false;
                }
            }
        }
        jumpPower = 100 - Mathf.Abs(powerSlider.value);
    }

    public void onClickPause()
    {
        MenuHandler.Instance.pauseMenuHandler.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}