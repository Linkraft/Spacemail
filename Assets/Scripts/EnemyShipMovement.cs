using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{
    // Public
    public float xRange;
    public float yRange;
    public float speed;
    public int numPoints;
    // Private
    Vector3 initialPos;
    List<Vector3> travelPoints;
    int currIndex, nextIndex;

    // Start is called before the first frame update
    void Start()
    {
        currIndex = 0;
        nextIndex = 1;
        numPoints = 3;

        initialPos = transform.position;
        travelPoints = new List<Vector3>();
        GenerateTravelPoints();

        // Set initial position
        transform.position = travelPoints[currIndex];
    }

    // Update is called once per frame
    void Update()
    {   
        if (transform.position != travelPoints[nextIndex]) {
            transform.position = Vector3.MoveTowards(transform.position, travelPoints[nextIndex], Time.deltaTime * speed);
        }
        else
        {
            currIndex = (currIndex == numPoints - 1) ? 0 : currIndex + 1;
            nextIndex = (currIndex == numPoints - 1) ? 0 : currIndex + 1;
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
