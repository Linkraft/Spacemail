using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public IEnumerator LoadScreen()
    {
        BoxCollider[] colliders = GetComponentsInChildren<BoxCollider>();
        Debug.Log("Enabling colliders");
        foreach (BoxCollider collider in colliders)
            collider.enabled = false;
        yield return new WaitForSeconds(1);
        Debug.Log("Reenabling colliders");
        foreach (BoxCollider collider in colliders)
            collider.enabled = true;
    }
}
