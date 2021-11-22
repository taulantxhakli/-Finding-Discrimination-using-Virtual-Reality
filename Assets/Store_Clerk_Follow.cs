using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Store_Clerk_Follow : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 6;
    public GameObject NPC;
    public float FollowSpeed;
    public RaycastHit Shot;
    public Animator anim;
    public bool isWalking;
    public int timer = 1000;
    public GameObject eyes;
    public RaycastHit Collide;
    public static int DialougeCounter = 0;
    public bool isTalking = false;
    public GameObject startPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Enable the NPC to follow the player.
    void Update()
    {


        // Makes the NPC look toward the player for their movement.
        transform.LookAt(Player.transform);
        if (Physics.Raycast(eyes.transform.position, transform.TransformDirection(Vector3.forward), out Shot, 26f) && Shot.collider.tag == "Person")
        {
            // Sets how the npc behave when the user is near.
            //if (Shot.transform.tag == "Person")
            //{
            TargetDistance = Shot.distance;
            //}


            // NPC will perform the walk animation at the given Follow Speed toward the player when within Allowed Distance.
            if (!isWalking && !isTalking && TargetDistance >= AllowedDistance && DialougeCounter < 3)
            {
                if (timer > 0)
                {
                    timer--;
                }
                else if (timer <= 0)
                {
                    FollowSpeed = 0.02f;
                    anim.SetBool("isWalking", true);
                    anim.Play("Locomotion.Walk", 0, 0f);
                    isWalking = true;
                }
            }
            else if (isWalking && !isTalking && TargetDistance >= AllowedDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Collide, 4f) && Collide.collider.tag == "Untagged" && transform.rotation.y < 180)
                {
                    //UnityEngine.Debug.Log(FollowSpeed);
                    transform.Rotate(0, 0f, 0);
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-10f, 0f, 25f), FollowSpeed + 0.02f);
                }
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Collide, 4f) && Collide.collider.tag == "Untagged" && transform.rotation.y >= 180)
                {
                    transform.Rotate(0, 0f, 0);
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(10f, 0f, 25f), FollowSpeed + 0.02f);
                }
            }
            // NPC will remain still with the idle animation when the player is not within Allowed Distance.
            else if (isWalking && !isTalking && TargetDistance < AllowedDistance)
            {
                FollowSpeed = 0;
                //NPC.GetComponent<Animation>().Play("HumanoidIdle");
                anim.SetBool("isWalking", false);
                anim.Play("Locomotion.Idle", 0, 0f);
                isWalking = false;
                isTalking = true;
            }
            // NPC will stir a small conversation with the player, getting more suspicious each time
            else if (isTalking && !isWalking)
            {
                /*
                if(DialougeCounter == 0)
                {

                }
                else if (DialougeCounter == 1)
                {

                }
                else if (DialougeCounter == 2)
                {

                }
                */
                if (Input.GetKeyDown("space"))
                {
                    DialougeCounter++;
                    isWalking = true;
                }
            }

            //Walk back to counter after player talks to NPC
            else if (isTalking && isWalking)
            {
                FollowSpeed = 0.02f;
                transform.LookAt(startPosition.transform);
                transform.position = Vector3.MoveTowards(transform.position, startPosition.transform.position, FollowSpeed);
                UnityEngine.Debug.Log(FollowSpeed);
                anim.Play("Locomotion.Walk", 0, 0f);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Collide, 2f) && Collide.collider.tag == "Untagged" && transform.rotation.y < 180)
                {
                    //UnityEngine.Debug.Log(FollowSpeed);
                    transform.Rotate(0, 0f, 0);
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-10f, 0f, 10f), FollowSpeed + 0.02f);
                }
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Collide, 2f) && Collide.collider.tag == "Untagged" && transform.rotation.y >= 180)
                {
                    transform.Rotate(0, 0f, 0);
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(10f, 0f, 10f), FollowSpeed + 0.02f);
                }
                float dist = Vector3.Distance(transform.position, startPosition.transform.position);
                if (dist <= 2)
                {
                    if (DialougeCounter < 3)
                    {
                        timer = 1000;
                    }
                    else
                    {
                        UnityEngine.Debug.Log("Security");
                    }
                    anim.Play("Locomotion.Idle", 0, 0f);
                    isTalking = false;
                    isWalking = false;
                }
            }
        }
    }
}