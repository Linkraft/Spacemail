using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Color[] colors;
    public Light interiorLight;
    private int currentIndex = 0;
    public ShipInteraction shipInteraction;

    void Start()
    {
        colors[0] = Color.white;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.yellow;

        interiorLight.color = colors[currentIndex];
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide (name) : " + other.gameObject.name);

        LightChange();
        shipInteraction.isColor = true;
    }


    void LightChange()
    {

        currentIndex += 1;
        Debug.Log("CurrIndex " + currentIndex);

        if (currentIndex == 4)
            currentIndex = 0;

        if (currentIndex == -1)
            currentIndex = 3;

        interiorLight.color = colors[currentIndex];
    }
}
