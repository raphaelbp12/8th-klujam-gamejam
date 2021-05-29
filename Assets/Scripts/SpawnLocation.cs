using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{

    [SerializeField]
    private Transform _currentLocation;

    public Transform CurrentLocation => _currentLocation;

    public BarBehaviour BarBehaviour { get; private set; }


    private void Awake()
    {
        BarBehaviour = this.GetComponentInChildren<BarBehaviour>();
    }

}
