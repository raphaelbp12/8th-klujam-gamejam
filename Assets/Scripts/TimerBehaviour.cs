using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : BarBehaviour
{

    void Update()
    {
        UpdateBarValue(-Time.deltaTime);
    }
}
