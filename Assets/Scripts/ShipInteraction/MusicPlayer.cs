using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioClip[] clips;
    private string[] MusicList = new string[5];
    private int currentIndex;
    public ShipInteraction shipInteraction;

    bool sentinel = false;


    void Start()
    {
        if (!SoundManager.BGMSrc.isPlaying)
        {
            SoundManager.PlayMusic("music1");
        }
        MusicList[0] = "music1";
        MusicList[1] = "music2";
        MusicList[2] = "music3";
        MusicList[3] = "music4";
        MusicList[4] = "music5";
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

        if( !sentinel)
        {
            sentinel = true;
            if (this.gameObject.name == "nextButton")
            {
                currentIndex += 1;
                CheckBound();
                PlayNext();
            }

            if (this.gameObject.name == "previousButton")
            {
                currentIndex -= 1;
                CheckBound();
                PlayPrevious();
            }
        }
    }

   

    private void OnTriggerExit(Collider other)
    {
        sentinel = false;
    }

    void PlayNext()
    {
        Debug.Log("Play Next");
        

        Debug.Log("CurrMusic: " + currentIndex);
        shipInteraction.isNext = true;
        SoundManager.BGMSrc.Stop();

        SoundManager.PlayMusic(MusicList[currentIndex]);

    }

    void PlayPrevious()
    {
        Debug.Log("Play Previous");
  

        Debug.Log("CurrMusic: " + currentIndex);

        shipInteraction.isPrevious = true;
        SoundManager.BGMSrc.Stop();

        SoundManager.PlayMusic(MusicList[currentIndex]);


    }

    void CheckBound()
    {
        if (currentIndex == 5 )
        {
            currentIndex = 0;
        }

        if ( currentIndex == -1)
        {
            currentIndex = 4;
        }
    }
}
