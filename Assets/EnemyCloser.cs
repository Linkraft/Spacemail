using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloser : MonoBehaviour
{
    public float zDistance;
    public float zSpeed;
    float currZDistance;

    private void Update()
    {
        if (currZDistance < zDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - zSpeed * Time.deltaTime);
            currZDistance += zSpeed * Time.deltaTime;
        }
    }
}
