using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Inventory
{
    public int numOfCards = 4;

    public List<Card> cardList = new List<Card>();

    private List<Card> _cardTypes;

    public Inventory(Card[] allCardTypes)
    {
        _cardTypes = allCardTypes.ToList();

        for (int i = 0; i < numOfCards; i++)
        {
            cardList.Add(GetRandomCardType());
        }
    }

    private Card GetRandomCardType()
    {
        int randomIndex = UnityEngine.Random.Range(0, _cardTypes.Count);
        return _cardTypes[randomIndex];
    }
}
