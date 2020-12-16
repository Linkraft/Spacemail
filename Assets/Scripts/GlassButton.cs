using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassButton : MonoBehaviour
{
    public Animator buttonAnim, glassAnim;
    private bool isUp = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        buttonAnim.SetBool("isDown", true);
        StartCoroutine(ButtonUp(0.2f));

    }

    private void OnTriggerStay(Collider other)
    {
        SwitchGlassState();
        Debug.Log("IS UP?" + isUp);

    }

    void SwitchGlassState()
    {
        if (glassAnim.GetCurrentAnimatorStateInfo(0).IsName("GlassIdle") ||
            !(glassAnim.GetCurrentAnimatorStateInfo(0).length >
            glassAnim.GetCurrentAnimatorStateInfo(0).normalizedTime))
        {
            if (isUp)
            {
                glassAnim.SetBool("goUp", false);
                isUp = false;
            }

            else
            {
                glassAnim.SetBool("goUp", true);
                isUp = true;
            }
        }
    }


    IEnumerator ButtonUp(float time)
    {
        yield return new WaitForSeconds(time);
        buttonAnim.SetBool("isIdle", true);
        buttonAnim.SetBool("isDown", false);

    }
}
