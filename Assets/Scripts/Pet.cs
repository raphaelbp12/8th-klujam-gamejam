using System;
using System.Collections;
using System.Collections.Generic;
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

    private void OnValidate()
    {
        foreach (PetNeed petNeed in _needs)
        {
            petNeed.name = petNeed.Type.ToString();


        }
    }

    public void GetCard(Card card)
    {

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
    private int _weightToChoose;


    public Card.CardType Type => _type;
}
