using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Inventory
{
    public int numOfCards = 7;

    public List<Card> cardList { get; private set; } = new List<Card>();

    private List<Card> _cardTypes;
    private UI_Inventory uiInventory;

    public Inventory(List<Card> allCardTypes, UI_Inventory uiInventory)
    {
        this.uiInventory = uiInventory;

        _cardTypes = allCardTypes;

        for (int i = 0; i < numOfCards; i++)
        {
            cardList.Add(GetRandomCardType());
        }
    }

    public void Start()
    {
        uiInventory.InitInventoryItems();
    }

    public Card GetCardInSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex > cardList.Count - 1) return null;
        return cardList[slotIndex];
    }

    public void ChangeCardOnSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex > cardList.Count - 1) return;
        cardList[slotIndex] = GetRandomCardType();
        uiInventory.RefreshInventoryItems();
    }

    private Card GetRandomCardType()
    {
        int randomIndex = UnityEngine.Random.Range(1, _cardTypes.Count); //skip the first card, the empty one
        return _cardTypes[randomIndex];
    }
}
