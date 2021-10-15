 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{ 
    public NPC npc;
    private  SpriteRenderer speechBubbleSpriteRenderer;
    
    public TextMeshPro npcName;
    public  TextMeshPro npcDialogueBox;
	public TextMeshPro playerResponse;
   
    private Queue<string> sentences2;
    private Queue<string> sentences3;
    private int index = 0;
    

    private void Awake(){
        speechBubbleSpriteRenderer = transform.Find("Speechbubble_2").GetComponent<SpriteRenderer>();
        speechBubbleSpriteRenderer = transform.Find("Speechbubble_3").GetComponent<SpriteRenderer>();
        npcName = transform.Find("NPC Name Text").GetComponent<TextMeshPro>();
        npcDialogueBox = transform.Find("NPC dialogue").GetComponent<TextMeshPro>();
        playerResponse = transform.Find("Player Response").GetComponent<TextMeshPro>();
    }
    private void Start()
    {
       sentences2 = new Queue<string>();
        
        StartDialogue(npc);

    }

    public void StartDialogue (NPC npc)
	{
		Debug.Log("This is the start Dialogue");
		sentences2.Clear();

		foreach (string sentence in npc.dialogue)
		{
            npcName.text = npc.name;  
            
			sentences2.Enqueue(sentence);
		}
        playerResponse.text = npc.playerDialogue[0];


		NextSentence();
        
	}

    IEnumerator Type(string sentence){
        // foreach (char letter in sentences[index].ToCharArray())
        foreach (char letter in sentence.ToCharArray())
        {
            
            npcDialogueBox.text += letter;
            yield return null;
             Debug.Log(" This Chat Bubble funtion is being called");
        }
    }
    public void NextSentence(){
         Debug.Log(" This nextSentences funtion is being called");
        if (sentences2.Count == 0)
		{
			npcDialogueBox.text = "";
            sentences2.Clear();
			return;
		}else{
            string sentence = sentences2.Dequeue();
		    StopAllCoroutines();
            npcDialogueBox.text = "";
		    StartCoroutine(Type(sentence));
        }

		
    }
    public void PlayerSentence(){
            if(index < npc.playerDialogue.Length){
                index++;
                playerResponse.text = npc.playerDialogue[index];
            }else
            {
                playerResponse.text = "";
            }  
        
    }
   
}



