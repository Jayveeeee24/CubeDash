using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    Text coinScore;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            coinScore = GameObject.Find("CoinScore").GetComponent<Text>();
            coinScore.text = (int.Parse(coinScore.text) + 1).ToString();

            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}
