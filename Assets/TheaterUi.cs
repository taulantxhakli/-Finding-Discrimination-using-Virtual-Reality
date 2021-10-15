using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TheaterUi : MonoBehaviour
{
    public GameObject NpcDialogue;
    public GameObject NpcChatBubble;
    public GameObject NpcName;
    public GameObject UserChatBubble;
    public GameObject UserDialogue;
    public GameObject nextText;
  
    // Start is called before the first frame update
    void Start()
    {
        NpcDialogue.SetActive(false);
        NpcChatBubble.SetActive(false);
        NpcName.SetActive(false);
        UserChatBubble.SetActive(false);
        UserDialogue.SetActive(false);
        nextText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Person")
        {
            NpcDialogue.SetActive(true);
            NpcChatBubble.SetActive(true);
            NpcName.SetActive(true);
            UserChatBubble.SetActive(true);
            UserDialogue.SetActive(true);
            nextText.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        NpcDialogue.SetActive(false);
        NpcChatBubble.SetActive(false);
        NpcName.SetActive(false);
        UserChatBubble.SetActive(false);
        UserDialogue.SetActive(false);
        nextText.SetActive(false);
    }
}
