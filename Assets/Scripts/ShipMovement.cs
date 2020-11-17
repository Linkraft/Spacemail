using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public GameObject ship;
    float xRange, yRange, time;
    Vector3 initialPos, nextPos;
    List<Vector3> travelPoints;
    int currIndex, nextIndex, numPoints;
    // Start is called before the first frame update
    void Start()
    {
        xRange = 50f;
        yRange = 50f;
        numPoints = 3;
        initialPos = ship.transform.position;
        travelPoints = new List<Vector3>();
        GenerateTravelPoints();

        // Set initial positions
        currIndex = 0;
        nextIndex = 1;
        ship.transform.position = travelPoints[currIndex];
        nextPos = travelPoints[nextIndex];
    }

    // Update is called once per frame
    void Update()
    {
/*        if (ship.transform.position == nextPos)
        {
            ship.transform.position = nextPos;
            index = (index == 2) ? 0 : index + 1;
            nextPos = travelPoints[index];
        }*/
        //Vector3.MoveTowards(ship.transform.position, nextPos, 5f * Time.deltaTime);
        ship.transform.position = Vector3.Lerp(travelPoints[currIndex], travelPoints[nextIndex], 5f);
        time += Time.deltaTime;
        
    }

    void GenerateTravelPoints()
    {
        for (int i = 0; i < numPoints; i++)
        {
            // Generate random positions in an XY plane costrained by xRange and yRange
            float randX = Random.Range(initialPos.x - xRange, initialPos.x + xRange);
            float randY = Random.Range(initialPos.y - yRange, initialPos.y + yRange);
            Vector3 travelPoint = new Vector3(randX, randY, 0);
            travelPoints.Add(travelPoint);
        }
    }
}
