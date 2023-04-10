using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    Text coinScore;

    private void OnCollisionEnter(Collision collider)
    {
        //if (collider.collider.tag == "Player")
        //{

        //    coinScore = GameObject.Find("CoinScore").GetComponent<Text>();
        //    coinScore.text = (int.Parse(coinScore.text) + 1).ToString();

        //    //Destroy(gameObject);
        //    Destroy(gameObject);
        //}
    }
}
