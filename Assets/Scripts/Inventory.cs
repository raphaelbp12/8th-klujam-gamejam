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
        AddCard(new Card { cardType = Card.CardType.Shower });
        AddCard(new Card { cardType = Card.CardType.Medicin });
        AddCard(new Card { cardType = Card.CardType.Play });
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public List<Card> GetCardList()
    {
        return cards;
    }
}
