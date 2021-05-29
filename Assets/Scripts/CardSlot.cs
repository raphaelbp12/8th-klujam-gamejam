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


    private void Awake()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        gameRules = GameObject.FindObjectOfType<GameRules>();
        gameRules.AddCardToInventory(this);
    }

    public void SetCardAttributes(Card card)
    {
        scriptableCard = card;

        cardImage.sprite = card.Sprite;
    }

    public void OnClick()
    {
        gameRules.SelectCard(this);
        backGroudImage.color = Color.black;
    }
    public void OnDestroy()
    {
        gameRules.RemoveFromInventory(this);
    }

    public void UnselectCard()
    {
        backGroudImage.color = Color.white;
    }

}
