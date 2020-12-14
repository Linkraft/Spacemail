using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScreen(GameObject screen)
    {
        Debug.Log("Loading..");
        screen.SetActive(true);
        StartCoroutine(Load(screen));
    }

    IEnumerator Load(GameObject screen)
    {
        BoxCollider[] colliders = screen.GetComponentsInChildren<BoxCollider>();
        Debug.Log("Disabling colliders");
        foreach (BoxCollider collider in colliders)
            collider.enabled = false;
        yield return new WaitForSeconds(1f);
        Debug.Log("Reenabling colliders");
        foreach (BoxCollider collider in colliders)
            collider.enabled = true;
    }
}
