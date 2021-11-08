using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clerkAudio : MonoBehaviour
{
    public string ClerkName;
    public AudioClip[] clerkDialogue;
    private AudioSource audioSource;
    private GameObject triggeringNPC;
    private bool triggering;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(playAudioSequentially());
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
        if (other.tag == "NPC")
        {
            triggering = true;
            triggeringNPC = other.gameObject;

        }
    }

    // Deactivates the update function when player exits box collider
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggering = false;
            triggeringNPC = null;

        }
    }

}
