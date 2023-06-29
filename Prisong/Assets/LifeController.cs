using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameSceneManager gameSceneManager;
    [HideInInspector] public float lives;
    public GameObject heartHit1;
    public GameObject heartHit2;
    public GameObject heartHit3;

    public void Start()
    {
        lives = Config.maxLives;
    }

    public void Hit(int damage)
    {
        lives = lives - damage;
        Debug.Log(lives);
        if (lives == 3)
        {
            heartHit1.SetActive(false);
        }
        else if (lives == 2)
        {
            heartHit2.SetActive(false);
        }
        else if (lives == 1)
        {
            heartHit3.SetActive(false);
        }
        if (lives <= 0 /*&& TPDarkWorld.realWorld == true*/)
        {
            if (gameSceneManager != null)
            {
                gameSceneManager.LoadDeadMenu();
            }
        }
        /*else if (lives <= 0 && TPDarkWorld.realWorld == false*)
        {
            if (gameSceneManager != null)
            {
                gameSceneManager.LoadDeadMenu();
            }
        }*/
    }
}
