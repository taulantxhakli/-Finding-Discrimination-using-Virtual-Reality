using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public GameObject NPC;
    public float FollowSpeed;
    public RaycastHit Shot;

    // Enable the NPC to follow the player.
    void Update() {

        // Makes the NPC look toward the player for their movement.
       transform.LookAt(Player.transform);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
        {
            // Sets how the npc behave when the user is near.
            TargetDistance = Shot.distance;

            // NPC will perform the walk animation at the given Follow Speed toward the player when within Allowed Distance.
            if (TargetDistance >= AllowedDistance)
            {
                FollowSpeed = 0.2f;
                NPC.GetComponent<Animation>().Play("HumanoidWalk");
                transform.position = Vector3.MoveTowards(transform.position,Player.transform.position, FollowSpeed);
            }
            // NPC will remain still with the idle animation when the player is not within Allowed Distance.
            else
            {
                FollowSpeed = 0;
                NPC.GetComponent<Animation>().Play("HumanoidIdle");
            }
        }
    }
}
