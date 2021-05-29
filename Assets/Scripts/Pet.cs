using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
                    NeedType = Card.CardType.Medicin
                }
            }
            );
    }

    private void Update()
    {
        DecreaseHappinessOverTime();

        CalculateNeed();
    }

    private void FixedUpdate()
    {
        _progressBar.SetBarValue(_happiness);
    }

    private void CalculateNeed()
    {
        _currentNeed = _needs.OrderBy(e => e.Happiness).First();
    }

    private void DecreaseHappinessOverTime()
    {
        foreach (var need in _needs)
        {
            need.Happiness -= Time.deltaTime;
        }

        _happiness = _needs.Sum(e => e.Happiness) / (_needs.Count() * _maxNeedIndex);
    }

    public void GetCard(Card card)
    {
        print($"Pet {gameObject.name} GetCard {card.name}");
        if (_currentNeed == null) return;
    }

    class Need
    {
        public Card.CardType NeedType { get; set; }
        public float Happiness { get; set; }
    }
}
