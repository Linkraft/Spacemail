using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSphere : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hand Contact"))
        {
            Physics.IgnoreCollision(this.GetComponent<SphereCollider>(), collision.collider);
        }
    }
}
