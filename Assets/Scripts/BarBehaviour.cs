using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{
    public Slider slider;

    [SerializeField]
    Image icon;

    // public Sprite m_Sprite;

    public void UpdateBarValue(float addValue){
        float newSliderValue = slider.value + addValue;
        if(newSliderValue < 0){
            newSliderValue = 0;
        }
        slider.value = newSliderValue;
    }

    void Start() {
        slider.value = slider.maxValue;
    }

    public void SetBarValue(float value){
        slider.value = value;
    }

    public void SetIcon(Sprite sprite){
        icon.sprite = sprite;
    }
    
}
