using System;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public float restartDelay = 1;
    public GameObject completeLevelUI;
    public PlayerMovement player;

    public static int heart = 3;
    private Animation anim;
    public Image heart1, heart2, heart3;

    public void Start()
    {
        if(heart == 2)
        {
            heart3.enabled = false;
        }
        else if(heart == 1)
        {
            heart3.enabled = false;
            heart2.enabled = false;
        }
        else
        {
            heart3.enabled = true;
            heart2.enabled = true;
            heart2.enabled = true;
        }
    }

    public void GameComplete()
    {
        player.isControllable = false;   
        completeLevelUI.SetActive(true);
    }


    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Invoke("Restart", restartDelay);

            heart = 3;
        }
    }

    public int removeHeart()
    {
        if (heart == 3)
        {
            anim = heart3.GetComponent<Animation>();
            anim["HeartFade"].layer = 123;
            anim.Play();
        }else if(heart == 2)
        {
            anim = heart2.GetComponent<Animation>();
            anim["HeartFade"].layer = 123;
            anim.Play();
        }
        else
        {
            anim = heart1.GetComponent<Animation>();
            anim["HeartFade"].layer = 123;
            anim.Play();
        }

        heart--;
        Debug.Log(heart);
        return heart;
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
    }


}
