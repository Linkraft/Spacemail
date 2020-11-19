using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveProjectile : MonoBehaviour
{
    public float speed;
    private float interval, nextTime;
    public float destroyTime = 4f;

    void Start()
    {
        speed = 25f;

    }

    void Update()
    {
       
            transform.position -= transform.up * (speed * Time.deltaTime);
        Destroy(gameObject, destroyTime);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        speed = 0;

        Destroy(gameObject);
    }
}
