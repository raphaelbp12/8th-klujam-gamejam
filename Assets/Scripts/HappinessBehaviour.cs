using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBehaviour : BarBehaviour
{
    [SerializeField]
    Image fillImage;

    public Sprite testNewSprite;

    [SerializeField]
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    
    void UpdateFillColor(){
        fillImage.color = gradient.Evaluate(slider.value/slider.maxValue);
    }    

    void Update() {
        // Just testing :)
        UpdateBarValue(-Time.deltaTime);
        UpdateFillColor();
        setIcon(testNewSprite);
    }

}
