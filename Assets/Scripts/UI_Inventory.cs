using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        foreach (var card in gameRules.inventory.cardList)
        {
            GameObject cardGameObject = Instantiate(cardSlotPrefab, cardSlotContainer.transform);
            CardSlot cardSlot = cardGameObject.GetComponent<CardSlot>();
            cardSlot.SetCardAttributes(card);
        }
    }

    public void RefreshInventoryItems()
    {
        CardSlot[] cardSlots = gameObject.GetComponents<CardSlot>();

        for(int i = 0; i < cardSlots.Length; i++)
        {
            CardSlot cardSlot = cardSlots[i];

            cardSlot.SetCardAttributes(gameRules.inventory.cardList[i]);
        }
    }
}
