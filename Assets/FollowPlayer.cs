using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform Target;
    public float MinModifier;
    public float MaxModifier;
    public bool isFollow;
    public float smoothTime = 0.3F;


    Vector3 _velocity = Vector3.zero;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        MinModifier = 7;
        MaxModifier = 11;
    }

    public void StartFollowing()
    {
        isFollow = true;
    }

    void Update()
    {
            transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref _velocity, smoothTime);
            //transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * 10);

    }
}
