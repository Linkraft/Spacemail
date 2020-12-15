using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandContact2 : MonoBehaviour
{
    float distance = 0.1f;
    public GameObject sphereControl;
    public GameObject ship;
    public float speed = 15f;
    public float zDistance, zSpeed;
    float currZDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        originalMovement();
    }

    public void originalMovement()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.up);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.gameObject.CompareTag("Control Sphere"))
            {
                Debug.Log("Touched");
                Vector3 handPosition = this.gameObject.transform.position;
                Vector3 spherePosition = sphereControl.transform.position;
                // Debug.Log("HandPosition: " + handPosition);
                Vector3 handMag = handPosition - spherePosition;
                Debug.Log("HandMagnitude: " + handMag);

                //Original Movement
                sphereControl.transform.localRotation = Quaternion.Euler(handMag.z * 2000, 0, -handMag.x * 2000);
                Vector3 newPos = new Vector3(sphereControl.transform.rotation.z * speed, sphereControl.transform.rotation.x * speed, 0);

                //Global Movement
                //sphereControl.transform.Rotate((handMag.z + handMag.y) * 10, 0, -handMag.x * 10, Space.World);
                //Vector3 newPos = new Vector3(sphereControl.transform.rotation.z * speed, sphereControl.transform.rotation.x * speed, 0);

                //ship.transform.position = new Vector3(-sphereControl.transform.rotation.z * speed, sphereControl.transform.rotation.x * speed, 0);
                ship.transform.position = Vector3.Lerp(ship.transform.position, newPos, Time.deltaTime * 1.0f);
            }
        }


        if (currZDistance < zDistance)
        {
            ship.transform.Translate(0, 0, zSpeed * Time.deltaTime);
            currZDistance += zSpeed * Time.deltaTime;
        }
    }

    
}
