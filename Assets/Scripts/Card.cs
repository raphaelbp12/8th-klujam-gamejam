using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardType
    {
        Food,
        Shower,
        Play,
        Medicin
    }

    public CardType cardType { get; set; }

    public Sprite GetSprite()
    {
        switch (cardType) {
            default:
            case CardType.Food:     return CardAssets.Instance.foodCardSprite;
            case CardType.Shower:   return CardAssets.Instance.showerCardSprite;
            case CardType.Play:     return CardAssets.Instance.playCardSprite;
            case CardType.Medicin:  return CardAssets.Instance.medicinCardSprite;
        }
    }
}
