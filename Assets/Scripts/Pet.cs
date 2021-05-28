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

    [Space]
    [SerializeField]
    private List<PetNeed> _needs;

    public float CdwToStay => _cdwToStay;
    public int WeigthToSpawn => _weigthToSpawn;

    private Coroutine _needProcess = null;

    private void Start()
    {
        StartNeedProcess();
    }

    private void OnValidate()
    {
        foreach (var need in _needs)
        {
            need.name = need.Type.ToString();
        }
    }

    public void GetCard(Card card)
    {

    }

    private PetNeed GetRandomNeed()
    {
        int totalWeight = _needs.Sum(e => e.WeightToNeed);
        int randomNumber = UnityEngine.Random.Range(1, totalWeight);

        int count = 0;
        foreach (var petNeed in _needs)
        {
            count += petNeed.WeightToNeed;
            if (randomNumber <= count)
            {
                return petNeed;
            }
        }

        return _needs.FirstOrDefault();
    }

    private void StartNeedProcess()
    {
        _needProcess = StartCoroutine(NeedProcess());
    }

    IEnumerator NeedProcess()
    {
        PetNeed need = GetRandomNeed();
        print($"I({this.name}) need {need.Type}");
        yield return new WaitForSeconds(need.CdwNeeding);

        StartNeedProcess();
    }

}
[Serializable]
public class PetNeed
{
    [HideInInspector]
    public string name;

    [SerializeField]
    private Card.CardType _type;
    [SerializeField]
    private float _cdwNeeding;
    [SerializeField]
    private int _weightToNeed;


    public Card.CardType Type => _type;

    public float CdwNeeding => _cdwNeeding;
    public int WeightToNeed => _weightToNeed;
}
