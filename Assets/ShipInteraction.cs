using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInteraction : MonoBehaviour
{
    Animator animator;

    public bool isNext, isPrevious, isColor;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isNext == true)
            animator.SetBool("isNext", true);
        if (isPrevious == true)
            animator.SetBool("isPrevious", true);
        if (isColor == true)
            animator.SetBool("isColor", true);
    }
}
