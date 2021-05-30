using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour, IPointerClickHandler
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

    private bool canChangeCard = true;
    private float changeCardCooldownTime = 10f;

    private void Awake()
    {
        button = this.GetComponent<Button>();
        gameRules = GameObject.FindObjectOfType<GameRules>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (gameRules.selectedSlotIndex == slotIndex)
        {
            backGroudImage.color = Color.cyan;
        }
        else if (!canChangeCard)
        {
            backGroudImage.color = Color.grey;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            audioManager.PlaySelectCard();
            gameRules.SelectCard(slotIndex);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (!canChangeCard) return;

            gameRules.inventory.ChangeCardOnSlot(slotIndex);
            audioManager.PlaySelectCard();
            canChangeCard = false;
            StartCoroutine(UnlockChangeCard());
        }
    }

    IEnumerator UnlockChangeCard()
    {
        yield return new WaitForSeconds(changeCardCooldownTime);
        canChangeCard = true;
    }
}
