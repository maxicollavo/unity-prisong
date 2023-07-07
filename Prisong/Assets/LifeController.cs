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
    public GameObject heartHitBlue1;
    public GameObject heartHitBlue2;
    public GameObject heartHitBlue3;
    public GameObject heartHitBlue4;

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
            heartHitBlue1.SetActive(true);
            heartHitBlue2.SetActive(true);
            heartHitBlue3.SetActive(true);
            heartHitBlue4.SetActive(true);
        }
    }

    void ShowRedHearts()
    {
        heartHit1.SetActive(true);
        heartHit2.SetActive(true);
        heartHit3.SetActive(true);
        heartHit4.SetActive(true);
    }

    void NotShowRedHearts()
    {
        heartHit1.SetActive(false);
        heartHit2.SetActive(false);
        heartHit3.SetActive(false);
        heartHit4.SetActive(false);
    }

    void ShowBlueHearts()
    {
        heartHitBlue1.SetActive(true);
        heartHitBlue2.SetActive(true);
        heartHitBlue3.SetActive(true);
        heartHitBlue4.SetActive(true);
    }

    void NotShowBlueHearts()
    {
        heartHitBlue1.SetActive(false);
        heartHitBlue2.SetActive(false);
        heartHitBlue3.SetActive(false);
        heartHitBlue4.SetActive(false);
    }


    public IEnumerator LivesElectro()
    {
        ShowRedHearts();
        NotShowBlueHearts();
        yield return new WaitForSeconds(0.5f);
        NotShowRedHearts();
        ShowBlueHearts();
        yield return new WaitForSeconds(0.5f);
        ShowRedHearts();
        NotShowBlueHearts();
    }

    public void Hit(int damage)
    {
        lives = lives - damage;
        NotShowBlueHearts();
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
