using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Security_Guard : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 1.5f;
    public GameObject NPC;
    public float FollowSpeed;
    public RaycastHit Shot;
    public Animator anim;
    public bool isWalking;
    public int timer = 200;
    public GameObject eyes;
    public RaycastHit Collide;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Store_Clerk_Follow.DialougeCounter == 3)
        {
            transform.LookAt(Player.transform);
            if (Physics.Raycast(eyes.transform.position, transform.TransformDirection(Vector3.forward), out Shot, 26f) && Shot.collider.tag == "Person")
            {
                TargetDistance = Shot.distance;

                if (!isWalking && TargetDistance >= AllowedDistance)
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

                else if (isWalking && TargetDistance >= AllowedDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
                }

                else if (isWalking && TargetDistance < AllowedDistance)
                {
                    FollowSpeed = 0;
                    //NPC.GetComponent<Animation>().Play("HumanoidIdle");
                    anim.SetBool("isWalking", false);
                    anim.Play("Locomotion.Idle", 0, 0f);
                    isWalking = false;
                }
            }
        }
    }
}
