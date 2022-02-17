using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class clerkAudio : MonoBehaviour
{  
    public string ClerkName;
    public int count = 0;
    public AudioClip[] clerkDialogue;
    public AudioClip exitWhistle;
    private AudioSource audioSource;
    private AudioSource exitAudio;
    // Start is called before the first frame update
    void Start()
    {
         audioSource = GetComponent<AudioSource>();
         exitAudio = GetComponent<AudioSource>();
         
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
        count++;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Person" && count == 0)
        {
            
            StartCoroutine(playAudioSequentially());
            Console.WriteLine("Npc is in the Collider");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Person")
        {
        //Once Player Exits collider the Conversation stops 
           audioSource.Stop();
           // Then the clerk whistles when the player exits the collider
           exitAudio.clip = exitWhistle;
           exitAudio.Play();
        }
    }
}