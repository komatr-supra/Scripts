using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseBehaviour : MonoBehaviour
{
    [SerializeField] GameObject firePosition;
    [SerializeField] float fireDistance = 10f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float energy = 2f;
    [SerializeField] float energyRechargeModifierMultiplier = 0.5f;
    bool fireEnabled = true;
    float fireCountdown = 0;
    GameObject target;
    Score score;
    private void Awake()
    {
        score = GetComponent<Score>();        
    }

    private void Update()
    {
        energy += Time.deltaTime*energyRechargeModifierMultiplier;
        if (fireCountdown > 0) fireCountdown -= Time.deltaTime;
        if(target == null || Vector3.Distance(target.transform.position,transform.position) > fireDistance)
        {
            StartCoroutine(FindNearestTarget());
        }
        else
        {
            if (!fireEnabled || fireCountdown > 0) return;
            StopAllCoroutines();            
            fireCountdown = fireRate;
            ShootAtEnemy();
        }
    }
    public float GetEnergyActual()
    {
        return energy;
    }
    private void ShootAtEnemy()
    {        
        //shoot to enemy
        var _inst = Instantiate(projectilePrefab, firePosition.transform.position, Quaternion.identity);
        _inst.GetComponent<Projectile>().SetTarget(target);
    }

    IEnumerator FindNearestTarget()
    {
        float distance = Mathf.Infinity;
        GameObject nearTarget = null;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (enemy == null) continue;
            //is this target nearest?
            float _dist = Vector3.Distance(enemy.transform.position, transform.position);
            if (_dist < distance)
            {
                distance = _dist;
                nearTarget = enemy;
            }
            yield return null;
        }
        if (distance < fireDistance) target = nearTarget;
        else target = null;
    }
    public bool ReduceEnergy()
    {
        if (energy < 1) return false;
        energy--;
        return true;
    }
}
