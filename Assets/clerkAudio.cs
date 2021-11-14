﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clerkAudio : MonoBehaviour
{
    public string ClerkName;
    public AudioClip[] clerkDialogue;
    public AudioClip exitWhistle;
    private AudioSource exitAudio;
    private AudioSource audioSource;
    private GameObject triggeringNPC;
    private bool triggering;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        exitAudio = GetComponent<AudioSource>();
       // StartCoroutine(playAudioSequentially());
    }

    IEnumerator playAudioSequentially()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < clerkDialogue.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = clerkDialogue[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Person")
        {
            triggering = true;
           
            StartCoroutine(playAudioSequentially());
        }
    }

    // Deactivates the update function when player exits box collider
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Person")
        {
            //Once Player Exits collider the conversation stops
            triggering = false;
            audioSource.Stop();
            //Then the clerk whistles when the player exits the collider
            exitAudio.clip = exitWhistle;
            exitAudio.Play();

        }
    }

}
