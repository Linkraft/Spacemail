using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float health;
    public GameObject healthBar;
    public GameObject explodeVFX;
    

    void Start()
    {
        health = 100;
    }

    void Update()
    {
       
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        
        health -= 20;
        healthBar.transform.localScale = new Vector3(health / 100f, 1, 1);
        

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
