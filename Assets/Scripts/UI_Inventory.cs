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

    private void Awake()
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

        for(int i = 0; i < inventory.GetCardList().Count; i++)
        {
            Card card = inventory.GetCardList()[i];
            RectTransform itemSlotRectTransform = Instantiate(cardSlotTemplate, cardSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<ButtonHandler>().ClickFunc = () =>
            {
                Debug.Log("Click button " + i.ToString());
                gameRules.SelectCard(i);
            };

            Image backgroundImage = cardSlotTemplate.Find("Background").GetComponent<Image>();

            Debug.Log("SelectedCardIndex " + i.ToString());
            if (gameRules.SelectedCardIndex == i)
            {
                backgroundImage.color = new Color(0, 0, 0);
            } else
            {
                backgroundImage.color = new Color(1, 0, 0);
            }

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
