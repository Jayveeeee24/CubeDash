using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOver == false)
        {
            scoreText.text = player.position.z.ToString("0");
        }
    }
}
