using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    [Header("Spawn Configurations")]
    [SerializeField]
    private float _cdwToStay = 2;
    [SerializeField]
    private int _weigthToSpawn = 1;

    [Header("Config")]
    [Tooltip("Used to change the amout of maximum happines this pet has")]
    [SerializeField]
    private float _maxNeedIndex = 15f;
    [Range(0, 1)]
    [SerializeField]
    private float _minimumStartPercentage = 0.5f;

    [Header("Config")]
    [SerializeField]
    private Image iconImage;

    public float CdwToStay => _cdwToStay;
    public int WeigthToSpawn => _weigthToSpawn;

    private float _happiness;

    private List<Need> _needs = new List<Need>();
    private BarBehaviour _progressBar;
    private Need _currentNeed;

    private void Start()
    {
        InitializeNeedList();
        _progressBar = this.GetComponentInChildren<BarBehaviour>();
        CalculateNeed();
    }

    private void InitializeNeedList()
    {
        _needs.AddRange(
            new List<Need>()
            {
                new Need()
                {
                    Happiness = UnityEngine.Random.Range(_maxNeedIndex*_minimumStartPercentage, _maxNeedIndex),
                    NeedType = Card.CardType.Food
                },
                new Need()
                {
                    Happiness = UnityEngine.Random.Range(_maxNeedIndex*_minimumStartPercentage, _maxNeedIndex),
                    NeedType = Card.CardType.Shower
                },
                new Need()
                {
                    Happiness = UnityEngine.Random.Range(_maxNeedIndex*_minimumStartPercentage, _maxNeedIndex),
                    NeedType = Card.CardType.Play
                },
                new Need()
                {
                    Happiness = UnityEngine.Random.Range(_maxNeedIndex*_minimumStartPercentage, _maxNeedIndex),
                    NeedType = Card.CardType.Medicine
                }
            }
            );
    }

    private void Update()
    {
        DecreaseHappinessOverTime();
    }

    private void FixedUpdate()
    {
        _progressBar.SetBarValue(_happiness);
    }

    private void CalculateNeed()
    {
        int randomIndex = UnityEngine.Random.Range(0, _needs.Count);
        _currentNeed = _needs[randomIndex];

        iconImage.sprite = GetNeedSprite(_currentNeed.NeedType);
    }

    private Sprite GetNeedSprite(Card.CardType cardType)
    {
        return GameRules.GetCardSprite(cardType);
    }

    private void DecreaseHappinessOverTime()
    {
        foreach (var need in _needs)
        {
            need.Happiness -= Time.deltaTime;
        }

        _happiness = _needs.Sum(e => e.Happiness) / (_needs.Count() * _maxNeedIndex);
    }

    public bool GetCard(Card card)
    {
        if (_currentNeed == null) return false;

        bool isValidCard = card.Type == Card.CardType.Time || card.Type == _currentNeed.NeedType;

        if (!isValidCard) return false;

        switch (card.Type)
        {
            case Card.CardType.Empty:
                break;
            case Card.CardType.Food:
                _cdwToStay += 10;
                break;
            case Card.CardType.Shower:
                break;
            case Card.CardType.Play:
                break;
            case Card.CardType.Medicine:
                break;
            case Card.CardType.Time:
                _cdwToStay += 5;
                break;
            default:
                break;
        }

        if (card.Type != Card.CardType.Time) CalculateNeed();
        return true;
    }

    class Need
    {
        public Card.CardType NeedType { get; set; }
        public float Happiness { get; set; }
    }
}
