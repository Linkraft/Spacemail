using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButtonCollider : MonoBehaviour
{
    Color initSpriteColor;
    public Color newSpriteColor;

    private void Start()
    {
        initSpriteColor = GetComponentInParent<SpriteRenderer>().color;   
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called on " + gameObject.name);
        GetComponentInParent<SpriteRenderer>().color = newSpriteColor;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called on " + gameObject.name);
        GetComponentInParent<SpriteRenderer>().color = initSpriteColor;
    }
}
