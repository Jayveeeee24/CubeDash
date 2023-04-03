using System;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public float restartDelay = 1;
    public GameObject completeLevelUI;
    public PlayerMovement player;

    public void GameComplete()
    {
        player.isControllable = false;   
        completeLevelUI.SetActive(true);
    }


    public void GameOver()
    {
        if (!isGameOver) {
            isGameOver = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
