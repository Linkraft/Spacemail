using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{
    // Public
    public float xRange = 50f;
    public float yRange = 50f;
    public float speed = 0.5f;

    // Private
    float fraction;
    Vector3 initialPos;
    List<Vector3> travelPoints;
    int currIndex, nextIndex, numPoints;

    // Start is called before the first frame update
    void Start()
    {
        xRange = 50f;
        yRange = 50f;
        numPoints = 3;
        speed = .5f;
        initialPos = transform.position;
        travelPoints = new List<Vector3>();
        GenerateTravelPoints();

        // Set initial positions
        currIndex = 0;
        nextIndex = 1;
        transform.position = travelPoints[currIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (fraction < 1)
        {
            fraction += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(travelPoints[currIndex], travelPoints[nextIndex], fraction);
        }
        else
        {
            fraction = 0;
            currIndex = (currIndex == 2) ? 0 : currIndex + 1;
            nextIndex = (currIndex == 2) ? 0 : currIndex + 1;
        }
        
    }

    void GenerateTravelPoints()
    {
        for (int i = 0; i < numPoints; i++)
        {
            // Generate random positions in an XY plane costrained by xRange and yRange
            float randX = Random.Range(initialPos.x - xRange, initialPos.x + xRange);
            float randY = Random.Range(initialPos.y - yRange, initialPos.y + yRange);
            Vector3 travelPoint = new Vector3(randX, randY, initialPos.z);
            travelPoints.Add(travelPoint);
        }
    }
}
