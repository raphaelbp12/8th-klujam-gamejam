using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] Transform cardSlotContainer;
    [SerializeField] Transform cardSlotTemplate;

    private GameRules gameRules;

    private void Start()
    {
        gameRules = GameObject.FindObjectOfType<GameRules>();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 110f;

        foreach(Card card in inventory.GetCardList())
        {
            RectTransform itemSlotRectTransform = Instantiate(cardSlotTemplate, cardSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<ButtonHandler>().ClickFunc = () =>
            {
                gameRules.SelectCard(itemSlotRectTransform);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("CardImage").GetComponent<Image>();
            image.sprite = card.GetSprite();
            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
