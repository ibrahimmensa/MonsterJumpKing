using System;
using UnityEngine;
using UnityEngine.UI;


public class DailyRewardsHandler : MonoBehaviour
{
    public double msToWait;
    public Button CollectButton;
    private ulong lastTimeClicked;

    public Image[] RewardCards;
    public Sprite selectedSprite;
    public Sprite UnSelectedSprite;
    public GameObject RewardGivenPanel;
    public TMPro.TMP_Text rewardGivenText;

    public Image RewardReadyEffect;

    int selectedReward;

    private void Start()
    {
        //86400000 one day in milli seconds
        selectedReward = PlayerPrefs.GetInt("SelectedReward", -1);
        if (selectedReward >= 0)
        {
            foreach (Image img in RewardCards)
                img.sprite = UnSelectedSprite;
            RewardCards[selectedReward].sprite = selectedSprite;
        }
        bool canBuyPlayer = false;
        for (int i = 1; i < 9; i++)
        {
            if (PlayerPrefs.GetString(i.ToString(), "false") == "false")
            {
                canBuyPlayer = true;
            }
        }
        if (PlayerPrefs.GetInt("PlayerRewarded", 0) == 1 || !canBuyPlayer)
        {
            RewardCards[6].transform.Find("PlayerImage").gameObject.SetActive(false);
            RewardCards[6].transform.Find("Text").gameObject.SetActive(false);
            RewardCards[6].transform.Find("CoinsImage").gameObject.SetActive(true);
            RewardCards[6].transform.Find("AmountText").gameObject.SetActive(true);
        }

        lastTimeClicked = ulong.Parse(PlayerPrefs.GetString("LastTimeClicked"));

        if (PlayerPrefs.GetInt("RewardCollected", 0) == 1)
        {
            CollectButton.interactable = false;
            RewardReadyEffect.enabled = false;
        }

        if (!Ready())
        {
            if (PlayerPrefs.GetInt("RewardCollected", 0) == 1)
            {
                CollectButton.interactable = false;
                RewardReadyEffect.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (Ready())
        {
            CollectButton.interactable = true;
            RewardReadyEffect.enabled = true;
            return;
        }
    }

    public void ClickToCollectReward()
    {
        CollectButton.interactable = false;
        RewardReadyEffect.enabled = false;
        //give reward

        PlayerPrefs.SetInt("RewardCollected", 1);

        RewardGivenPanel.SetActive(true);

        if (selectedReward == 0)
        {
            int totalCoins;
            totalCoins = PlayerPrefs.GetInt("Coins", 0) + 200;
            PlayerPrefs.SetInt("Coins", totalCoins);
            MenuHandler.Instance.mainMenu.updateStats();
            rewardGivenText.text = "You got 200 coins!";
        }
        else if (selectedReward == 1)
        {
            int totalGems;
            totalGems = PlayerPrefs.GetInt("Gems", 0) + 5;
            PlayerPrefs.SetInt("Gems", totalGems);
            MenuHandler.Instance.mainMenu.updateStats();
            rewardGivenText.text = "You got 5 gems!";
        }
        else if (selectedReward == 2)
        {
            int totalCoins;
            totalCoins = PlayerPrefs.GetInt("Coins", 0) + 400;
            PlayerPrefs.SetInt("Coins", totalCoins);
            MenuHandler.Instance.mainMenu.updateStats();
            rewardGivenText.text = "You got 400 coins!";
        }
        else if (selectedReward == 3)
        {
            int totalCoins;
            totalCoins = PlayerPrefs.GetInt("Coins", 0) + 600;
            PlayerPrefs.SetInt("Coins", totalCoins);
            MenuHandler.Instance.mainMenu.updateStats();
            rewardGivenText.text = "You got 600 coins!";
        }
        else if (selectedReward == 4)
        {
            int totalGems;
            totalGems = PlayerPrefs.GetInt("Gems", 0) + 8;
            PlayerPrefs.SetInt("Gems", totalGems);
            MenuHandler.Instance.mainMenu.updateStats();
            rewardGivenText.text = "You got 8 gems!";
        }
        else if (selectedReward == 5)
        {
            int totalCoins;
            totalCoins = PlayerPrefs.GetInt("Coins", 0) + 800;
            PlayerPrefs.SetInt("Coins", totalCoins);
            MenuHandler.Instance.mainMenu.updateStats();
            rewardGivenText.text = "You got 800 coins!";
        }
        else if (selectedReward == 6)
        {

            if (PlayerPrefs.GetInt("PlayerRewarded", 0) == 0)
            {
                for (int i = 1; i < 9; i++)
                {
                    if (PlayerPrefs.GetString(i.ToString(), "false") == "false")
                    {
                        PlayerPrefs.SetString(i.ToString(), "true");
                        PlayerPrefs.SetInt("PlayerRewarded", 1); 
                        RewardCards[6].transform.Find("PlayerImage").gameObject.SetActive(false);
                        RewardCards[6].transform.Find("Text").gameObject.SetActive(false);
                        RewardCards[6].transform.Find("CoinsImage").gameObject.SetActive(true);
                        RewardCards[6].transform.Find("AmountText").gameObject.SetActive(true);
                        rewardGivenText.text = "You got 1 free player!";
                        break;
                    }
                }
            }
            else
            {
                int totalCoins;
                totalCoins = PlayerPrefs.GetInt("Coins", 0) + 1000;
                PlayerPrefs.SetInt("Coins", totalCoins);
                MenuHandler.Instance.mainMenu.updateStats();
                rewardGivenText.text = "You got 1000 coins!";
            }
        }
        selectedReward++;
        if (selectedReward > 6)
            selectedReward = 0;
        PlayerPrefs.SetInt("SelectedReward", selectedReward);
        foreach (Image img in RewardCards)
            img.sprite = UnSelectedSprite;
        RewardCards[selectedReward].sprite = selectedSprite;
    }

    private bool Ready()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeClicked);
        ulong m = diff / TimeSpan.TicksPerMillisecond;

        float secondsLeft = (float)(msToWait - m) / 1000.0f;

        if (secondsLeft < 0)
        {
            //DO SOMETHING WHEN TIMER IS FINISHED
            lastTimeClicked = (ulong)DateTime.Now.Ticks;
            PlayerPrefs.SetString("LastTimeClicked", lastTimeClicked.ToString());
            PlayerPrefs.DeleteKey("RewardCollected");
            if (CollectButton.interactable)
            {
                selectedReward=0;
                PlayerPrefs.SetInt("SelectedReward", selectedReward);
                foreach (Image img in RewardCards)
                    img.sprite = UnSelectedSprite;
                RewardCards[selectedReward].sprite = selectedSprite;
            }
            return true;
        }

        return false;
    }

    public void onClickBackDailyRewardScreen()
    {
        SoundManager.Instance.playOnce(SoundEffects.BUTTONCLICK);
        MenuHandler.Instance.switchMenu(MenuStates.MAINMENU);
    }
}



