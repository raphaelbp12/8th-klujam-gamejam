using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Card> cards;

    public Inventory()
    {
        cards = new List<Card>();

        AddCard(new Card { cardType = Card.CardType.Food });
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }
}
