using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] int damage = 1;
    GameObject target;
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (target == null) return;
        transform.LookAt(target.transform);
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;
        transform.LookAt(target.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other == null || !other.CompareTag(target.tag)) return;
        //cool stuff
        //die villagers, DIE!
        Debug.Log("number of hits?" + damage);
        other.GetComponent<Health>().ReduceHealth(damage);
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject);

    }
}
