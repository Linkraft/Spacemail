using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacle;
    GameObject shipPosition;
    Vector3 shipPos;
    Vector3 instantiateSpot;
    float distance;
    float randomNumb;
    float randomSpot;
    void Start()
    {
        shipPosition = GameObject.Find("ShipFinal");
        randomNumb = Random.Range(1, 20);
        randomSpot = Random.Range(-15, 15);
        instantiateSpot = new Vector3(shipPos.x + randomSpot, shipPos.y + randomSpot, shipPos.z + randomSpot + 100);
    }

    // Update is called once per frame
    void Update()
    {
        spawnObject();
    }

    public void spawnObject() {

        shipPos = shipPosition.transform.position;
        gameObject.transform.Translate(Vector3.forward * -Time.deltaTime * randomNumb);

        distance = gameObject.transform.position.z - shipPos.z;

        if (distance < -5 || gameObject == null)
        {
            Instantiate(obstacle, instantiateSpot, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
