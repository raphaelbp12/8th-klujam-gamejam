using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] Transform cardSlotContainer;
    [SerializeField] GameObject cardSlotPrefab;


    private GameRules gameRules;

    private void Awake()
    {
        gameRules = GameObject.FindObjectOfType<GameRules>();
    }

    public void InitInventoryItems()
    {
        for (int i = 0; i < gameRules.inventory.cardList.Count; i++)
        {
            Card card = gameRules.inventory.cardList[i];
            GameObject cardGameObject = Instantiate(cardSlotPrefab, cardSlotContainer.transform);
            CardSlot cardSlot = cardGameObject.GetComponent<CardSlot>();
            cardSlot.SetCardAttributes(card, i);
        }
    }

    public void RefreshInventoryItems()
    {
        CardSlot[] cardSlots = gameObject.GetComponentsInChildren<CardSlot>();

        for(int i = 0; i < cardSlots.Length; i++)
        {
            CardSlot cardSlot = cardSlots[i];
            cardSlot.SetCardAttributes(gameRules.inventory.cardList[i], -1);
        }
    }
}
