using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    Text coinScore;
    //public AudioClip coinCollectAlert;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            //AudioSource.PlayClipAtPoint(coinCollectAlert, collider.transform.position);
            coinScore = GameObject.Find("CoinScore").GetComponent<Text>();
            coinScore.text = (int.Parse(coinScore.text) + 1).ToString();

            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}
