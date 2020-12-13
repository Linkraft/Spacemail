using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Light flashLight;
    public GameObject ray;
    Animator animator;
    public int lightStep = 10;

    void Start()
    {
        animator = GetComponent<Animator>();
        ray.SetActive(false);
        StartCoroutine(ExecuteAfterTime(0.9f));
    }

    // Update is called once per frame
    void Update()
    {
        LightOff();    
    }

    void LightOff()
    {
        flashLight.intensity -= lightStep * Time.deltaTime;
        if ( flashLight.intensity <8 && flashLight.intensity>0)
        {
            ShowRays();
        }
    }

    void ShowRays()
    {
        ray.SetActive(true);
    }

    void MoveShip()
    {
        animator.SetBool("MoveTo", true);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        MoveShip();
    }
}
