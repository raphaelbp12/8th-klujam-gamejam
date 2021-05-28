using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    private RectTransform selectedItemSlotRectTransform;

    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCard(RectTransform itemSlotRectTransform)
    {
        selectedItemSlotRectTransform = itemSlotRectTransform;
    }
}
