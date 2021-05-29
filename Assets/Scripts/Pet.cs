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

    //[Space]
    //[SerializeField]
    //private List<PetNeed> _needs;

    public float CdwToStay => _cdwToStay;
    public int WeigthToSpawn => _weigthToSpawn;

    private const float MAX_VALUE_NEED = 1f;

    private float _happiness;

    private List<Need> _needs = new List<Need>();

    private Need _currentNeed;

    private void Start()
    {
        _needs.AddRange(
            new List<Need>()
            {
                new Need()
                {
                    Happiness = UnityEngine.Random.Range(0, MAX_VALUE_NEED),
                    NeedType = Card.CardType.Food
                },
                new Need()
                {
                    Happiness = UnityEngine.Random.Range(0, MAX_VALUE_NEED),
                    NeedType = Card.CardType.Shower
                },
                new Need()
                {
                    Happiness = UnityEngine.Random.Range(0, MAX_VALUE_NEED),
                    NeedType = Card.CardType.Play
                },
                new Need()
                {
                    Happiness = UnityEngine.Random.Range(0, MAX_VALUE_NEED),
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
        //TODO: Chamar Barra
    }

    private void CalculateNeed()
    {
        _currentNeed = _needs.OrderBy(e => e.Happiness).First();

        print($"I need  {_currentNeed.NeedType}");
    }

    private void DecreaseHappinessOverTime()
    {
        foreach (var need in _needs)
        {
            need.Happiness -= Time.deltaTime;
        }

        _happiness = _needs.Sum(e => e.Happiness) / (_needs.Count() * MAX_VALUE_NEED);
    }

    public void GetCard(Card card)
    {
        if (_currentNeed == null) return;



    }

    class Need
    {
        public Card.CardType NeedType { get; set; }
        public float Happiness { get; set; }
    }
}
