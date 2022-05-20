using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Range(1,100)]
    [SerializeField] int lifePoints = 100;
    
    public void ReduceLife(int count)
    {
        lifePoints += count;
        Debug.Log("Life: " + lifePoints);
    }
}
