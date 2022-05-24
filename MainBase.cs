using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBase : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] int lifePoints = 100;
    [SerializeField] GameObject effectHit;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag(other.tag))
        {
            Debug.Log("same tag");
            return;
        }
        ReduceLife(-1);//other.gameObject.GetComponent<EnemyAI>().GetAttackPower()
        Instantiate(effectHit,transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }
    private void ReduceLife(int v)
    {
        lifePoints += v;
    }
    public int GetLifePoints()
    {
        return lifePoints;
    }
}
