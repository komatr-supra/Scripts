using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Range(1,100)]
    [SerializeField] int damageToBase = 1;
    NavMeshHit navMeshHit;
    Vector3 target;
    NavMeshPath path;
    NavMeshAgent navMeshAgent;
    private void Awake()
    {
        path = new();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        NavMesh.SamplePosition(target,out navMeshHit,3f,NavMesh.AllAreas);
    }
    void Start()
    {
        target = new Vector3(target.x, 0, target.z);
        
    }
    void Update()
    {
        navMeshAgent.SetDestination(navMeshHit.position);
    }
    public int GetDamageToBase()
    {
        return damageToBase;
    }
}
