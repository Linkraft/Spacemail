using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health;
    public GameObject explodeVFX;
    
    void Start()
    {
        health = 50;
    }

    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        health -= 10;

        if (health == 0)
        {
            SoundManager.audioSrc.volume = 1.8f;
            SoundManager.PlaySound("explode");
            Instantiate(explodeVFX, transform.position, transform.rotation);
            Debug.Log("Explode");

            Destroy(gameObject);
        }

    }
}
