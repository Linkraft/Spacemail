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
        {
            animator.SetBool("isNext", true);
            StartCoroutine(ExecuteAfterTime(0.2f));
        }
        if (isPrevious == true)
        {
            animator.SetBool("isPrevious", true);
            StartCoroutine(ExecuteAfterTime(0.2f));


        }
        if (isColor == true)
        {
            animator.SetBool("isColor", true);
            StartCoroutine(ExecuteAfterTime(0.2f));

        }
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("isIdle", true);
        animator.SetBool("isNext", false);
        animator.SetBool("isPrevious", false);
        isNext = false;
        isPrevious = false;
        isColor = false;

    }
}
