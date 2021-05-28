using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{

    [SerializeField]
    private Transform _currentLocation;

    public Transform CurrentLocation => _currentLocation;
}
