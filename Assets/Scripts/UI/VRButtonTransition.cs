using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButtonTransition : MonoBehaviour
{
    public GameObject screen;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Transitioning to screen " + screen.name);
        FindObjectOfType<MainMenu>().LoadScreen(screen);
        this.transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
        this.transform.parent.parent.gameObject.SetActive(false);
    }
}
