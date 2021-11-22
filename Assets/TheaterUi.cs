using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TheaterUi : MonoBehaviour
{
    
    public GameObject audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Person")
        {
             audio.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        audio.SetActive(false);
    }
}
