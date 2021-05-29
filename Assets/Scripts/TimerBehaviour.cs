using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : BarBehaviour
{
    [SerializeField]
    float decreaseSpeed = 0.5f;

    void Update()
    {
        UpdateBarValue(-Time.deltaTime * decreaseSpeed);
    }
}
