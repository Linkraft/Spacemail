using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScene : MonoBehaviour
{
    public GameObject cloud;
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(1.5f));
    }

    void Update()
    {

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(cloud);
    }
}
