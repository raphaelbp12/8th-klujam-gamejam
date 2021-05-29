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
        gameRules = GameObject.FindObjectOfType<GameRules>();
    }

    private void Update()
    {
        int instanceId = gameObject.GetInstanceID();

        if (gameRules.selectedSlotInstanceId == instanceId)
        {
            backGroudImage.color = Color.cyan;
        }
        else
        {
            backGroudImage.color = Color.white;
        }
    }

    public void SetCardAttributes(Card card)
    {
        scriptableCard = card;
        cardImage.sprite = card.Sprite;
    }

    public void OnClick()
    {
        gameRules.SelectCard(gameObject.GetInstanceID());
    }
}
