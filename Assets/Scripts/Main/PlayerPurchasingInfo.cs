using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPurchasingData", menuName = "ScriptableObjects/PlayerPurchasingInfo", order = 1)]
public class PlayerPurchasingInfo : ScriptableObject
{
    public SinglePlayerInfo[] playersInfo;
}

[System.Serializable]
public class SinglePlayerInfo
{
    public bool isBought;
    public int noOfAdsToWatchInTotal;
    public int noOfAdsWatched;
}
