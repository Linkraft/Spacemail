using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Battle
    public static AudioClip atk1, atk2, atkHit1, atkHit2, explode;

    //Interactions
    public static AudioClip music1, music2, music3;

    public static AudioSource audioSrc;

    void Start()
    {
        atk1 = Resources.Load<AudioClip>("atk1");
        atk2 = Resources.Load<AudioClip>("atk2");
        atkHit1 = Resources.Load<AudioClip>("atkHit1");
        atkHit2 = Resources.Load<AudioClip>("atkHit2");
        explode = Resources.Load<AudioClip>("explode");

        music1 = Resources.Load<AudioClip>("music1");
        music2 = Resources.Load<AudioClip>("music2");
        music3 = Resources.Load<AudioClip>("music3");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "atk1":
                audioSrc.PlayOneShot(atk1);
                break;
            case "atk2":
                audioSrc.PlayOneShot(atk2);
                break;
            case "atkHit1":
                audioSrc.PlayOneShot(atkHit1);
                break;
            case "atkHit2":
                audioSrc.PlayOneShot(atkHit2);
                break;
            case "explode":
                audioSrc.PlayOneShot(explode);
                break;

            case "music1":
                audioSrc.PlayOneShot(music1);
                break;
            case "music2":
                audioSrc.PlayOneShot(music2);
                break;
            case "music3":
                audioSrc.PlayOneShot(music3);
                break;

        }

    }



}
