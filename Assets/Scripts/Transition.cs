using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Light flashLight;
    public GameObject ray;
    Animator animator;
    public float lightStep = 800f;

    void Start()
    {
        animator = GetComponent<Animator>();
        ray.SetActive(false);
        StartCoroutine(ExecuteAfterTime(0.6f));
        StartCoroutine(NextScene(3.3f));

    }

    // Update is called once per frame
    void Update()
    {
        LightOff();    
    }

    void LightOff()
    {
        flashLight.intensity -= lightStep*Time.deltaTime;
        
        if ( flashLight.intensity == 0)
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

    IEnumerator NextScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(3);
    }
}
