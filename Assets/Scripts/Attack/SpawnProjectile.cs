using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    //public List<GameObject> vfx = new List<GameObject>();
    public GameObject basicAttack, specialAttack;
    GameObject laser;

    void Start()
    {
        laser = Instantiate(specialAttack, firePoint.transform.position, Quaternion.identity);
        laser.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (firePoint != null)
            {
                Instantiate(basicAttack, firePoint.transform.position, Quaternion.identity);
                SoundManager.audioSrc.volume = 0.3f;
                SoundManager.PlaySound("atk1");
            }
        }

        //Laser Attack on right mouse button down
        if (Input.GetMouseButton(1))
        {
            if (firePoint != null)
            {
                laser.SetActive(true);
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
            laser.SetActive(false);

        }

    }
}