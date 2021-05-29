using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    private RectTransform selectedItemSlotRectTransform;

    private Inventory inventory;

    public int SelectedCardIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    public void SelectCard(int selectedCard)
    {
        SelectedCardIndex = selectedCard;
    }

    public void SelectCard(RectTransform itemSlotRectTransform)
    {
        selectedItemSlotRectTransform = itemSlotRectTransform;
    }
}
