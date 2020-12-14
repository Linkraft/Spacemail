using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private Color[] colors = new Color[4];
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
    }


    void LightChange()
    {
        //Debug.Log("CurrIndex " + currentIndex);
        currentIndex += 1;

        if (currentIndex == 4)
            currentIndex = 0;

        shipInteraction.isColor = true;
        interiorLight.color = colors[currentIndex];
    }
}
