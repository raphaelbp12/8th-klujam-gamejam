using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField]
    private float _cdwToStay = 2;
    [SerializeField]
    private int _weigthToSpawn = 1;

    public float CdwToStay => _cdwToStay;
    public int WeigthToSpawn => _weigthToSpawn;
}
