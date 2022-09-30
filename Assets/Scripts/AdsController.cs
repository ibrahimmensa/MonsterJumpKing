using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class AdsController : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestBanner();
        RequestAndLoadInterstitial();
        RequestAndLoadRewarded();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-1778345177688333/6091186196";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-1778345177688333/3241661575";
#endif

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }


    public void RequestAndLoadInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1778345177688333/2200042645";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-1778345177688333/8810479181";
#endif

        interstitialAd = new InterstitialAd(adUnitId);
        interstitialAd.LoadAd(CreateAdRequest());
    }
    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }



    public void RequestAndLoadRewarded()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1778345177688333/7943323915";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-1778345177688333/2742968129";
#endif

        rewardedAd = new RewardedAd(adUnitId);
        rewardedAd.LoadAd(CreateAdRequest());
    }
    public void ShowRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Show();
        }
    }



    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();
    }
}
