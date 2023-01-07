using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class InappListener : MonoBehaviour
{
    public static InappListener instance;

    public string[] nonConsumableProductIds;

    public bool[] nonConsumableItemsUnlocked;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForIAPInitialization());
    }

    IEnumerator waitForIAPInitialization()
    {
        while (!CodelessIAPStoreListener.initializationComplete)
        {
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log("initialization Complete.........");
        for (int i = 0; i < nonConsumableProductIds.Length; i++)
        {
            CheckProductPurchased(nonConsumableProductIds[i]);
        }
        SplashScreenManager.Instance.canLoadNextScene = true;
    }

    public void CheckProductPurchased(string productId)
    {
        if (CodelessIAPStoreListener.Instance.StoreController != null)
        {
            Debug.Log("checking for reciepts.........");
            Product product = CodelessIAPStoreListener.Instance.StoreController.products.WithID(productId);
            if (product != null && product.hasReceipt)
            {
                Debug.Log("unlocking product");
                //unlock products
                if (productId == nonConsumableProductIds[0])
                {
                    nonConsumableItemsUnlocked[0] = true;
                }
                else if (productId == nonConsumableProductIds[1])
                {
                    nonConsumableItemsUnlocked[1] = true;
                }
                else if (productId == nonConsumableProductIds[2])
                {
                    nonConsumableItemsUnlocked[2] = true;
                }
            }
        }
    }

    public void OnPurchaseComplete(Product p)
    {
        if (p.definition.id == nonConsumableProductIds[0])
        {
            nonConsumableItemsUnlocked[0] = true;
        }
        else if (p.definition.id == nonConsumableProductIds[1])
        {
            nonConsumableItemsUnlocked[1] = true;
        }
        else if (p.definition.id == nonConsumableProductIds[2])
        {
            nonConsumableItemsUnlocked[2] = true;
        }
    }
}
