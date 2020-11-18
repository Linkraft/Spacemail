using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandContact2 : MonoBehaviour
{
    float distance = 0.1f;
    public GameObject sphereControl;
    public GameObject ship;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
                sphereControl.transform.localRotation = Quaternion.Euler(handMag.z * 1000, 0, -handMag.x * 1000);
                ship.transform.position = new Vector3(-sphereControl.transform.rotation.z * speed, sphereControl.transform.rotation.x  *speed, 0);
            }
        }
    }
}
