using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour { 
    public AudioClip[] clips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Find the audio source
        audioSource = GetComponent<AudioSource>();
        // Sets the audio to not repeat the same music in sequence
        audioSource.loop = false; 

    }

    private AudioClip GetRandomClip()
    {
        // Plays a random clip between 1 and however many clips in the array (3) at random
        return clips[Random.Range(0, clips.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        // When the audio source is not playing, play the next random clip.
        if (!audioSource.isPlaying)
            {
                audioSource.clip = GetRandomClip();
                audioSource.Play();
            }
    }
}
