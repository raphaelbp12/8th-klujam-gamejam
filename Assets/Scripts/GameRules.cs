using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour
{
    [SerializeField]
    private UI_Inventory uiInventory;
    [SerializeField]
    public List<Card> scriptableCardList = new List<Card>();

    [SerializeField]
    private GameObject youLoseScreen;
    [SerializeField]
    private GameObject youWinScreen;

    public int selectedSlotIndex { get; private set; } = -1;

    public Inventory inventory;
    
    private void Awake()
    {
        inventory = new Inventory(scriptableCardList, uiInventory);
    }

    void Start()
    {
        inventory.Start();
    }

    public void SelectCard(int index)
    {
        this.selectedSlotIndex = index;
    }

    public void SelectPet(Pet petSelected)
    {
        if (petSelected == null || selectedSlotIndex < 0) return;

        Card selectedCard = inventory.GetCardInSlot(selectedSlotIndex);
        bool isValidCard = petSelected.UseCard(selectedCard);

        if (!isValidCard) return;

        inventory.ChangeCardOnSlot(selectedSlotIndex);
        this.selectedSlotIndex = -1;
    }

    public Sprite GetCardSprite(Card.CardType cardType)
    {
        var allCards = scriptableCardList; // get all scriptable objects

        foreach (var card in allCards)
        {
            if (cardType == card.Type)
            {
                return card.Sprite;
            }
        }

        return null;
    }

    public void GameOver(bool win)
    {
        if (win)
        {
            youWinScreen.SetActive(true);
        }
        else
        {
            youLoseScreen.SetActive(true);
        }
    }

    public void OnPLayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
