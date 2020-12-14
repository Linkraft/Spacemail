using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float health;
    public GameObject healthBar;
    public GameObject explodeVFX;
    public GameObject loot;


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
            for(int i = 0; i<5; i++)
            {
                Instantiate(loot, transform.position + (new Vector3(Random.Range(-2f, 2f), Random.Range(-0.4f, 1f), Random.Range(-0.4f, 1f))), transform.rotation);

            }


            Destroy(gameObject);
        }

    }
}
