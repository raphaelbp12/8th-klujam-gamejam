using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameRules gameRules;

    private void Awake()
    {
        gameRules = GameObject.FindObjectOfType<GameRules>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Pet? petTarget = CheckMouseHover.CheckPetHover();

            if (petTarget != null)
            {
                gameRules.SelectPet(petTarget);
            }
        }
    }
}
