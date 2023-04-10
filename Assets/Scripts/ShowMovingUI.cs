using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowMovingUI : MonoBehaviour
{
    public Canvas MovingUIWarning;
    public Rigidbody player;
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            StartCoroutine(WarningMovingObstacle());
        }
    }

    IEnumerator WarningMovingObstacle()
    {
        player.isKinematic = true;
        MovingUIWarning.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        player.isKinematic = false;
        MovingUIWarning.gameObject.SetActive(false);
        //transform.position = new Vector3(transform.position.x, -10f, transform.position.z);
        Destroy(gameObject);
    }



}
