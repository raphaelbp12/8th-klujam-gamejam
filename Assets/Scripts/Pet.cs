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
    private float _cdwToStay = 5;
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

    public float _cooldownIncreased { get; private set; } = 0;

    private List<Need> _needs = new List<Need>();
    private BarBehaviour _progressBar;
    private Need _currentNeed;


    private GameRules gameRules;

    private void Awake()
    {
        gameRules = GameObject.FindObjectOfType<GameRules>();
    }

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
        return gameRules.GetCardSprite(cardType);
    }

    private void DecreaseHappinessOverTime()
    {
        foreach (var need in _needs)
        {
            need.Happiness -= Time.deltaTime;
        }

        _happiness = _needs.Sum(e => e.Happiness) / (_needs.Count() * _maxNeedIndex);
    }

    public bool UseCard(Card card)
    {
        if (_currentNeed == null) return false;

        bool isValidCard = card.Type == Card.CardType.Time || card.Type == _currentNeed.NeedType;

        if (!isValidCard) return false;

        float effectAmount = 30f;

        switch (card.Type)
        {
            case Card.CardType.Empty:
                break;
            case Card.CardType.Food:
                _cooldownIncreased += 10;
                break;
            case Card.CardType.Shower:
                break;
            case Card.CardType.Play:
                break;
            case Card.CardType.Medicine:
                break;
            case Card.CardType.Time:
                _cooldownIncreased += 5;
                break;
            default:
                break;
        }

        UseCardEffect(card.Type, effectAmount);
        if (card.Type != Card.CardType.Time) CalculateNeed();
        return true;
    }

    private void UseCardEffect(Card.CardType cardType, float amount)
    {
        foreach (var need in _needs)
        {
            if (need.NeedType == cardType)
            {
                need.Happiness += amount;
            }
        }
    }

    public void ResetCooldownIncreased()
    {
        _cooldownIncreased = 0;
    }

    class Need
    {
        public Card.CardType NeedType { get; set; }
        public float Happiness { get; set; }
    }
}
