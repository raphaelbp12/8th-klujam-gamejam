using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_1", menuName = "ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{
    public enum CardType
    {
        Empty,
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
}
