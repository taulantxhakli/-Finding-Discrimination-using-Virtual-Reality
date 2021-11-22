using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public ChatBubble otherScipt;
    public NPC npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown (KeyCode.N))
        {
            Debug.Log(" N key was pressed");
            otherScipt.NextSentence();
            
            
        }
        if (Input.GetKeyDown (KeyCode.N))
        {
            Debug.Log(" N key was pressed");
            otherScipt.PlayerSentence();
            
            Debug.Log(" end of player sentence");
        }



          if (Input.GetKeyDown (KeyCode.Alpha1))
        {
            Debug.Log(" 1 key was pressed");
            otherScipt.NextSentence();
        }
         if (Input.GetKeyDown (KeyCode.Alpha1))
        {
            Debug.Log(" 1 key was pressed");
            otherScipt.PlayerSentence();
            
            Debug.Log(" end of player sentence");
        }
          if (Input.GetKeyDown (KeyCode.Alpha2))
        {
            Debug.Log(" 2 key was pressed");
            otherScipt.NextSentence();
        }
        if (Input.GetKeyDown (KeyCode.Alpha2))
        {
            Debug.Log(" 2 key was pressed");
            otherScipt.PlayerSentence();
            
            Debug.Log(" end of player sentence");
        }
          if (Input.GetKeyDown (KeyCode.Alpha3))
        {
            Debug.Log(" 3 key was pressed");
            otherScipt.NextSentence();    
        }
        if (Input.GetKeyDown (KeyCode.Alpha3))
        {
            Debug.Log(" 3 key was pressed");
            otherScipt.PlayerSentence();
            
            Debug.Log(" end of player sentence");
        }
    }
}
