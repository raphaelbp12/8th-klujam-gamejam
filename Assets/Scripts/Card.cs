using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_1", menuName = "ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{
    public enum CardType
    {
        Food,
        Shower,
        Play,
        Medicin
    }

    [SerializeField]
    private CardType _type;
    [SerializeField]
    private Sprite _sprite;

    public CardType Type => _type;
    public Sprite Sprite => _sprite;

    //public Sprite GetSprite()
    //{
    //    switch (Type) {
    //        default:
    //        case CardType.Food:     return CardAssets.Instance.foodCardSprite;
    //        case CardType.Shower:   return CardAssets.Instance.showerCardSprite;
    //        case CardType.Play:     return CardAssets.Instance.playCardSprite;
    //        case CardType.Medicin:  return CardAssets.Instance.medicinCardSprite;
    //    }
    //}
}
