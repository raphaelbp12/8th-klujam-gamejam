using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    [SerializeField]
    private Image cardImage;
    [SerializeField]
    private Image backGroudImage;

    public Card scriptableCard;
    private Button button;
    private GameRules gameRules;
    private int slotIndex = -1;

    private AudioManager audioManager;

    private void Awake()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        gameRules = GameObject.FindObjectOfType<GameRules>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (gameRules.selectedSlotIndex == slotIndex)
        {
            backGroudImage.color = Color.cyan;
        }
        else
        {
            backGroudImage.color = Color.white;
        }
    }

    public void SetCardAttributes(Card card, int index)
    {
        scriptableCard = card;
        cardImage.sprite = card.Sprite;

        if (index >= 0) slotIndex = index;
    }

    public void OnClick()
    {
        audioManager.PlaySelectCard();
        gameRules.SelectCard(slotIndex);
    }
}
