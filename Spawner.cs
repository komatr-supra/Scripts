using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minSpawningTime = 3f;
    [SerializeField] float maxSpawningTime = 5f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnPoint;
    Transform playerBaseTransform;
    void Start()
    {
        StartCoroutine(Spawning());
        playerBaseTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    IEnumerator Spawning()
    {
        while (true)
        {
            //spawn an enemy
            Debug.Log("Spawning an enemy");
            GameObject actualEnemy = Instantiate(enemyPrefab);
            actualEnemy.transform.position = spawnPoint.transform.position;
            actualEnemy.transform.LookAt(playerBaseTransform,Vector3.up);
            actualEnemy.GetComponent<NavMeshAgent>().enabled = true;
            //wait for random time
            yield return new WaitForSeconds(RandomSpawnTime());
        }
    }
    float RandomSpawnTime()
    {
        return Random.Range(minSpawningTime, maxSpawningTime);
    }
}
