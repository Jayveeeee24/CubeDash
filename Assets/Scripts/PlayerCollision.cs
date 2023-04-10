using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    Text coinScore;

    //public CameraShake cameraShake;
    private void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log(collisionInfo.collider.name);

        //coinScore = GameObject.Find("CoinScore").GetComponent<Text>();
        //if (collisionInfo.collider.tag == "Collectibles")
        //{
        //    //collisionInfo.gameObject.SetActive(false);
        //    Destroy(collisionInfo.gameObject);

        //    if (collisionInfo.collider.name.Contains("Coin"))
        //    {
        //        coinScore.text = (int.Parse(coinScore.text) + 1).ToString();
        //    }
        //}
        if (collisionInfo.collider.tag == "Obstacle")
        {
            //StartCoroutine(cameraShake.Shake(.1f, .01f));
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
