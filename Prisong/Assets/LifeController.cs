using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameSceneManager gameSceneManager;
    [HideInInspector] public static float lives;
    public GameObject heartHit1;
    public GameObject heartHit2;
    public GameObject heartHit3;
    public GameObject heartHit4;

    public void Start()
    {
        lives = Config.maxLives;
    }
    private void Update()
    {
        if (Traps.tutorialTerminado)
        {
            lives = Config.maxLives;
            heartHit1.SetActive(true);
            heartHit2.SetActive(true);
            heartHit3.SetActive(true);
            heartHit4.SetActive(true);
        }
    }
    public void Hit(int damage)
    {
        lives = lives - damage;
        if (lives == 3)
        {
            heartHit1.SetActive(false);
        }
         if (lives == 2)
         {
            heartHit1.SetActive(false);
            heartHit2.SetActive(false);
         }
         if (lives == 1)
         {
            heartHit1.SetActive(false);
            heartHit2.SetActive(false);
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
