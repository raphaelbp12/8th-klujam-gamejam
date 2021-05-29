using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    [SerializeField]
    private UI_Inventory uiInventory;

    public int selectedSlotIndex { get; private set; } = -1;

    public Inventory inventory;

    private void Awake()
    {
        Card[] allCardTypes = GetAllInstances<Card>(); // get all scriptable objects
        inventory = new Inventory(allCardTypes, uiInventory);
    }

    void Start()
    {
        inventory.Start();
    }

    public void SelectCard(int index)
    {
        inventory.ChangeCardOnSlot(selectedSlotIndex);
        this.selectedSlotIndex = index;
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
