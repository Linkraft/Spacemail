using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResourceTrigger : MonoBehaviour
{
    public Animator anim1, anim2, buttomDown;

    private Scene curScene;
    private string sceneName;

    void Start()
    {
       curScene = SceneManager.GetActiveScene();
       sceneName = curScene.name;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (sceneName == "FireScene")
        {
            anim1.SetTrigger("Water");
            anim2.SetTrigger("Water");
            StartCoroutine(WaterStop());
        }
        else
        {
            anim1.SetTrigger("Tree_plant");
            anim2.SetTrigger("Tree_plant");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        buttomDown.SetBool("isDown", true);
        StartCoroutine(ButtonUp(0.2f));

    }

    IEnumerator WaterStop()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Finished Water pour");
        //Stop watering
        anim1.SetTrigger("Suck_back");
        anim2.SetTrigger("Suck_back");

        anim1.SetTrigger("Water");
        anim2.SetTrigger("Water");
    }


    IEnumerator ButtonUp(float time)
    {
        yield return new WaitForSeconds(time);
        buttomDown.SetBool("isIdle", true);
        buttomDown.SetBool("isDown", false);

    }
}
