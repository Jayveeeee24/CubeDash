using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGround : MonoBehaviour
{
    public PlayerMovement player;
    private void OnTriggerEnter(Collider collisionInfo)
    { 
        if(collisionInfo.tag == "Player")
        {
            player.isJump = true;
        }
    }
    
}
