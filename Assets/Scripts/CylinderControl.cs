using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderControl : MonoBehaviour
{
    public Animator ship;
    private Animator cylindar;

    private GameObject ResourceButton, GlassButton;
    void Start()
    {
        cylindar = GetComponent<Animator>();

    }

    void Update()
    {

        if (ship.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            cylindar.SetBool("isShow", true);
        }

    }
}


 
