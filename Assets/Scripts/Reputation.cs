using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reputation : MonoBehaviour
{
    float _reputation;
    public Text reputationText;

    void Start()
    {
        _reputation = 0;
    }

    public void UpdateReputation(GameObject gameObject){
        Pet pet = gameObject.GetComponent<Pet>();
        float petHappiness = pet.GetHappiness();
        float petCooldown = pet.CdwToStay;
        float reputationDelta = CalculateReputationDelta(petHappiness, petCooldown);
        UpdateReputationField(reputationDelta);
    }

    private float CalculateReputationDelta(float happiness, float cooldown){
        return happiness * cooldown * 0.1;
    }

    void UpdateReputationField(float reputationDelta){
        _reputation += reputationDelta;
        reputationText.text = String.Format("Reputation:   {0}", getReputationNote());
    }

    string getReputationNote(){
        if(_reputation < 50){ return "F"; }
        else if(_reputation >= 50 && _reputation < 100){ return "E"; }        
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
        else{ return "S+"; }
    }

}
