using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] GameObject prefabCreatedAfterDeath;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject changeEffect;

    public void ReduceHealth(int amount)
    {
        Instantiate(hitEffect,transform.position,Quaternion.identity);
        health = Mathf.Max(0, health - amount);
        if (health == 0) Die();
    }

    private void Die()
    {
        //create a skeleton, if this is a willager
        if (CompareTag("Enemy") && GetComponent<EnemyAI>().GetEnemyBase().GetComponent<BaseBehaviour>().ReduceEnergy())
        {
            CreatePlayersUnit();
            Instantiate(changeEffect, transform.position, Quaternion.identity);
        }
        //destroy
        Destroy(gameObject);
    }

    private void CreatePlayersUnit()
    {
        GameObject _target = null;
        gameObject.SetActive(false);
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (!gameObject.activeSelf) continue;
            _target = enemy;
            break;
        }
        gameObject.SetActive(true);
        if(prefabCreatedAfterDeath!=null) Instantiate(prefabCreatedAfterDeath, transform.position, Quaternion.identity);        
    }
}
