using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Range(1,100)]
    [SerializeField] string targetStringID = "Enemy";
    [SerializeField] float chaseRadius = 4f;
    [Range(1,100)]
    [SerializeField] int attackPower = 1;
    [SerializeField] float attackDelay = 1;
    [SerializeField] float weaponRange = 1f;
    float attackDelayCounter = 0;
    NavMeshHit navMeshHit;
    public GameObject target;

    NavMeshAgent navMeshAgent;
    Animator animator;
    GameObject enemyBase;

    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();        
        animator = GetComponent<Animator>();
        //navMeshAgent.avoidancePriority = (int)UnityEngine.Random.Range(1, 100);
        
    }
    void Start()
    {
        //find enemy base
        FindEnemyBase();
        //goto the base
        SetTarget(enemyBase);
        
    }
    void Update()
    {        
        AnimationUpdate();
        if (attackDelayCounter > 0) attackDelayCounter -= Time.deltaTime;
        NearEnemyChecking();
        if (Vector3.Distance(target.transform.position, transform.position) < weaponRange)
        {
            navMeshAgent.isStopped = true;
            Attack();
            return;
        }
        

    }


    private void Attack()
    {
        if (attackDelayCounter > 0) return;
        attackDelayCounter = attackDelay;
        animator.SetTrigger("attack");
    }

    void NearEnemyChecking()
    {
        GameObject enemyToTarget = enemyBase;
        float _dist = Mathf.Infinity;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag(targetStringID))
        {
            float _tempDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if (_tempDistance < chaseRadius &&
                _dist > _tempDistance)
            {
                _dist = _tempDistance;
                enemyToTarget = enemy;
            }
        }
        SetTarget(enemyToTarget);        
    }
    private void FindEnemyBase()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag(targetStringID))
        {  
             if (enemy.GetComponent<MainBase>() != null) enemyBase = enemy;
        }   
    }
    private void MoveToTarget()
    {
        navMeshAgent.isStopped = false;
        Vector2 _rad = UnityEngine.Random.insideUnitCircle * 3;
        Vector3 _dest = new Vector3(target.transform.position.x + _rad.x,target.transform.position.y, target.transform.position.z + _rad.y);
        NavMesh.SamplePosition(_dest, out navMeshHit, 4f, NavMesh.AllAreas);
        navMeshAgent.SetDestination(navMeshHit.position);
    }

    private void AnimationUpdate()
    {
        float actualSpeed = Vector3.Magnitude(navMeshAgent.velocity);
        animator.SetFloat("speed", actualSpeed);
    }

    public int GetAttackPower()
    {
        return attackPower;
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;
        MoveToTarget();
    }
    public GameObject GetEnemyBase()
    {
        return enemyBase;
    }
    void Hit()
    {
        Health _enemy = target.GetComponent<Health>();
        if(_enemy != null) 
        _enemy.ReduceHealth(attackPower);
    }
}

