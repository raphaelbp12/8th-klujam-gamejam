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

    public event Action<Card> ValidCardUsed;
    public event Action<Card> InvalidCardUsed;

    public float CdwToStay => _cdwToStay;
    public int WeigthToSpawn => _weigthToSpawn;

    private float _happiness;

    public float _cooldownIncreased { get; private set; } = 0;

    private List<Need> _needs = new List<Need>();
    private BarBehaviour _progressBar;
    private Need _currentNeed;
    private AudioManager _audioManager;
    private GameRules gameRules;

    private void Awake()
    {
        gameRules = GameObject.FindObjectOfType<GameRules>();
        _audioManager = GameObject.FindObjectOfType<AudioManager>();
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
        _currentNeed = _needs.OrderBy(e => e.Happiness).First();
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
            if (need.Happiness - Time.deltaTime < 0)
            {
                need.Happiness = 0;
            } else
            {
                need.Happiness -= Time.deltaTime;
            }
        }

        _happiness = _needs.Sum(e => e.Happiness) / (_needs.Count() * _maxNeedIndex);
    }

    public bool UseCard(Card card)
    {
        if (_currentNeed == null) return false;

        bool isValidCard = card.Type == Card.CardType.Time || card.Type == _currentNeed.NeedType;

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

        if (!isValidCard)
        {
            _audioManager.PlayBadCard();
            InvalidCardUsed?.Invoke(card);
            UseCardEffect(card.Type, -1 * effectAmount / 2);
        }
        else
        {
            _audioManager.PlayGoodCard();
            ValidCardUsed?.Invoke(card);
            UseCardEffect(card.Type, effectAmount);
        }
        if (card.Type != Card.CardType.Time) CalculateNeed();
        return true;
    }

    private void UseCardEffect(Card.CardType cardType, float amount)
    {
        foreach (var need in _needs)
        {
            if (need.NeedType == cardType)
            {
                if (need.Happiness + amount < 0)
                {
                    need.Happiness = 0;
                } else if (need.Happiness + amount > _maxNeedIndex)
                {
                    need.Happiness = _maxNeedIndex;
                } else
                {
                    need.Happiness += amount;
                }
            }
        }
    }

    public void ResetCooldownIncreased()
    {
        _cooldownIncreased = 0;
    }

    public float GetHappiness(){
        return _happiness/_maxNeedIndex;
    }

    class Need
    {
        public Card.CardType NeedType { get; set; }
        public float Happiness { get; set; }
    }
}
