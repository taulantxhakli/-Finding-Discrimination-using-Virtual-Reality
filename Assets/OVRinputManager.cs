using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRinputManager : MonoBehaviour
{
   public ChatBubble otherScipt;

   
    void Update()
    {
        	if (OVRInput.Get(OVRInput.Button.One))
			{
				Debug.Log(" A button was pressed on the controller for NPC sentence");
                otherScipt.NextSentence();
			}
            if (OVRInput.Get(OVRInput.Button.One))
            {
                Debug.Log("A button was pressed on the controller for Player Sentence");
                otherScipt.PlayerSentence();
            
            Debug.Log(" end of player sentence");
            }
    }
}
