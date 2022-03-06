using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNewScene : MonoBehaviour
{
    public string PlayerTag = "Person";
    private GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag(PlayerTag);
        CharacterController cc = thePlayer.GetComponent<CharacterController>();
        Debug.Log("Room " + MallData.previousSceneLocation);

        if (MallData.previousSceneLocation == 1)
        {
            cc.enabled = false;
            //  move to location just outside of dance door
            cc.transform.position = new Vector3(-74.0f, 0.98f, -22.98f);
            cc.enabled = true;

            Debug.Log("Change location here");
            MallData.previousSceneLocation = -1;
            Debug.Log("New Room " + MallData.previousSceneLocation);
        }

        if (MallData.previousSceneLocation == 2)
        {
            cc.enabled = false;
            //  move to location just outside of lecture door
            cc.transform.position = new Vector3(-44.0f, 0.98f, 41.0f);
            cc.enabled = true;

            Debug.Log("Change location here");
            MallData.previousSceneLocation = -1;
            Debug.Log("New Room " + MallData.previousSceneLocation);
        }
    }
          

    // Update is called once per frame
    void Update()
    {       
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "DanceDoor")
        {
            Debug.Log("hit the dance studio door");
            SceneManager.LoadScene(1);
        }

        if (hit.gameObject.tag == "DanceExit")
        {
            Debug.Log("hit the dance exit door");
            MallData.previousSceneLocation = 1;
            SceneManager.LoadScene(0);
        }

        if (hit.gameObject.tag == "DanceBR")
        {
            Debug.Log("hit the dance studio br door");
            SceneManager.LoadScene(4);
        }

        if (hit.gameObject.tag == "Bathroom")
        {
            Debug.Log("hit the bathroom door");
            SceneManager.LoadScene(2);
        }

        if (hit.gameObject.tag == "BathroomExit")
        {
            Debug.Log("hit the bathroom door");
            MallData.previousSceneLocation = 2;
            SceneManager.LoadScene(0);
        }

        if (hit.gameObject.tag == "DressingRoom")
        {
            Debug.Log("hit the dressing door");
            SceneManager.LoadScene(3);
        }

        if (hit.gameObject.tag == "DressingRoomExit")
        {
            Debug.Log("hit the bathroom door");
            MallData.previousSceneLocation = 3;
            SceneManager.LoadScene(0);
        }
    }
}
