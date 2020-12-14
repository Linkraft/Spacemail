using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectileHand : MonoBehaviour
{
    public GameObject firePoint_L, firePoint_R;
    //public List<GameObject> vfx = new List<GameObject>();
    public GameObject basicAttack, specialAttack;
    private GameObject laser_L, laser_R;

    public Animator anim1, anim2;

    void Start()
    {
    }

    void Update()
    {
   

        //Laser Attack on right mouse button down
        if (Input.GetMouseButtonDown(1))
        {
            if (firePoint_L != null)
            {
                laser_L = Instantiate(specialAttack, firePoint_L.transform.position, Quaternion.identity);
            }

            if (firePoint_R != null)
            {
                laser_R = Instantiate(specialAttack, firePoint_R.transform.position, Quaternion.identity);
            }

            //Play sound
            if (!SoundManager.audioSrc.isPlaying)
            {
                SoundManager.PlaySound("atk2");
                SoundManager.audioSrc.loop = true;
            }
        }


        // Hide laser VFX on right mouse button up
        if (Input.GetMouseButtonUp(1))
        {
            SoundManager.audioSrc.Stop();
            Destroy(laser_L);
            Destroy(laser_R);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("HandContact"))
        if (firePoint_L != null)
        {
            Instantiate(basicAttack, firePoint_L.transform.position, Quaternion.identity);
                anim1.SetTrigger("Fire_1");
        }

        if (firePoint_R != null)
        {
            Instantiate(basicAttack, firePoint_R.transform.position, Quaternion.identity);
            anim2.SetTrigger("Fire_1");
        }
        //animate
        Animator test = GameObject.Find("Robot_arm").GetComponent<Animator>();
        test.SetTrigger("Shoot1");
        
        SoundManager.audioSrc.volume = 0.3f;
        SoundManager.PlaySound("atk1");
    }
}