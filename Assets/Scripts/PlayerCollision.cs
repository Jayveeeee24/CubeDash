using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement playerMovement;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log(collisionInfo.collider.name);

        if(collisionInfo.collider.tag == "Obstacle")
        {
            //Debug.Log("We hit an obstacle!");
            playerMovement.enabled = false;
            playerMovement.isControllable = false;

            //FindObjectOfType<GameManager>().PlayerDied();
            FindObjectOfType<GameManager>().GameOver();

        }
    }

}
