using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    private GameObject triggeringNPC;
    private bool triggering;
    public GameObject npcText;
    public GameObject nextTextButton;
    public TextMeshProUGUI textDisplay;
    public string[] sentences; //string array that holds our sentences
    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    void Start()
    {
        StartCoroutine(Type());
    }
  
    // Displays the npcText for the player to interact with the npc when the player is within trigger range of box collider
    void Update()
    {
         
        if(triggering) 
        {
            // The text will only be seen when talking to the npc
            
            //textDisplay.SetActive(true);
             npcText.SetActive(true);
                nextTextButton.SetActive(true);
            
             if(textDisplay.text == sentences[index]){
                 continueButton.SetActive(true);
            }
            // Allows the user to trigger dialogue when the player presses E
            if (Input.GetKeyDown(KeyCode.E))
            {
               
                print("Player is triggering with " + triggeringNPC);
               
            }

        } else {
            // The text will not be seen when not talking to the npc
            npcText.SetActive(false);
            nextTextButton.SetActive(false);
        }
    }

    // Activates the update function when player enters box collider
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
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
    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence(){
        continueButton.SetActive(false);
        if(index < sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
