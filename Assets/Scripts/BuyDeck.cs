﻿using UnityEngine;
using UnityEngine.Purchasing;

public class BuyDeck : MonoBehaviour
{
    [SerializeField] public Deck buyableDeck;
    [SerializeField] public string productId;

    private void Start()
    {
        if (PurchasesManager.CheckPurchaseState(productId))
            OnPurchaseComplete();
    }

    public void OnPurchaseComplete()
    {
        DeckSelectionManager.Instance.AddDeck(buyableDeck);
        gameObject.SetActive(false);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError("Purchase of product: " + product.definition.id + " failed because " + failureReason);
    }
}
