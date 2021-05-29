using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    [SerializeField]
    private UI_Inventory uiInventory;

    public int selectedSlotInstanceId { get; private set; }

    public Inventory inventory;

    private void Awake()
    {
        Card[] allCardTypes = GetAllInstances<Card>(); // get all scriptable objects
        inventory = new Inventory(allCardTypes);
    }

    void Start()
    {
        uiInventory.InitInventoryItems();
    }

    public void SelectCard(int instanceId)
    {
        this.selectedSlotInstanceId = instanceId;
        uiInventory.RefreshInventoryItems();
    }

    public static T[] GetAllInstances<T>() where T : ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;

    }
}
