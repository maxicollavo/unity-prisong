using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameSceneManager gameSceneManager;
    [HideInInspector] public float lives;
    public float teleportHeightDown = -48f;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public void Start()
    {
        lives = Config.maxLives;
    }

    public void Hit()
    {
        lives--;
        if (lives <= 0 && TPDarkWorld.realWorld == true)
        {
            /*Vector3 newPosition = new Vector3(transform.position.x, teleportHeightDown, transform.position.z);
            transform.position = newPosition;
            lives = 1;*/
            if (gameSceneManager != null)
            {
                gameSceneManager.LoadDeadMenu();
            }
        }
        else if (lives <= 0 && TPDarkWorld.darkWorld == true)
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
