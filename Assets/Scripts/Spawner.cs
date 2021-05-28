using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Information")]
    [SerializeField]
    private List<SpawnInformation> _spawns;

    [Header("Events")]
    public OnSpawnPet onSpawnPet;
    public OnRemovePet onRemovePet;

    void Start()
    {
        StartSpawnProcess();
    }
    private void OnValidate()
    {
    }
    private void StartSpawnProcess()
    {
        foreach (SpawnInformation sawnInformation in _spawns)
        {
            StartCoroutine(SpawnProcess(sawnInformation));
        }
    }

    IEnumerator SpawnProcess(SpawnInformation spawnInfo)
    {
        yield return new WaitForSeconds(spawnInfo.CdwToSpawn);

        spawnInfo.CurrentGameObject = Instantiate(spawnInfo.Prefab, spawnInfo.SpawnLocation);
        spawnInfo.CurrentGameObject.transform.parent = null;
        spawnInfo.HasSpawned = true;

        if (onSpawnPet != null)
            onSpawnPet.Invoke(spawnInfo.CurrentGameObject);

        StartCoroutine(RemoveProcess(spawnInfo));
    }

    IEnumerator RemoveProcess(SpawnInformation spawnInfo)
    {
        yield return new WaitForSeconds(spawnInfo.Pet.CdwToStay);

        if (onRemovePet != null)
            onRemovePet.Invoke(spawnInfo.CurrentGameObject);

        Destroy(spawnInfo.CurrentGameObject);
        spawnInfo.CurrentGameObject = null;
        spawnInfo.HasSpawned = false;

        StartCoroutine(SpawnProcess(spawnInfo));
    }
}

[Serializable]
public class SpawnInformation
{
    [HideInInspector]
    public string name = "Pet";

    [SerializeField]
    private float _cdwToSpawn;

    [SerializeField]
    private SpawnLocation _spawnLocation;
    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private List<GameObject> _prefabs;

    private GameObject GetPrefab()
    {
        if (_prefabs.Any())
        {
            int totalWeight = _prefabs.Sum(e => e.GetComponent<Pet>().WeigthToSpawn);
            int randomNumber = UnityEngine.Random.Range(1, totalWeight);
 
            int count = 0;
            foreach (var prefab in _prefabs)
            {
                Pet pet = prefab.GetComponent<Pet>();
                count += pet.WeigthToSpawn;

                if (randomNumber <= count)
                {
                    return prefab;
                }
            }
        }

        return _prefab;
    }

    public GameObject CurrentGameObject { get; set; }
    public bool HasSpawned { get; set; }

    public Pet Pet => CurrentGameObject.GetComponent<Pet>();
    public float CdwToSpawn => _cdwToSpawn;
    public Transform SpawnLocation => _spawnLocation.CurrentLocation;
    public GameObject Prefab => GetPrefab();
}

[Serializable]
public class OnSpawnPet : UnityEvent<GameObject> { }
[Serializable]
public class OnRemovePet : UnityEvent<GameObject> { }