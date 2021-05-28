using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAssets : MonoBehaviour
{
    public static CardAssets Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    public Sprite foodCardSprite;
    public Sprite showerCardSprite;
    public Sprite playCardSprite;
    public Sprite medicinCardSprite;
}
