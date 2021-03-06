using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Reputation : MonoBehaviour
{
    
    [SerializeField]
    float multiplierFactor = 10f;
    [SerializeField]
    float positiveReputationThreshold = 0.314159265359f;
    float _reputation;
    public Text reputationText;

    [Header("Events")]
    public OnGameOver onGameOver;

    void Start()
    {
        _reputation = 380;
        string reputationNote = getReputationNote();
        reputationText.text = String.Format("Reputation: {0}", reputationNote);
    }

    public void UpdateReputation(GameObject gameObject){
        Pet pet = gameObject.GetComponent<Pet>();
        float petHappiness = pet.GetHappiness();
        float petCooldown = pet.CdwToStay;
        float reputationDelta = CalculateReputationDelta(petHappiness);
        UpdateReputationField(reputationDelta);
    }

    private float CalculateReputationDelta(float happiness){
        return (happiness-positiveReputationThreshold) * multiplierFactor;
    }

    void UpdateReputationField(float reputationDelta){
        _reputation += reputationDelta;
        string reputationNote = getReputationNote();
        reputationText.text = String.Format("Reputation: {0}", reputationNote);

        if(onGameOver != null){            
            if(reputationNote == "F"){
                onGameOver.Invoke(false);
            }
            else if(reputationNote == "S +"){
                onGameOver.Invoke(true);
            }
        }
    }

    string getReputationNote(){
        if(_reputation < 100){ return "F"; }        
        else if(_reputation >= 100 && _reputation < 150){ return "D"; }
        else if(_reputation >= 150 && _reputation < 200){ return "C -"; }
        else if(_reputation >= 200 && _reputation < 250){ return "C"; }
        else if(_reputation >= 250 && _reputation < 300){ return "C +"; }
        else if(_reputation >= 300 && _reputation < 350){ return "B -"; }
        else if(_reputation >= 350 && _reputation < 400){ return "B"; }
        else if(_reputation >= 400 && _reputation < 450){ return "B +"; }
        else if(_reputation >= 450 && _reputation < 500){ return "A -"; }
        else if(_reputation >= 500 && _reputation < 550){ return "A"; }
        else if(_reputation >= 550 && _reputation < 600){ return "A +"; }
        else if(_reputation >= 600 && _reputation < 650){ return "S -"; }
        else if(_reputation >= 650 && _reputation < 700){ return "S"; }
        else{ return "S +"; }
    }

}

[Serializable]
public class OnGameOver : UnityEvent<bool> { }