using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float destroyTime = 4f;
    public float speed;
    public float fireRate;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;
    public GameObject target;


    void Start()
    {
        if(muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            var pMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
            if (pMuzzle != null)
                Destroy(muzzleVFX, pMuzzle.main.duration);
            else
            {
                var pChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, pChild.main.duration);
            }
        }
    }

    void Update()
    {
        target = GameObject.Find("ShipFinal/BulletTarget");
        if (speed != 0)
        {
            //transform.position += transform.forward * (speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        //Destroy projectile after 3 seconds
        Destroy(gameObject, destroyTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);
            SoundManager.PlaySound("atkHit1");
            var pHit = hitVFX.GetComponent<ParticleSystem>();
            if (pHit != null)
                Destroy(hitVFX, pHit.main.duration);
            else
            {
                var pChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitVFX, pChild.main.duration);
            }
        }

        Destroy(gameObject);
    }

   
}
