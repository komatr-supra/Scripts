using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseBehaviour : MonoBehaviour
{
    Score score;
    private void Awake()
    {
        score = GetComponent<Score>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        Debug.Log("Enemy atacking to base!");
        score.ReduceLife(-other.gameObject.GetComponent<EnemyAI>().GetDamageToBase());
        Destroy(other.gameObject);
    }
}
