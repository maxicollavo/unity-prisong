using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameSceneManager gameSceneManager;
    [HideInInspector] public float lives;

    public void Start()
    {
        lives = Config.maxLives;
    }

    public void Hit()
    {
        lives--;
        if (lives <= 0)
        {
            if (gameSceneManager != null)
            {
                gameSceneManager.LoadDeadMenu();
            }
        }
    }

    /*public void IncrementLives(int extraLives)
    {
        if (lives == maxLives)
        {
            return;
        }
        lives += extraLives;
    }*/
}
