using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement playerMovement;
    private void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log(collisionInfo.collider.name);

        if(collisionInfo.collider.tag == "Obstacle")
        {
            //Debug.Log("We hit an obstacle!");
            if (collisionInfo.collider.name.Contains("Obstacle"))
            {
                StartCoroutine(DestroyObstacle(collisionInfo.gameObject));
            }
            if (FindObjectOfType<GameManager>().removeHeart() <= 0)
            {
                playerMovement.enabled = false;
                playerMovement.isControllable = false;

                FindObjectOfType<GameManager>().GameOver();
            }

        }
    }

    IEnumerator DestroyObstacle(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

}
