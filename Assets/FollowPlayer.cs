using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject[] Target;
    float minDistance;
    public Transform currTarget;
    public float MinModifier;
    public float MaxModifier;
    public bool isFollow;
    public float smoothTime = 0.3F;


    Vector3 _velocity = Vector3.zero;
    void Start()
    {
        Target = GameObject.FindGameObjectsWithTag("Collector");
        currTarget = Target[0].transform;
        if (Mathf.Abs(Target[1].transform.position.x - transform.position.x) < Mathf.Abs(Target[0].transform.position.x - transform.position.x)){
            currTarget = Target[1].transform;
        }

 
        MinModifier = 7;
        MaxModifier = 11;
    }

    public void StartFollowing()
    {
        transform.position = Vector3.SmoothDamp(transform.position, currTarget.position, ref _velocity, smoothTime);
        //transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * 10);
    }

    void Update()
    {

        StartCoroutine(ExecuteAfterTime(0.9f));

    }



    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        StartFollowing();
    }
}
