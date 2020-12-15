using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Vector3 initPos;
    Quaternion initRot, downRot;
    Rigidbody rb;
    BoxCollider collider;
    float minAngle, maxAngle, deltaAngle, rotationSpeed;
    bool resetting;

    //Laser
    public GameObject firePoint_L, firePoint_R;
    public GameObject specialAttack;
    private GameObject laser_L, laser_R;

    private void Start()
    {
        initPos = transform.localPosition;
        initRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        minAngle = 280;
        maxAngle = 340;
        deltaAngle = 0;
        rotationSpeed = 10f;
    }
    private void FixedUpdate()
    {
        Vector3 currRot = transform.rotation.eulerAngles;
        if (resetting)
        {
            Debug.Log("Resetting! " + currRot);
            if (currRot.x >= maxAngle)
            {
                //SoundManager.audioSrc.Stop();
                Debug.Log("Stopped resetting!");
                collider.enabled = true;
                rb.angularVelocity = Vector3.zero;
                resetting = false;
            }
            else
            {
                collider.enabled = false;
                deltaAngle += rotationSpeed * Time.deltaTime;
                deltaAngle = Mathf.Min(deltaAngle, maxAngle);
                transform.rotation = downRot * Quaternion.AngleAxis(deltaAngle, Vector3.right);
            }
        }
        else
        {
            // Movable
            if (rb.angularVelocity.x > 1) rb.angularVelocity = new Vector3(1, rb.angularVelocity.y, rb.angularVelocity.z);
            if (currRot.x < minAngle || maxAngle < currRot.x)
            {
                if (currRot.x < minAngle)
                {
                    //Laser Here
                    if (firePoint_L != null)
                    {
                        laser_L = Instantiate(specialAttack, firePoint_L.transform.position, Quaternion.identity);
                    }

                    if (firePoint_R != null)
                    {
                        laser_R = Instantiate(specialAttack, firePoint_R.transform.position, Quaternion.identity);
                    }

                    //Play sound
                    SoundManager.PlaySound("atk2");
                    SoundManager.audioSrc.loop = true;

                    StartCoroutine(StopLaser());

                    //Debug.Log("Moving to " + minAngle + " from " + currRot.x + "!");
                    currRot.x = minAngle;
                    resetting = true;
                    deltaAngle = 0;
                }
                else if (maxAngle < currRot.x)
                {
                    //Debug.Log("Moving to " + maxAngle + " from " + currRot.x + "!");
                    currRot.x = maxAngle;
                }
                currRot.y = initRot.y;
                currRot.z = initRot.z;
                transform.rotation = Quaternion.Euler(currRot.x, currRot.y, currRot.z);
                if (resetting) downRot = transform.rotation;
            }
        }
        transform.localPosition = initPos;
    }

    IEnumerator StopLaser()
    {
        yield return new WaitForSeconds(3);
        Destroy(laser_L);
        Destroy(laser_R);
    }
}
