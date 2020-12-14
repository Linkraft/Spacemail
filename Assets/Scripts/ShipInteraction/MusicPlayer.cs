using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioClip[] clips;
    private string[] MusicList = new string[3];
    private int currentIndex;
    public ShipInteraction shipInteraction;
    

    void Start()
    {
        SoundManager.PlayMusic("music1");
        MusicList[0] = "music1";
        MusicList[1] = "music2";
        MusicList[2] = "music3";
    }

    void Update()
    {
        if (Input.GetKeyDown("right"))
            PlayNext();

        if (Input.GetKeyDown("left"))
            PlayPrevious();


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide (name) : " + other.gameObject.name);

        if (this.gameObject.name == "nextButton")
            PlayNext();

        if (this.gameObject.name == "previousButton")
            PlayPrevious();

       
    }

    void PlayNext()
    {
        Debug.Log("Play Next");
        currentIndex += 1;
        CheckBound();
        shipInteraction.isNext = true;
        SoundManager.BGMSrc.Stop();

        SoundManager.PlayMusic(MusicList[currentIndex]);

    }

    void PlayPrevious()
    {
        Debug.Log("Play Previous");
        currentIndex -= 1;
        CheckBound();
        shipInteraction.isPrevious = true;
        SoundManager.BGMSrc.Stop();

        SoundManager.PlayMusic(MusicList[currentIndex]);


    }

    void CheckBound()
    {
        if (currentIndex == 3 )
        {
            currentIndex = 0;
        }

        if ( currentIndex == -1)
        {
            currentIndex = 2;
        }
    }
}
