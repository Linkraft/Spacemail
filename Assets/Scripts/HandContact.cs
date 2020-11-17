using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandContact : MonoBehaviour
{
    float distance = .1f;
    float rotationSpeed = 50f;

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.up);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.gameObject.CompareTag("Control Sphere"))
            {
                Rigidbody controlSphereRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                Transform localPos = controlSphereRB.transform;
                Vector3 velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                Debug.Log("Hand velocity: " + velocity);

                float diffX = Mathf.Abs(transform.position.x - localPos.position.x);
                if (transform.position.x < localPos.position.x) diffX *= -1;
                float diffZ = Mathf.Abs(transform.position.z - localPos.position.z);
                if (transform.position.x < localPos.position.x) diffZ *= -1;

                Debug.Log("Difference: (" + diffX + ", 0, " + diffZ + ")");

                float h = diffX * rotationSpeed * Time.deltaTime;
                float v = diffZ * rotationSpeed * Time.deltaTime;

                //Debug.Log("Z Axis Rotation: " + h + "\nX Axis Rotation: " + v);
                //controlSphereRB.AddTorque(localPos.up + yFactor);
                //controlSphereRB.AddTorque(localPos.right * v);
                controlSphereRB.AddTorque(localPos.forward * h);
                controlSphereRB.AddTorque(localPos.right * v);
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
    }
}
