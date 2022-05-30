using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI lifeRemaningText;
    [SerializeField] TextMeshProUGUI energyRemaningText;
    [SerializeField] MainBase mainBase;
    [SerializeField] BaseBehaviour baseBehaviour;


    public void Update()
    {
        lifeRemaningText.text = "Life: " + mainBase.GetLifePoints();
        energyRemaningText.text = "Energy: " + Mathf.Floor(baseBehaviour.GetEnergyActual());
    }


}
