using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot_arm_behaviour : MonoBehaviour
{
    Animator roboArm;
    int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        roboArm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        roboArm.SetInteger("state", state);
    }

    public void stateChange()
    {
        state = 3;
    }
}
