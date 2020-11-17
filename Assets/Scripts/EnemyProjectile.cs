using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject laser;
    private float nextTime, interval;
    Quaternion rotation;

    void Start()
    {
        interval = Random.Range(0.5f,2f);
         rotation = Quaternion.Euler(90, 0, 0);

    }

    void Update()
    {
     
        if (firePoint != null && Time.time > nextTime)
        {
            nextTime = Time.time + interval;
            Instantiate(laser, firePoint.transform.position, rotation);
            //Sound Here
        }
    }
}
