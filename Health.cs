using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] GameObject prefabCreatedAfterDeath;

    private void Awake()
    {

    }
    public void ReduceHealth(int amount)
    {
        health = Mathf.Max(0, health - amount);
        if (health == 0) Die();
    }

    private void Die()
    {
        //create a skeleton, if this is a willager
        if (CompareTag("Enemy"))
        {
            Debug.Log("CREATING PLAYERS UNIT");
            CreatePlayersUnit();
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
