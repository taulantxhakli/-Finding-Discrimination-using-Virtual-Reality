using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DanceScript : MonoBehaviour
{
    public string ClerkName;
    public AudioClip[] clerkDialogue;
    public AudioClip music;
    private AudioSource audioSource;
    private AudioSource musicAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicAudio = GetComponent<AudioSource>();
       
       
    }

    IEnumerator playAudioSequentially()
    {   
        
        WaitForSeconds wfs = new WaitForSeconds(10);
       

      
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
               
                yield return wfs;

            }
            
            


            //5. Go back to #2 and play the next audio in the adClips array
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Person")
        {

            StartCoroutine(playAudioSequentially());
           
            Console.WriteLine("Npc is in the Collider");
        }
    }

  
}
