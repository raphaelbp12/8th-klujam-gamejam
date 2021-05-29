using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    [SerializeField]
    public List<CardSlot> _cardSlot;
    public List<CardSlot> CardsSlot { get { return _cardSlot; } set { _cardSlot = value; } }

    public Inventory()
    {
        CardsSlot = new List<CardSlot>();
    }

}
