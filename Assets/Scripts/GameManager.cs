using System;
using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public float restartDelay = 1;

    public GameObject completeLevelUI;
    public Image chapterImage, coinImage;
    public PlayerMovement player;

    public static int heart = 3;
    private Animation anim;
    public Image heart1, heart2, heart3;

    public bool isShieldActive = false;
    public GameObject Shield;

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

    public IEnumerator ActivateShield()
    {
        Shield.SetActive(true);
        isShieldActive = true;
        yield return new WaitForSeconds(2.5f);
        Shield.SetActive(false);
        isShieldActive = false;
    }

    public void GameComplete()
    {
        chapterImage.enabled = false;
        coinImage.enabled = false;
        player.enabled = false;
        completeLevelUI.SetActive(true);
    }
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Invoke("Restart", restartDelay);
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
        return heart;
    }

    void Restart()
    {
        heart = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
