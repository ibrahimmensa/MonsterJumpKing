using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class GoogleAdsManager : Singleton<GoogleAdsManager>
{
    private BannerView bannerView;
    public List<BannerView> allBanners= new List<BannerView>();

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        Debug.Log("google ads working");

        if (PlayerPrefs.GetInt("AdsRemoved", 0) == 0)
            this.RequestBanner();
        //RequestInterstitial();
    }

    #region Banner
    public void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9962568154534727/1191474429";
#elif UNITY_IOS
        string adUnitId = "ca-app-pub-9962568154534727/1776963632";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);

        allBanners.Add(this.bannerView);
    }

    public void destroyBanner()
    {
        if(bannerView!=null)
            bannerView.Destroy();
    }

    public void destroyAllBanners()
    {
        while(allBanners.Count>0)
        {
            BannerView temp = allBanners[0];
            allBanners.RemoveAt(0);
            temp.Destroy();
        }
    }
    #endregion

    #region Interstitial
//    private InterstitialAd interstitial;

//    private void RequestInterstitial()
//    {
//#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
//#elif UNITY_IPHONE
//        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
//#else
//        string adUnitId = "unexpected_platform";
//#endif

//        // Initialize an InterstitialAd.
//        this.interstitial = new InterstitialAd(adUnitId);

//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();
//        // Load the interstitial with the request.
//        this.interstitial.LoadAd(request);

//        // Called when an ad request has successfully loaded.
//        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
//        // Called when an ad request failed to load.
//        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
//        // Called when an ad is shown.
//        this.interstitial.OnAdOpening += HandleOnAdOpening;
//        // Called when the ad is closed.
//        this.interstitial.OnAdClosed += HandleOnAdClosed;
//    }

//    public void showInterstitial()
//    {

//        if (PlayerPrefs.GetInt("AdsRemoved", 0) == 0)
//            if (this.interstitial.IsLoaded())
//            {
//                this.interstitial.Show();
//            }
//    }


//    public void HandleOnAdLoaded(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdLoaded event received");
//    }

//    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//    {
//        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
//                            + args.ToString());
//    }

//    public void HandleOnAdOpening(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdOpening event received");
//    }

//    public void HandleOnAdClosed(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdClosed event received");
//        RequestInterstitial();
//    }
    #endregion
}
