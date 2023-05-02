using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public AudioClip collideAlert;

    //public CameraShake cameraShake;
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (FindObjectOfType<GameManager>().isShieldActive == true)
        {
            if (collisionInfo.collider.name.Contains("Obstacle"))
            {
                Destroy(collisionInfo.gameObject);
            }
        }
        else
        {
            if (collisionInfo.collider.tag == "Obstacle")
            {
                AudioSource.PlayClipAtPoint(collideAlert, transform.position);

                if (collisionInfo.collider.name.Contains("Obstacle"))
                {
                    //Destroy(collisionInfo.gameObject);
                    StartCoroutine(DestroyObstacle(collisionInfo.gameObject));
                }
                else if (collisionInfo.collider.name.Contains("Wall"))
                {
                    StartCoroutine(MovePlayer());
                }

                if (FindObjectOfType<GameManager>().removeHeart() <= 0)
                {
                    playerMovement.enabled = false;
                    playerMovement.isControllable = false;

                    FindObjectOfType<GameManager>().GameOver();
                }


                StartCoroutine(FindObjectOfType<GameManager>().ActivateShield());
                //StartCoroutine(FindObjectOfType<GameManager>().Flash(1f, .5f));
            }

        }

    }

    IEnumerator DestroyObstacle(GameObject gameObject)
    {
        playerMovement.enabled = false;
        yield return new WaitForSeconds(.7f);
        Destroy(gameObject);
        playerMovement.enabled = true;
    }

    IEnumerator MovePlayer()
    {
        playerMovement.enabled = false;
        yield return new WaitForSeconds(.7f);
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        playerMovement.enabled = true;
    }

}
