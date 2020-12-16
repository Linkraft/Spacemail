using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSmallRocks : MonoBehaviour
{
    Transform[] childrenObjects;
    float timeInstantiated;
    ObstacleMovment wow;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillRocks());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(KillRocks());


    }

    IEnumerator KillRocks()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);

    }
}