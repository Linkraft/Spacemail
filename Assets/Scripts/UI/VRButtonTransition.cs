using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButtonTransition : MonoBehaviour
{
    public GameObject screen;
    private void OnTriggerEnter(Collider other)
    {
        screen.SetActive(true);
        this.transform.parent.parent.gameObject.SetActive(false);
    }
}
