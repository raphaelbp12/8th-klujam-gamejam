using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    public List<Card> initalCards;

    [SerializeField]
    private UI_Inventory uiInventory;

    //private RectTransform selectedItemSlotRectTransform;
    [SerializeField]
    private Inventory inventory;
    //public int SelectedCardIndex = -1;


    private CardSlot selectedSlot = null;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    internal void AddCardToInventory(CardSlot cardSlot)
    {
        inventory.CardsSlot.Add(cardSlot);
    }

    public void SelectCard(CardSlot selectedSlot)
    {
        this.selectedSlot = selectedSlot;

        print($"A carta {selectedSlot.scriptableCard.name} foi selecionada!");
        foreach (var cardSlot in inventory.CardsSlot)
        {
            if (cardSlot.gameObject.GetInstanceID() == selectedSlot.gameObject.GetInstanceID()) continue;

            cardSlot.UnselectCard();
        }
    }

    internal void RemoveFromInventory(CardSlot cardSlot)
    {
        inventory.CardsSlot.Remove(cardSlot);
    }
}
